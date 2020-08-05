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
    using ProductShop.XMLHelper;
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
            var outputResult = new StringBuilder();
            var booksResult = XmlConverter.Deserializer<ImportBooksDTO>(xmlString, "Books");
            var booksToAdd = new List<Book>();

            foreach (var bookDto in booksResult)
            {
                if (!IsValid(bookDto))
                {
                    outputResult.AppendLine(ErrorMessage);
                    continue;
                }
                DateTime publishedOn;

                bool isDateValid = DateTime.TryParseExact(
                                   bookDto.PublishedOn,
                                   "MM/dd/yyyy",
                                   CultureInfo.InvariantCulture,
                                   DateTimeStyles.None,
                                   out publishedOn);
                if (!isDateValid)
                {
                    outputResult.AppendLine(ErrorMessage);
                    continue;
                }

                Book newBook = new Book
                {
                    Name = bookDto.Name,
                    Genre = (Genre)bookDto.Genre,
                    Price = bookDto.Price,
                    Pages = bookDto.Pages,
                    PublishedOn = publishedOn,
                };
                
                booksToAdd.Add(newBook);
                outputResult.AppendLine(String.Format(SuccessfullyImportedBook, newBook.Name, newBook.Price));
            }

            context.Books.AddRange(booksToAdd);
            context.SaveChanges();
            return outputResult.ToString().TrimEnd();
        }

        public static string ImportAuthors(BookShopContext context, string jsonString)
        {
            var authorsDtos = JsonConvert.DeserializeObject<List<ImportAuthorDTO>>(jsonString);

            var authorsList = new List<Author>();
            var resultString = new StringBuilder();

            foreach (var authorDto in authorsDtos)
            {
                if (!IsValid(authorDto))
                {
                    resultString.AppendLine(ErrorMessage);
                    continue;
                }
                if (context.Authors.Any(a=> a.Email == authorDto.Email) || authorsList.Any(a=> a.Email == authorDto.Email))
                {
                    resultString.AppendLine(ErrorMessage);
                    continue;
                }
                var newAuthor = new Author
                {
                    FirstName = authorDto.FirstName,
                    LastName = authorDto.LastName,
                    Email = authorDto.Email,
                    Phone = authorDto.Phone,
                };

                foreach (var book  in authorDto.Books)
                {
                    if (!book.BookId.HasValue)
                    {
                        continue;
                    }
                    Book newBook = context.Books
                        .FirstOrDefault(b => b.Id == book.BookId);
                    if (newBook == null)
                    {
                        continue;
                    }

                    newAuthor.AuthorsBooks.Add(new AuthorBook
                    {
                        Author = newAuthor,
                        Book = newBook
                    });
                }
                if (newAuthor.AuthorsBooks.Count == 0)
                {
                    resultString.AppendLine(ErrorMessage);
                    continue;
                }

                authorsList.Add(newAuthor);
                resultString.AppendLine(string.Format(SuccessfullyImportedAuthor,
                    (newAuthor.FirstName+ " " + newAuthor.LastName),
                    newAuthor.AuthorsBooks.Count));
            }

            context.Authors.AddRange(authorsList);
            context.SaveChanges();
            return resultString.ToString().TrimEnd();
        }

        private static bool IsValid(object dto)
        {
            var validationContext = new ValidationContext(dto);
            var validationResult = new List<ValidationResult>();

            return Validator.TryValidateObject(dto, validationContext, validationResult, true);
        }
    }
}