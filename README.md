# TasteIt
ASP.Net MVC Application

#### Description:
TasteIt is an informational application, in witch the user can learn interesting information about food products, read articles related to food and also find appropriate recipe.

##### Roles:
* Not Login user - has access to Articles, Recipes and Ingredients menu
* Login user - can like and dislike certain recipe; can give comment to recipe, can Create Ingredient and Recipe. Login user has access to his personal profile, which he can edit and also can see/edit/delete all comments, recipes and ingredients added by him
* Administrator - has access to Manage App menu through witch he can manage Articles, Ingredients, Recipes, Comments and Users (create/edit/delete)

##### Home page:
Has four modules:
* pictuere slideshow - external library uesed - bxslider.js (more details on https://github.com/stevenwanderski/bxslider-4; Cofiguration options - http://bxslider.com/options)
* Random 3 ingredients with link to their Details page
* Top 3 most liked recipes with link to their Details page
* Top 3 newes Articles with link to their Details page

##### About page:
Shows basic information of the application.

##### Contact page:
Shows contacts information and Google map to phisical location of the company TasteIt.

#### Ingredients page:
Shows alphabetical paging about ingredients, using their first letter. If the user click on respective letter, all ingredients starting with it are shown. If no such exists letter button is not active.through this page user can create new ingredient and respective message is shown in success case. 
When clicking on ingredient the User is directed to Ingredient details page with additional information about it.


#### Article page:
Shows all articles list with paging - 10 per page.When clicking on article the User is redirected to Article details page with additional information about it. User can click on Related articles button which direct him to All other food articles from the same category.

#### Recipe page:
Has four modules:
* Create new recipe
* Chose recipe by season - select all recipes in respective season
* Chose recipe by occasion - select all recipes in respective occasion
* List all recipes

#### Manage app section (for Adninistrator role):
Manage app in Grid views.

#### GitHub repository:
https://github.com/marianamn/TasteIt
