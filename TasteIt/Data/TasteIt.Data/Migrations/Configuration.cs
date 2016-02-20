namespace TasteIt.Data.Migrations
{
    using System.Data.Entity.Migrations;
    using System.Linq;
    using Microsoft.AspNet.Identity;
    using Microsoft.AspNet.Identity.EntityFramework;
    using Models;

    public sealed class Configuration : DbMigrationsConfiguration<TasteItDbContext>
    {
        public Configuration()
        {
            this.AutomaticMigrationsEnabled = true;
            this.AutomaticMigrationDataLossAllowed = true;
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

            seed.Categories.ForEach(x => context.Categories.Add(x));

            seed.Articles.ForEach(x => context.Articles.Add(x));

            context.SaveChanges();

            const string AdministratorUserName = "admin@admin.com";
            const string AdministratorPassword = AdministratorUserName;
            const string AdministratorRoleName = "Administrator";

            if (!context.Roles.Any())
            {
                // Create admin role
                var roleStore = new RoleStore<IdentityRole>(context);
                var roleManager = new RoleManager<IdentityRole>(roleStore);
                var role = new IdentityRole { Name = AdministratorRoleName };
                roleManager.Create(role);

                // Create admin user
                var userStore = new UserStore<User>(context);
                var userManager = new UserManager<User>(userStore);
                var admin = new User
                {
                    FirstName = "Admin",
                    LastName = "Admin",
                    UserName = AdministratorUserName,
                    Email = AdministratorUserName,
                    PasswordHash = AdministratorPassword,
                };
                userManager.Create(admin, AdministratorPassword);

                // Assign user to admin role
                userManager.AddToRole(admin.Id, AdministratorRoleName);
                context.SaveChanges();
            }
        }
    }
}
