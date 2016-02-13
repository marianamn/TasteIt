namespace TasteIt.Data.Models
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using Common.Models;

    public class Category : BaseModel<int>
    {
        private ICollection<Article> articles;

        public Category()
        {
            this.articles = new HashSet<Article>();
        }

        [Required]
        [Index(IsUnique = true)]
        [StringLength(100, ErrorMessage = "The {0} must be at least {2} characters long.", MinimumLength = 5)]
        public string Name { get; set; }

        public virtual ICollection<Article> Articles
        {
            get { return this.articles; }
            set { this.articles = value; }
        }
    }
}
