namespace TasteIt.Web.Models.Ingredient
{
    using System.Collections.Generic;
    using System.Linq;

    public class AlphabeticalPagingViewModel
    {
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
        
        public IEnumerable<IngredientViewModel> Ingredients { get; set; }
    }
}