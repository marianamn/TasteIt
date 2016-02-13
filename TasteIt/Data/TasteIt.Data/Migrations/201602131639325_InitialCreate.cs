namespace TasteIt.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Comments",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Content = c.String(nullable: false, maxLength: 500),
                        AuthorId = c.String(maxLength: 128),
                        RecipeId = c.Int(nullable: false),
                        CreatedOn = c.DateTime(nullable: false),
                        ModifiedOn = c.DateTime(),
                        IsDeleted = c.Boolean(nullable: false),
                        DeletedOn = c.DateTime(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.AspNetUsers", t => t.AuthorId)
                .ForeignKey("dbo.Recipes", t => t.RecipeId, cascadeDelete: true)
                .Index(t => t.AuthorId)
                .Index(t => t.RecipeId)
                .Index(t => t.IsDeleted);
            
            AddColumn("dbo.Articles", "ModifiedOn", c => c.DateTime());
            AddColumn("dbo.Articles", "IsDeleted", c => c.Boolean(nullable: false));
            AddColumn("dbo.Articles", "DeletedOn", c => c.DateTime());
            AddColumn("dbo.Categories", "CreatedOn", c => c.DateTime(nullable: false));
            AddColumn("dbo.Categories", "ModifiedOn", c => c.DateTime());
            AddColumn("dbo.Categories", "IsDeleted", c => c.Boolean(nullable: false));
            AddColumn("dbo.Categories", "DeletedOn", c => c.DateTime());
            AddColumn("dbo.Ingredients", "CreatedOn", c => c.DateTime(nullable: false));
            AddColumn("dbo.Ingredients", "ModifiedOn", c => c.DateTime());
            AddColumn("dbo.Ingredients", "IsDeleted", c => c.Boolean(nullable: false));
            AddColumn("dbo.Ingredients", "DeletedOn", c => c.DateTime());
            AddColumn("dbo.Recipes", "ModifiedOn", c => c.DateTime());
            AddColumn("dbo.Recipes", "IsDeleted", c => c.Boolean(nullable: false));
            AddColumn("dbo.Recipes", "DeletedOn", c => c.DateTime());
            AddColumn("dbo.Likes", "CreatedOn", c => c.DateTime(nullable: false));
            AddColumn("dbo.Likes", "ModifiedOn", c => c.DateTime());
            AddColumn("dbo.Likes", "IsDeleted", c => c.Boolean(nullable: false));
            AddColumn("dbo.Likes", "DeletedOn", c => c.DateTime());
            AddColumn("dbo.Occasions", "CreatedOn", c => c.DateTime(nullable: false));
            AddColumn("dbo.Occasions", "ModifiedOn", c => c.DateTime());
            AddColumn("dbo.Occasions", "IsDeleted", c => c.Boolean(nullable: false));
            AddColumn("dbo.Occasions", "DeletedOn", c => c.DateTime());
            CreateIndex("dbo.Articles", "IsDeleted");
            CreateIndex("dbo.Categories", "IsDeleted");
            CreateIndex("dbo.Recipes", "IsDeleted");
            CreateIndex("dbo.Ingredients", "IsDeleted");
            CreateIndex("dbo.Likes", "IsDeleted");
            CreateIndex("dbo.Occasions", "IsDeleted");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Comments", "RecipeId", "dbo.Recipes");
            DropForeignKey("dbo.Comments", "AuthorId", "dbo.AspNetUsers");
            DropIndex("dbo.Occasions", new[] { "IsDeleted" });
            DropIndex("dbo.Likes", new[] { "IsDeleted" });
            DropIndex("dbo.Ingredients", new[] { "IsDeleted" });
            DropIndex("dbo.Recipes", new[] { "IsDeleted" });
            DropIndex("dbo.Comments", new[] { "IsDeleted" });
            DropIndex("dbo.Comments", new[] { "RecipeId" });
            DropIndex("dbo.Comments", new[] { "AuthorId" });
            DropIndex("dbo.Categories", new[] { "IsDeleted" });
            DropIndex("dbo.Articles", new[] { "IsDeleted" });
            DropColumn("dbo.Occasions", "DeletedOn");
            DropColumn("dbo.Occasions", "IsDeleted");
            DropColumn("dbo.Occasions", "ModifiedOn");
            DropColumn("dbo.Occasions", "CreatedOn");
            DropColumn("dbo.Likes", "DeletedOn");
            DropColumn("dbo.Likes", "IsDeleted");
            DropColumn("dbo.Likes", "ModifiedOn");
            DropColumn("dbo.Likes", "CreatedOn");
            DropColumn("dbo.Recipes", "DeletedOn");
            DropColumn("dbo.Recipes", "IsDeleted");
            DropColumn("dbo.Recipes", "ModifiedOn");
            DropColumn("dbo.Ingredients", "DeletedOn");
            DropColumn("dbo.Ingredients", "IsDeleted");
            DropColumn("dbo.Ingredients", "ModifiedOn");
            DropColumn("dbo.Ingredients", "CreatedOn");
            DropColumn("dbo.Categories", "DeletedOn");
            DropColumn("dbo.Categories", "IsDeleted");
            DropColumn("dbo.Categories", "ModifiedOn");
            DropColumn("dbo.Categories", "CreatedOn");
            DropColumn("dbo.Articles", "DeletedOn");
            DropColumn("dbo.Articles", "IsDeleted");
            DropColumn("dbo.Articles", "ModifiedOn");
            DropTable("dbo.Comments");
        }
    }
}
