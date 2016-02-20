namespace TasteIt.Web.Models.Ingredient
{
    using Services.Web;
    using Services.Web.Contracts;
    using System.Collections.Generic;
    using System.Linq;
    using TasteIt.Web.Infrastructure.Mapping;
    using AutoMapper;
    using System;

    public class AlphabeticalPagingViewModel : IMapFrom<Data.Models.Ingredient>
    {
        public List<int> Id { get; set; }

        public List<string> IngredientNames { get; set; }

        public List<string> Alphabet
        {
            get
            {
                var alphabet = Enumerable.Range(65, 26).Select(i => ((char)i).ToString()).ToList();
                alphabet.Insert(0, "All");
                return alphabet;
            }
        }

        public List<string> FirstLetters { get; set; }
        
        public string SelectedLetter { get; set; }

        //public string Url
        //{
        //    get
        //    {
        //        IIdentifierProvider identifier = new IdentifierProvider();
        //        return $"/{identifier.EncodeId(this.Id)}";
        //    }
        //}

    }
}