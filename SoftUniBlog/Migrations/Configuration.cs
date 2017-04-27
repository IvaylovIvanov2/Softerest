namespace SoftUniBlog.Migrations
{
    using Models;
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    public class Configuration : DbMigrationsConfiguration<SoftUniBlog.Models.BlogDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
            AutomaticMigrationDataLossAllowed = false;
        }

        protected override void Seed(BlogDbContext context)
        {
            if(context.Articles.Any())
            {
                return;
            }

            var user = context.Users.FirstOrDefault();

            if(user==null)
            {
                return;
            }

            context.Articles.Add(new Article
            {
                Title = "Welcome",
                Content = "Welcome to Softerest. On this page you can post articles about any topic you find interesting.",
                ImageUrl = "http://www.really-learn-english.com/image-files/letter-s.png",
                AuthorId = user.Id,
                Author = user
            });
        }
    }
}
