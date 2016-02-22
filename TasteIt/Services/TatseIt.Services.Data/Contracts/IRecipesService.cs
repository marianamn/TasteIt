namespace TatseIt.Services.Data.Contracts
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using TasteIt.Data.Models;

    public interface IRecipesService
    {
        IQueryable<Recipe> GetAll();

        IQueryable<Recipe> GetMostLikedRecipes(int count);

        Recipe GetById(string id);

        IQueryable<Recipe> GetBySeason(string season);

        IQueryable<Recipe> GetByOccasion(string occasion);
    }
}
