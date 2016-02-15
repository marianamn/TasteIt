namespace TasteIt.Web.Controllers
{
    using Infrastructure.Mapping;
    using Models.Article;
    using Models.Home;
    using Models.Ingredients;
    using Models.Recipe;
    using System.Linq;
    using System.Web.Mvc;
    using TatseIt.Services.Data.Contracts;

    public class HomeController : BaseController
    {
        private readonly IIngredientsService ingredients;
        private readonly IRecipesService recipes;
        private readonly IArticlesService articles;

        public HomeController(IIngredientsService ingredients, IRecipesService recipes, IArticlesService articles)
        {
            this.ingredients = ingredients;
            this.recipes = recipes;
            this.articles = articles;
        }

        public ActionResult Index()
        {
            if (this.User.Identity.IsAuthenticated)
            {
                this.ViewData.Add("Username", this.User.Identity);
            }

            var ingredients = this.ingredients.GetRandomIngredients(3)
                                  .To<IngredientsViewModel>()
                                  .ToList();

            var recipes = this.recipes.GetMostLikedRecipes(3)
                                 .To<RecipeViewModel>()
                                 .ToList();

            var articles = this.articles.GetNewestArticles(3)
                               .To<ArticleViewModel>()
                               .ToList();

            //var categories =
            //    this.Cache.Get(
            //        "categories",
            //        () => this.jokeCategories.GetAll().To<JokeCategoryViewModel>().ToList(),
            //        30 * 60);

            var viewModel = new IndexViewModel
            {
                Ingredients = ingredients,
                Recipes = recipes,
                Articles = articles
            };

            return this.View(viewModel);
        }

        public ActionResult About()
        {
            this.ViewBag.Message = "Your application description page.";

            return this.View();
        }

        public ActionResult Contact()
        {
            this.ViewBag.Message = "Your contact page.";

            return this.View();
        }
    }
}