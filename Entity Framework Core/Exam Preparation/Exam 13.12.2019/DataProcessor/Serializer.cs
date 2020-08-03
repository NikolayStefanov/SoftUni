namespace BookShop.DataProcessor
{
    using System;
    using System.Globalization;
    using System.IO;
    using System.Linq;
    using System.Text;
    using System.Xml;
    using System.Xml.Serialization;
    using BookShop.DataProcessor.ExportDto;
    using Data;
    using Newtonsoft.Json;
    using ProductShop.XMLHelper;
    using Formatting = Newtonsoft.Json.Formatting;

    public class Serializer
    {
        public static string ExportMostCraziestAuthors(BookShopContext context)
        {
            var targetAuthors = context.Authors
                .Select(x => new
                {
                    AuthorName = $"{x.FirstName} {x.LastName}",
                    Books = x.AuthorsBooks
                    .OrderByDescending(b => b.Book.Price)
                    .Select(b => new
                    {
                        BookName = b.Book.Name,
                        BookPrice = b.Book.Price.ToString("F2")
                    })
                })
                .ToList()
                .OrderByDescending(x => x.Books.Count())
                .ThenBy(x => x.AuthorName)
                .ToList();
            var jsonFile = JsonConvert.SerializeObject(targetAuthors,Formatting.Indented);
            return jsonFile;
        }

        public static string ExportOldestBooks(BookShopContext context, DateTime date)
        {
            var targetBooks = context.Books
                .AsEnumerable()
                .Where(x => x.PublishedOn < date && x.Genre.ToString().ToLower() == "science")
                .Select(x => new ExportBookDTO
                {
                    Pages = x.Pages,
                    Name = x.Name,
                    Date = x.PublishedOn.ToString("MM/dd/yyyy")
                })
                .OrderByDescending(x => x.Pages)
                .ThenByDescending(x => DateTime.Parse(x.Date))
                .Take(10)
                .ToList();
            var resultXml = XmlConverter.Serialize(targetBooks, "Books");
            return resultXml;
        }
    }
}