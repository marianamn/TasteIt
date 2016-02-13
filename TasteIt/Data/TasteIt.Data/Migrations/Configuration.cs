namespace TasteIt.Data.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;
    using Microsoft.AspNet.Identity;
    using Models;

    public sealed class Configuration : DbMigrationsConfiguration<TasteItDbContext>
    {
        public Configuration()
        {
            this.AutomaticMigrationsEnabled = false;
            this.AutomaticMigrationDataLossAllowed = false;
        }

        protected override void Seed(TasteItDbContext context)
        {
            if (context.Recipes.Any() && context.Articles.Any())
            {
                return;
            }

            // Adding some Users
            var passwordHash = new PasswordHasher();
            string password = passwordHash.HashPassword("123456");
            var user = new User()
            {
                FirstName = "Pesho",
                LastName = "Goshev",
                UserName = "pesho@abv.bg",
                Email = "pesho@abv.bg",
                PasswordHash = password,
                ImageURL = "http://trendsnutrition.com/wp-content/uploads/2014/02/eat-more-sandwich.jpg"
            };
            
            if (context.Users.Any())
            {
                return;
            }

            context.Users.Add(user);
            context.SaveChanges();

            var seed = new SeedData(user);
           
            seed.Users.ForEach(x => context.Users.Add(x));

            seed.Occasions.ForEach(x => context.Occasions.Add(x));

            seed.Recipes.ForEach(x => context.Recipes.Add(x));

            seed.Ingredients.ForEach(x => context.Ingredients.Add(x));

            context.SaveChanges();
        }
    }
}
