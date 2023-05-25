using System;
using System.Data;
using System.Diagnostics;
using System.Linq;
using System.Security.Cryptography;
using System.Security.Policy;

namespace BookShop
{
    internal class Program
    {
       
        static void Main(string[] args)
        {
            using (BookShop_Connection db = new BookShop_Connection())
            {
                //Show all Themes
                Console.WriteLine("--Show All Themes--");

                var themes = from t in db.Themes
                             select t;
                foreach (var theme in themes)
                {
                    Console.WriteLine("{0}---{1}", theme.Id, theme.Name);
                }
                Console.WriteLine("---------------------------------\n");

                //Show all books with more than 500 pages but less than 650
                Console.WriteLine("--Show all books with more than 500 pages but less than 650--");
                var books = from b in db.Books
                            where b.Pages > 500 & b.Pages < 650
                            select b;
                foreach(var book in books)
                {
                    Console.WriteLine("{0}---{1}", book.Name, book.Pages);
                }
                Console.WriteLine("---------------------------------\n");

                //Show all books in which the first letter of the title is either "A" or "Z", while displaying them in alphabetical order.
                Console.WriteLine("--Show all books in which the first letter of the title is either 'A' or 'Z', while displaying them in alphabetical order.--");
                var bookLetters = from b in db.Books
                                  where b.Name.StartsWith("A") || b.Name.StartsWith("Z")
                                  select b;
                foreach(var bookLetter in bookLetters)
                {
                    Console.WriteLine("{0}---{1}---{2}---{3}---{4}---{5}---{6}", bookLetter.Id, bookLetter.Name, bookLetter.Pages, bookLetter.Price, bookLetter.PublishDate, bookLetter.AuthorId, bookLetter.ThemeId);
                }
                Console.WriteLine("---------------------------------\n");

                //Show all books whose titles consist of 5 letters.
                Console.WriteLine("--Show all books whose titles consist of 5 letters.--");
                var bookContains = from b in db.Books
                                   where b.Name.Length == 11
                                   select b;
                foreach(var bookContain in bookContains)
                {
                    Console.WriteLine("{0}---{1}---{2}---{3}---{4}---{5}---{6}", bookContain.Id, bookContain.Name, bookContain.Pages, bookContain.Price, bookContain.PublishDate, bookContain.AuthorId, bookContain.ThemeId);
                }
                Console.WriteLine("---------------------------------\n");

                //Show all countries in alphabetical order.
                Console.WriteLine("--Show all countries in alphabetical order.--");
                var countries = from c in db.Countries
                                orderby c.Name
                                select c;
                foreach(var country in countries)
                {
                    Console.WriteLine("{0}---{1}", country.Id, country.Name);
                }
                Console.WriteLine("---------------------------------\n");

                //Show the number of unique book titles.
                Console.WriteLine("--Show the number of unique book titles.--");
                var bookThemeCount = (from b in db.Books
                                 select b).Count();
                Console.WriteLine(bookThemeCount);
                Console.WriteLine("---------------------------------\n");

                //Show all themes for which there is at least one book.
                Console.WriteLine("--Show all themes for which there is at least one book.--");
                var bookThemes = from t in db.Themes
                                 join b in db.Books on t.Id equals b.ThemeId
                                 where b.Id != null
                                 select t;
                foreach(var bookTheme in bookThemes)
                {
                    Console.WriteLine(bookTheme.Name);
                }
                Console.WriteLine("---------------------------------\n");

                //Show all the books with the highest price.
                Console.WriteLine("--Show all the books with the highest price.--");
                var bookPrices = from b in db.Books
                                 group b by b.Name into g
                                 select new
                                 {
                                     BookName = g.Key,
                                     MostExpensive = g.Max(a => a.Price)
                                 };
                foreach (var bookPrice in bookPrices)
                {
                    Console.WriteLine(bookPrice);
                }
            }
            Console.ReadKey();
        }
    }
}
