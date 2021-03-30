namespace BookShop
{
    using BookShop.Models.Enums;
    using Data;
    using Initializer;
    using Microsoft.EntityFrameworkCore;
    using System;
    using System.Globalization;
    using System.IO;
    using System.Linq;
    using System.Text;

    public class StartUp
    {
        public static void Main()
        {
            using var db = new BookShopContext();
            //DbInitializer.ResetDatabase(db);

            var result = RemoveBooks(db);

            Console.WriteLine(result);
        }

        public static int RemoveBooks(BookShopContext context)
        {
            var books = context.Books
                .Where(b => b.Copies < 4200)
                .ToList();

            context.Books.RemoveRange(books);

            context.SaveChanges();

            return books.Count;
        }

        public static void IncreasePrices(BookShopContext context)
        {
            var books = context.Books
                .Where(book => book.ReleaseDate.Value.Year < 2010)
                .ToList();

            foreach (var book in books)
            {
                book.Price += 5;
            }

            context.SaveChanges();
        }

        public static string GetMostRecentBooks(BookShopContext context)
        {
            var categoryBooks = context.Categories
                .Select(category => new
                {
                    CatName = category.Name,
                    Books = category.CategoryBooks.Select(b => new
                    {
                        Title = b.Book.Title,
                        Date = b.Book.ReleaseDate.Value,
                    })
                    .OrderByDescending(b => b.Date)
                    .Take(3)
                    .ToList(),
                })
                .OrderBy(x => x.CatName)
                .ToList();

            var sb = new StringBuilder();

            foreach (var category in categoryBooks)
            {
                sb.AppendLine($"--{category.CatName}");

                foreach (var book in category.Books)
                {
                    sb.AppendLine($"{book.Title} ({book.Date.Year})");
                }
            }

            return sb.ToString().TrimEnd();
        }

        public static string GetTotalProfitByCategory(BookShopContext context)
        {
            var categories = context.Categories
                .Select(category => new
                {
                    category.Name,
                    Profit = category.CategoryBooks.Sum(b => b.Book.Price * b.Book.Copies),
                })
                .OrderByDescending(p => p.Profit)
                .ThenBy(x => x.Name)
                .ToArray();

            var result = string.Join(Environment.NewLine, categories.Select(c => $"{c.Name} ${c.Profit:F2}"));

            return result;
        }

        public static string CountCopiesByAuthor(BookShopContext context)
        {
            var authors = context.Authors
                .Select(author => new
                {
                    author.FirstName,
                    author.LastName,
                    TotalCopies = author.Books.Sum(b => b.Copies)
                })
                .OrderByDescending(t => t.TotalCopies)
                .ToList();

            var result = string.Join(Environment.NewLine, authors.Select(author => $"{author.FirstName} {author.LastName} - {author.TotalCopies}"));

            return result;
        }

        public static int CountBooks(BookShopContext context, int lengthCheck)
        {
            var books = context.Books
                .Where(book => book.Title.Length > lengthCheck)
                .ToList();

            return books.Count;
        }

        public static string GetBooksByAuthor(BookShopContext context, string input)
        {
            var booksAndAuthors = context.Books
                .Where(book => EF.Functions.Like(book.Author.LastName, $"{input}%"))
                .Select(x => new
                {
                    BookId = x.BookId,
                    Title = x.Title,
                    AuthorName = x.Author.FirstName + " " + x.Author.LastName,
                })
                .OrderBy(x => x.BookId)
                .ToList();

            var result = string.Join(Environment.NewLine,
                booksAndAuthors.Select(x => $"{x.Title} ({x.AuthorName})"));

            return result;
        }

        public static string GetBookTitlesContaining(BookShopContext context, string input)
        {
            var books = context.Books
                .Where(title => EF.Functions.Like(title.Title, $"%{input}%"))
                .Select(book => book.Title)
                .OrderBy(x => x)
                .ToList();

            var result = string.Join(Environment.NewLine, books);

            return result;
        }

        public static string GetAuthorNamesEndingIn(BookShopContext context, string input)
        {
            var authors = context.Authors
                .Where(author => EF.Functions.Like(author.FirstName, $"%{input}"))
                .Select(x => new
                { 
                    x.FirstName,
                    x.LastName,
                })
                .OrderBy(x => x.FirstName)
                .ThenBy(x => x.LastName)
                .ToList();

            var result = string.Join(Environment.NewLine, authors.Select(x => $"{x.FirstName} {x.LastName}"));

            return result;
        }

        public static string GetBooksReleasedBefore(BookShopContext context, string date)
        {
            var targetDate = DateTime.ParseExact(date, "dd-MM-yyyy", CultureInfo.InvariantCulture);

            var books = context.Books
                .Where(x => x.ReleaseDate.Value < targetDate)
                .Select(x => new
                {
                    x.Title,
                    x.EditionType,
                    x.Price,
                    x.ReleaseDate.Value
                })
                .OrderByDescending(x => x.Value)
                .ToList();

            var result = string.Join(Environment.NewLine,
                books.Select(book => $"{book.Title} - {book.EditionType} - ${book.Price:F2}"));

            return result;
        }

        public static string GetBooksByCategory(BookShopContext context, string input)
        {
            var categories = input.Split(' ', StringSplitOptions.RemoveEmptyEntries)
                .Select(x => x.ToLower())
                .ToArray();

            var books = context.Books
                .Include(x => x.BookCategories)
                .ThenInclude(x => x.Category)
                .Where(book => book.BookCategories
                    .Any(category => categories.Contains(category.Category.Name.ToLower())))
                .Select(books => books.Title)
                .OrderBy(title => title)
                .ToArray();

            var result = string.Join(Environment.NewLine, books);

            return result;
        }

        public static string GetBooksNotReleasedIn(BookShopContext context, int year)
        {
            var books = context.Books
                .Where(book => book.ReleaseDate.Value.Year != year)
                .Select(book => new
                { 
                    book.Title,
                    book.BookId,
                })
                .OrderBy(x => x.BookId)
                .ToList();

            var result = string.Join(Environment.NewLine, books.Select(x => x.Title));

            return result;
        }

        public static string GetBooksByPrice(BookShopContext context)
        {
            var books = context.Books
                .Where(x => x.Price > 40)
                .Select(x => new
                {
                    Title = x.Title,
                    Price = x.Price,
                })
                .OrderByDescending(x => x.Price)
                .ToList();

            var result = string.Join(Environment.NewLine, 
                books.Select(x => $"{x.Title} - ${x.Price:F2}"));

            return result;
        }

        public static string GetGoldenBooks(BookShopContext context)
        {
            var goldenBooks = context.Books
                .Where(books => books.Copies < 5000
                && books.EditionType == EditionType.Gold)
                .Select(book => new
                {
                    Id = book.BookId,
                    Title = book.Title,
                })
                .OrderBy(bookId => bookId.Id)
                .ToList();

            var result = string.Join(Environment.NewLine, goldenBooks.Select(x => x.Title));

            return result;
        }

        public static string GetBooksByAgeRestriction(BookShopContext context, string command)
        {
            var ageRestriction = Enum.Parse<AgeRestriction>(command, true);

            var books = context.Books
                .Where(books => books.AgeRestriction == ageRestriction)
                .Select(book => book.Title)
                .OrderBy(title => title)
                .ToList();

            var result = string.Join(Environment.NewLine, books);

            return result;
        }
    }
}
