namespace BookShop
{
    using BookShop.Models.Enums;
    using Data;
    using Initializer;
    using System;
    using System.Globalization;
    using System.Linq;
    using System.Text;

    public class StartUp
    {
        public static void Main()
        {
            var db = new BookShopContext();
            // DbInitializer.ResetDatabase(db);

            //EXERCISE 1 - Age Restriction
            //var inputEx1 = Console.ReadLine();
            //var resultEx1 = GetBooksByAgeRestriction(db,inputEx1);
            //Console.WriteLine(resultEx1);

            //EXERCISE 2 - Golden Book
            //var resultEx2 = GetGoldenBooks(db);
            //Console.WriteLine(resultEx2);

            //EXERCISE 3 - Books by Price
            //var resultEx3 = GetBooksByPrice(db);
            //Console.WriteLine(resultEx3);

            //EXERCISE 4 - Not Released In
            //var targetYear = int.Parse(Console.ReadLine());
            //var resultEx4 = GetBooksNotReleasedIn(db, targetYear);
            //Console.WriteLine(resultEx4);

            //EXERCISE 5 - Book Titles by Category
            //var inputEx5 = Console.ReadLine();
            //var resultEx5 = GetBooksByCategory(db, inputEx5);
            //Console.WriteLine(resultEx5);

            //EXERCISE 6 - Released Before Date
            //var dateEx6 = Console.ReadLine();
            //var resultEx6 = GetBooksReleasedBefore(db, dateEx6);
            //Console.WriteLine(resultEx6);

            //EXERCISE 7 - Author Search
            // var inputEx7 = Console.ReadLine();
            // var resultEx7 = GetAuthorNamesEndingIn(db, inputEx7);
            // Console.WriteLine(resultEx7);

            //EXERCISE 8 - Book Search
            //var inputEx8 = Console.ReadLine();
            //var resultEx8 = GetBookTitlesContaining(db, inputEx8);
            //Console.WriteLine(resultEx8);

            //EXERCISE 9 - Book Search by Author
            //var inputEx9 = Console.ReadLine();
            //var resultEx9 = GetBooksByAuthor(db, inputEx9);
            //Console.WriteLine(resultEx9);

            //EXERCISE 10 - Count Books
            //var lengthCheck = int.Parse(Console.ReadLine());
            //var resultEx10 = CountBooks(db, lengthCheck);
            //Console.WriteLine(resultEx10);

            //EXERCISE 11 - Total Book Copies
            //var resultEx11 = CountCopiesByAuthor(db);
            //Console.WriteLine(resultEx11);

            //EXERCISE 12 - Profit by Category
            //var resultEx12 = GetTotalProfitByCategory(db);
            //Console.WriteLine(resultEx12);

            //EXERCISE 13 - Most Recent Books
            //var resultEx13 = GetMostRecentBooks(db);
            //Console.WriteLine(resultEx13);

            //EXERCISE 14 - Increase Prices
            //IncreasePrices(db);

            //EXERCISE 15 - Remove Books
            //var resultEx15 = RemoveBooks(db);
            //Console.WriteLine(resultEx15);
        }

        //EXERCISE 1 - Age Restriction
        public static string GetBooksByAgeRestriction(BookShopContext context, string command)
        {
            var commandToLower = command.ToLower();
            var bookTitles = context.Books
                .Where(x => x.AgeRestriction.ToString().ToLower() == commandToLower)
                .OrderBy(x => x.Title)
                .Select(x => x.Title)
                .ToList();

            var resultStrBulder = new StringBuilder();
            foreach (var title in bookTitles)
            {
                resultStrBulder.AppendLine(title);
            }
            return resultStrBulder.ToString().TrimEnd();
        }

        //EXERCISE 2 - Golden Book
        public static string GetGoldenBooks(BookShopContext context)
        {
            var goldenBooks = context.Books
                .Where(b => b.EditionType == EditionType.Gold && b.Copies < 5000)
                .OrderBy(x => x.BookId)
                .Select(x => new { x.Title })
                .ToList();
            var result = new StringBuilder();
            foreach (var book in goldenBooks)
            {
                result.AppendLine(book.Title);
            }
            return result.ToString().TrimEnd();
        }

        //EXERCISE 3 - Books by Price
        public static string GetBooksByPrice(BookShopContext context)
        {
            var targetBooks = context.Books
                .Where(b => b.Price > 40)
                .Select(b => new { b.Title, b.Price })
                .OrderByDescending(x => x.Price)
                .ToList();
            var resultString = new StringBuilder();
            foreach (var book in targetBooks)
            {
                resultString.AppendLine($"{book.Title} - ${book.Price:f2}");
            }
            return resultString.ToString().TrimEnd();
        }

        //EXERCISE 4 - Not Released In
        public static string GetBooksNotReleasedIn(BookShopContext context, int year)
        {
            var targetBooks = context.Books
                .Where(b => b.ReleaseDate.Value.Year != year)
                .OrderBy(b => b.BookId)
                .Select(b => new { b.Title })
                .ToList();
            var resultString = new StringBuilder();
            foreach (var book in targetBooks)
            {
                resultString.AppendLine(book.Title);
            }
            return resultString.ToString().TrimEnd();
        }

        //EXERCISE 5 - Book Titles by Category
        public static string GetBooksByCategory(BookShopContext context, string input)
        {
            var categories = input.Split(' ', StringSplitOptions.RemoveEmptyEntries)
                                  .Select(x => x.ToLower())
                                  .ToList();

            var targetBooks = context.BooksCategories
                .Where(b => categories.Contains(b.Category.Name.ToLower()))
                .OrderBy(x => x.Book.Title)
                .Select(x => new { x.Book.Title })
                .ToList();
            var result = new StringBuilder();
            foreach (var book in targetBooks)
            {
                result.AppendLine(book.Title);
            }
            return result.ToString().TrimEnd();
        }

        //EXERCISE 6 - Released Before Date
        public static string GetBooksReleasedBefore(BookShopContext context, string date)
        {
            var newDate = DateTime.ParseExact(date, "dd-MM-yyyy", null);

            var targetBooks = context.Books
                .Where(b => b.ReleaseDate < newDate)
                .OrderByDescending(b => b.ReleaseDate)
                .Select(x => new { x.Title, x.EditionType, x.Price })
                .ToList();

            var resultStr = new StringBuilder();
            foreach (var book in targetBooks)
            {
                resultStr.AppendLine($"{book.Title} - {book.EditionType} - ${book.Price:f2}");
            }
            return resultStr.ToString().TrimEnd();
        }

        //EXERCISE 7 - Author Search
        public static string GetAuthorNamesEndingIn(BookShopContext context, string input)
        {
            var targetAuthors = context.Authors
                .Where(a => a.FirstName.EndsWith(input.ToLower()))
                .Select(x => new { Name = x.FirstName + " " + x.LastName })
                .OrderBy(a => a.Name)
                .ToList();

            var resultStr = new StringBuilder();
            foreach (var author in targetAuthors)
            {
                resultStr.AppendLine(author.Name);
            }
            return resultStr.ToString().TrimEnd();
        }

        //EXERCISE 8 - Book Search
        public static string GetBookTitlesContaining(BookShopContext context, string input)
        {
            var targetBookTitles = context.Books
                .Where(b => b.Title.ToLower().Contains(input.ToLower()))
                .Select(x => x.Title)
                .OrderBy(x => x)
                .ToList();
            var resultStr = new StringBuilder();
            foreach (var title in targetBookTitles)
            {
                resultStr.AppendLine(title);
            }
            return resultStr.ToString().TrimEnd();
        }

        //EXERCISE 9 - Book Search by Author
        public static string GetBooksByAuthor(BookShopContext context, string input)
        {
            var targetBooksAndAuthors = context.Books
                .Select(x => new
                {
                    BookId = x.BookId,
                    BookName = x.Title,
                    AuthorFirstName = x.Author.FirstName,
                    AuthorLastName = x.Author.LastName
                })
                .Where(x => x.AuthorLastName.ToLower().StartsWith(input.ToLower()))
                .OrderBy(x => x.BookId)
                .ToList();
            var resultStr = new StringBuilder();
            foreach (var book in targetBooksAndAuthors)
            {
                resultStr.AppendLine($"{book.BookName} ({book.AuthorFirstName} {book.AuthorLastName})");
            }
            return resultStr.ToString().TrimEnd();
        }

        //EXERCISE 10 - Count Books
        public static int CountBooks(BookShopContext context, int lengthCheck)
        {
            var booksWithLongerTitleThanInput = context.Books
                .Where(x => x.Title.Length > lengthCheck)
                .ToList().Count;
            return booksWithLongerTitleThanInput;
        }

        //EXERCISE 11 - Total Book Copies
        public static string CountCopiesByAuthor(BookShopContext context)
        {
            var targetAuthorAndCopies = context.Authors
                .Select(x => new
                {
                    AuthorName = x.FirstName + " " + x.LastName,
                    CountOfCopies = x.Books.Sum(b => b.Copies)
                })
                .OrderByDescending(x => x.CountOfCopies)
                .ToList();
            var resultStr = new StringBuilder();
            foreach (var item in targetAuthorAndCopies)
            {
                resultStr.AppendLine($"{item.AuthorName} - {item.CountOfCopies}");
            }
            return resultStr.ToString().TrimEnd();
        }

        //EXERCISE 12 - Profit by Category
        public static string GetTotalProfitByCategory(BookShopContext context)
        {
            var result = context.Categories
                .Select(x => new
                {
                    x.Name,
                    TotalProfit = x.CategoryBooks.Sum(b => b.Book.Price * b.Book.Copies)
                })
                .OrderByDescending(x => x.TotalProfit)
                .ThenBy(x => x.Name)
                .ToList();

            var resultStr = new StringBuilder();
            foreach (var item in result)
            {
                resultStr.AppendLine($"{item.Name} ${item.TotalProfit:F2}");
            }
            return resultStr.ToString().TrimEnd();
        }

        //EXERCISE 13 - Most Recent Books
        public static string GetMostRecentBooks(BookShopContext context)
        {
            var targetBooks = context.Categories
                .Select(x => new
                {
                    x.Name,
                    RecentBooks = x.CategoryBooks
                        .Where(b => b.Book.ReleaseDate != null)
                        .OrderByDescending(b => b.Book.ReleaseDate)
                        .Select(b => new { BookName = b.Book.Title, RealeaseYear = b.Book.ReleaseDate.Value.Year })
                        .Take(3)
                })
                .OrderBy(x => x.Name)
                .ToList();
            var resultStr = new StringBuilder();
            foreach (var category in targetBooks)
            {
                resultStr.AppendLine($"--{category.Name}");
                foreach (var book in category.RecentBooks)
                {
                    resultStr.AppendLine($"{book.BookName} ({book.RealeaseYear})");
                }
            }
            return resultStr.ToString().TrimEnd();
        }

        //EXERCISE 14 - Increase Prices
        public static void IncreasePrices(BookShopContext context)
        {
            var targetBooks = context.Books
                .Where(x => x.ReleaseDate.Value.Year < 2010)
                .ToList();
            foreach (var book in targetBooks)
            {
                book.Price += 5;
            }
            context.SaveChanges();
        }

        //EXERCISE 15 - Remove Books
        public static int RemoveBooks(BookShopContext context)
        {
            var targetBooks = context.Books
                .Where(x => x.Copies < 4200)
                .ToList();

            context.RemoveRange(targetBooks);
            context.SaveChanges();

            return targetBooks.Count;
        }
    }
}
