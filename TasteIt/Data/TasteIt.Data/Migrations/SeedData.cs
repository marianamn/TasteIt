namespace TasteIt.Data.Migrations
{
    using Models;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    public class SeedData
    {
        public List<Occasion> Occasions;

        public List<Recipe> Recipes;

        public List<Ingredient> Ingredients;

        public List<Like> Likes;

        public List<Category> Categories;

        public List<Article> Article;

        public List<User> Users;

        public User Author { get; set; }
    }
}
