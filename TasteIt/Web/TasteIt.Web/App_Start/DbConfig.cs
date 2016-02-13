namespace TasteIt.Web
{
    using Data;
    using Data.Migrations;
    using System.Data.Entity;

    public class DbConfig
    {
        public static void Initialize()
        {
           Database.SetInitializer(new MigrateDatabaseToLatestVersion<TasteItDbContext, Configuration>());
           TasteItDbContext.Create().Database.Initialize(true);
        }
    }
}