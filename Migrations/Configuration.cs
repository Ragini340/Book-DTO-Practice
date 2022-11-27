namespace Book.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;
    using Book.Models;

    internal sealed class Configuration : DbMigrationsConfiguration<Book.Models.BookContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
            //ContextKey = "Book.Models.BookContext";
        }

        protected override void Seed(Book.Models.BookContext context)
        {
            context.Authors.AddOrUpdate(x => x.Id,
                   new Author() { Id = 1, Name = "BalaGuru Swamy" },
                   new Author() { Id = 2, Name = "S Chand" },
                   new Author() { Id = 3, Name = "R.D. Sharma" }
                   );

            context.Books.AddOrUpdate(x => x.Id,
                new BookModel()
                {
                    Id = 1,
                    Title = "C in Depth",
                    Year = 2000,
                    AuthorId = 1,
                    Price = 700,
                    Genre = "Technical"
                },
                new BookModel()
                {
                    Id = 2,
                    Title = "Science",
                    Year = 2015,
                    AuthorId = 1,
                    Price = 400,
                    Genre = "Class 9th Science"
                },
                new BookModel()
                {
                    Id = 3,
                    Title = "Mathematics Class 12",
                    Year = 2018,
                    AuthorId = 2,
                    Price = 750,
                    Genre = "Dhanpat Rai Publications"
                },
                new BookModel()
                {
                    Id = 4,
                    Title = "Mathematics Class 11",
                    Year = 2017,
                    AuthorId = 3,
                    Price = 8.95M,
                    Genre = "Dhanpat Rai Publications"
                });
        }
    }
}