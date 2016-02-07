namespace TasteIt.Data
{
    using Microsoft.AspNet.Identity.EntityFramework;
    using Models;


    public class TasteItDbContext : IdentityDbContext<User>
    {
        public TasteItDbContext()
            : base("DefaultConnection", throwIfV1Schema: false)
        {
        }

        public static TasteItDbContext Create()
        {
            return new TasteItDbContext();
        }
    }
}
