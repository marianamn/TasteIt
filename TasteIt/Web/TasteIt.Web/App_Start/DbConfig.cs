namespace TasteIt.Web
{
    using System.Data.Entity;
    using Data;
    using Data.Migrations;

    public class DbConfig
    {
        public static void Initialize()
        {
           Database.SetInitializer(new MigrateDatabaseToLatestVersion<TasteItDbContext, Configuration>());
           TasteItDbContext.Create().Database.Initialize(true);
        }
    }
}