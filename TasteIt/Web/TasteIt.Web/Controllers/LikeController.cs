namespace TasteIt.Web.Controllers
{
    using System.Linq;
    using System.Web.Mvc;
    using Microsoft.AspNet.Identity;
    using TasteIt.Data.Models;
    using TasteIt.Data.Repositories;

    [Authorize]
    public class LikesController : BaseController
    {
        private readonly IDbRepository<Like> likes;

        public LikesController(IDbRepository<Like> likes)
        {
            this.likes = likes;
        }

        [HttpPost]
        public ActionResult Like(int recipeId, int likeType)
        {
            if (likeType > 1)
            {
                likeType = 1;
            }

            if (likeType < -1)
            {
                likeType = -1;
            }

            var userId = this.User.Identity.GetUserId();
            var like = this.likes.All().FirstOrDefault(x => x.AuthorId == userId && x.RecipeId == recipeId);
            if (like == null)
            {
                like = new Like
                {
                    AuthorId = userId,
                    RecipeId = recipeId,
                    Value = (LikeType)likeType
                };
                this.likes.Add(like);
            }
            else
            {
                if (like.Value != (LikeType)likeType)
                {
                    like.Value = LikeType.Neutral;
                }
                else if (like.Value == LikeType.Neutral)
                {
                    like.Value = (LikeType)likeType;
                }
            }

            this.likes.SaveChanges();
            var recipesVotes = this.likes.All()
                .Where(x => x.RecipeId == recipeId)
                .Sum(x => (int)x.Value);

            return this.Json(new { Count = recipesVotes });
        }
    }
}