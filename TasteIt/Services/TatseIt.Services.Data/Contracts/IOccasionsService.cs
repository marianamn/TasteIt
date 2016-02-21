namespace TatseIt.Services.Data.Contracts
{
    using System.Linq;
    using TasteIt.Data.Models;

    public interface IOccasionsService
    {
        IQueryable<Occasion> GetAll();
    }
}
