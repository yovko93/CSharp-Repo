namespace BookShop.DataProcessor
{
    using System;
    using System.Globalization;
    using System.IO;
    using System.Linq;
    using System.Text;
    using System.Xml;
    using System.Xml.Serialization;
    using BookShop.Data.Models.Enums;
    using BookShop.DataProcessor.ExportDto;
    using Data;
    using Microsoft.EntityFrameworkCore;
    using Newtonsoft.Json;

    public class Serializer
    {
        public static string ExportMostCraziestAuthors(BookShopContext context)
        {
            var authors = context
                .Authors
                .Select(a => new
                {
                    AuthorName = $"{a.FirstName} {a.LastName}",
                    Books = a.AuthorsBooks
                    .OrderByDescending(b => b.Book.Price)
                    .Select(b => new
                    {
                        BookName = b.Book.Name,
                        BookPrice = b.Book.Price.ToString("F2"),
                    })
                    .ToList()
                })
                .ToArray()
                .OrderByDescending(x => x.Books.Count)
                .ThenBy(x => x.AuthorName)
                .ToArray();

            var json = JsonConvert.SerializeObject(authors, Newtonsoft.Json.Formatting.Indented);

            return json;
        }

        public static string ExportOldestBooks(BookShopContext context, DateTime date)
        {
            var sb = new StringBuilder();

            var books = context.Books
                .Where(x => x.Genre == Genre.Science &&
                x.PublishedOn < date)
                .ToArray()
                .OrderByDescending(x => x.Pages)
                .ThenByDescending(x => x.PublishedOn)
                .Select(b => new BookExportModel
                {
                    Pages = b.Pages,
                    Name = b.Name,
                    Date = b.PublishedOn.ToString("d", CultureInfo.InvariantCulture),
                })
                .Take(10)
                .ToArray();

            XmlSerializer xmlSerializer = new XmlSerializer(typeof(BookExportModel[]), new XmlRootAttribute("Books"));
            XmlSerializerNamespaces namespaces = new XmlSerializerNamespaces();
            namespaces.Add(string.Empty, string.Empty);

            using (StringWriter stringWriter = new StringWriter(sb))
            {
                xmlSerializer.Serialize(stringWriter, books, namespaces);
            }

            return sb.ToString().TrimEnd();
        }
    }
}