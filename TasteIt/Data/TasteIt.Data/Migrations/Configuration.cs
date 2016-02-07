namespace TasteIt.Data.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    public sealed class Configuration : DbMigrationsConfiguration<TasteItDbContext>
    {
        public Configuration()
        {
            this.AutomaticMigrationsEnabled = true;
            this.AutomaticMigrationDataLossAllowed = true;
        }

        protected override void Seed(TasteItDbContext context)
        {
            if (context.Recipes.Any() || context.Articles.Any())
            {
                return;
            }


        }
    }
}
