using ComicBookGalleryModel.Models;
using System;
using System.Data.Entity;
using System.Diagnostics;
using System.Linq;

namespace ComicBookGalleryModel
{

    class Program
    {
        static void Main(string[] args)
        {
            using (var context = new Context())
            {

                context.Database.Log = (message) => Debug.WriteLine(message);

                var comicBooks = context.ComicBooks

                    .ToList();

                foreach (var comicBook in comicBooks)
                {
                    if (comicBook.Series == null)
                    {
                        context.Entry(comicBook)
                               .Reference(cb => cb.Series)
                               .Load();
                    }

                    var artistRoleNames = comicBook.Artists.Select(a => $"{a.Artist.Name} - {a.Role.Name}").ToList();
                    var artistRolesDisplayText = string.Join(", ", artistRoleNames);
                    Console.WriteLine(comicBook.DisplayText);
                    Console.WriteLine(artistRolesDisplayText);
                }

                #region PreLoading-Related-Entities
                ////var comicBooks = context.ComicBooks
                ////    .Include(cb => cb.Series)
                ////    .OrderByDescending(cb => cb.IssueNumber)
                ////    .ThenBy(cb => cb.PublishedOn)
                ////    //.Where(cb => cb.IssueNumber == 1 || cb.Series.Title == "The Amazing Spider-Man")
                ////    .Where(cb => cb.Series.Title.Contains("man"))
                ////    .ToList();

                //var comicBooksQuery = context.ComicBooks
                //    .Include(cb => cb.Series)
                //    .OrderByDescending(cb => cb.IssueNumber);

                //var comicBooks = comicBooksQuery.ToList();

                //var comicBooks2 = comicBooksQuery.Where(cb => cb.AverageRating < 7).ToList();

                //foreach (var comicBook in comicBooks)
                //{
                //    Console.WriteLine(comicBook.DisplayText);
                //}



                ////var comicBooksQuery = from cb in context.ComicBooks select cb;
                ////var comicBooks = comicBooksQuery.ToList();

                //Console.WriteLine();
                //Console.WriteLine();
                //Console.WriteLine("# of comic books: {0}", comicBooks.Count);


                //foreach (var comicBook in comicBooks2)
                //{
                //    Console.WriteLine(comicBook.DisplayText);
                //}

                //Console.WriteLine();
                //Console.WriteLine("# of comic books: {0}", comicBooks2.Count);


                #endregion
                #region preListQuery
                //var comicBooks = context.ComicBooks
                //    .Include(cb => cb.Series)
                //    .Include(cb => cb.Artists.Select(a=> a.Artist))
                //    .Include(cb => cb.Artists.Select(a => a.Role))
                //    .ToList();

                //foreach (var comicBook in comicBooks)
                //{
                //    var artistRoleNames = comicBook.Artists
                //        .Select(a => $"{a.Artist.Name} - {a.Role.Name}").ToList();
                //    var artistRolesDisplayText = string.Join(", ", artistRoleNames);
                //    Console.WriteLine(comicBook.DisplayText);
                //    Console.WriteLine(artistRolesDisplayText);
                //}

                #endregion
                Console.ReadLine();
            }

        }
    }
}
