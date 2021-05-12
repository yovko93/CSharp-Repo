namespace BookShop.DataProcessor
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.Globalization;
    using System.IO;
    using System.Linq;
    using System.Text;
    using System.Xml.Serialization;
    using BookShop.Data.Models;
    using BookShop.Data.Models.Enums;
    using BookShop.DataProcessor.ImportDto;
    using Data;
    using Newtonsoft.Json;
    using ValidationContext = System.ComponentModel.DataAnnotations.ValidationContext;

    public class Deserializer
    {
        private const string ErrorMessage = "Invalid data!";

        private const string SuccessfullyImportedBook
            = "Successfully imported book {0} for {1:F2}.";

        private const string SuccessfullyImportedAuthor
            = "Successfully imported author - {0} with {1} books.";

        public static string ImportBooks(BookShopContext context, string xmlString)
        {
            var sb = new StringBuilder();

            XmlSerializer xmlSerializer = new XmlSerializer(typeof(BookImportDto[]), new XmlRootAttribute("Books"));

            var booksDto = (BookImportDto[])xmlSerializer.Deserialize(new StringReader(xmlString));

            foreach (var xmlBook in booksDto)
            {
                if (!IsValid(xmlBook))
                {
                    sb.AppendLine(ErrorMessage);
                    continue;
                }

                DateTime publishedOn;
                bool isDateValid = DateTime.TryParseExact(xmlBook.PublishedOn, "MM/dd/yyyy", CultureInfo.InvariantCulture, DateTimeStyles.None, out publishedOn);

                if (!isDateValid)
                {
                    sb.AppendLine(ErrorMessage);
                    continue;
                }

                var book = new Book
                {
                    Name = xmlBook.Name,
                    Genre = (Genre)xmlBook.Genre,
                    Price = xmlBook.Price,
                    Pages = xmlBook.Pages,
                    PublishedOn = publishedOn,
                };

                context.Books.Add(book);
                context.SaveChanges();

                sb.AppendLine(String.Format(SuccessfullyImportedBook, book.Name, book.Price));
            }
           
            return sb.ToString().TrimEnd();
        }

        public static string ImportAuthors(BookShopContext context, string jsonString)
        {
            var sb = new StringBuilder();
            var authors = new List<Author>();

            var jsonAuthors = JsonConvert.DeserializeObject<AuthorImportDto[]>(jsonString);

            foreach (var jsonAuthor in jsonAuthors)
            {
                if (!IsValid(jsonAuthor))
                {
                    sb.AppendLine(ErrorMessage);
                    continue;
                }

                if (authors.Any(a => a.Email == jsonAuthor.Email))
                {
                    sb.AppendLine(ErrorMessage);
                    continue;
                }

                var author = new Author
                {
                    FirstName = jsonAuthor.FirstName,
                    LastName = jsonAuthor.LastName,
                    Phone = jsonAuthor.Phone,
                    Email = jsonAuthor.Email,
                };

                foreach (var bookDto in jsonAuthor.Books)
                {
                    if (!bookDto.BookId.HasValue)
                    {
                        continue;
                    }

                    var book = context
                        .Books
                        .FirstOrDefault(b => b.Id == bookDto.BookId);

                    if (book == null)
                    {
                        continue;
                    }

                    author.AuthorsBooks.Add(new AuthorBook
                    {
                        Author = author,
                        Book = book
                    });
                }

                if (author.AuthorsBooks.Count == 0)
                {
                    sb.AppendLine(ErrorMessage);
                    continue;
                }

                authors.Add(author);
                string fullName = $"{author.FirstName} {author.LastName}";

                sb.AppendLine(String.Format(SuccessfullyImportedAuthor, fullName, author.AuthorsBooks.Count));
            }

            context.Authors.AddRange(authors);
            context.SaveChanges();

            return sb.ToString().TrimEnd();
        }

        private static bool IsValid(object dto)
        {
            var validationContext = new ValidationContext(dto);
            var validationResult = new List<ValidationResult>();

            return Validator.TryValidateObject(dto, validationContext, validationResult, true);
        }
    }
}