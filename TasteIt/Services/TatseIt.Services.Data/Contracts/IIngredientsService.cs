namespace TatseIt.Services.Data.Contracts
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using TasteIt.Data.Models;

    public interface IIngredientsService
    {
        IQueryable<Ingredient> GetAll();

        IQueryable<Ingredient> GetRandomIngredients(int count);

        Ingredient GetById(string id);

        IQueryable<Ingredient> GetIngredientsWithCommonLetter(string letter);

        List<string> GetFirstLetters();
    }
}
