namespace TasteIt.Data.Migrations
{
    using System;
    using System.Collections.Generic;
    using Microsoft.AspNet.Identity;
    using TasteIt.Data.Models;

    public class SeedData
    {
        private static Random rand = new Random();

        public SeedData(User author)
        {
            this.Author = author;
            User user = author;

            this.Occasions = new List<Occasion>();
            this.Recipes = new List<Recipe>();
            this.Categories = new List<Category>();
            this.Articles = new List<Article>();
            this.Users = new List<User>();

            // Adding Users
            var passwordHash = new PasswordHasher();
            string password = passwordHash.HashPassword("123456");
            this.Users.Add(new User()
            {
                FirstName = "Yana",
                LastName = "Hristova",
                UserName = "yancheto@gmail.com",
                Email = "yancheto@gmail.com",
                PasswordHash = password,
                ImageURL = "http://youngandraw.wpengine.netdna-cdn.com/wp-content/uploads/Eating-Raw-Can-Make-You-Healthier.jpg"
            });
            this.Users.Add(new User()
            {
                FirstName = "John",
                LastName = "Peshev",
                UserName = "john@abv.bg",
                Email = "john@abv.bg",
                PasswordHash = password,
                ImageURL = "https://encrypted-tbn1.gstatic.com/images?q=tbn:ANd9GcSfGp4ah9gQs2SOlorqzJZ927GwqeAgZm4gFX1EAK0C6Cl_lGso"
            });
            this.Users.Add(new User()
            {
                FirstName = "Maria",
                LastName = "jIvanova",
                UserName = "ivanova@gmail.com",
                Email = "john@abv.bg",
                PasswordHash = password
            });

            // Adding Occasions
            this.Occasions.Add(new Occasion { Name = "St.Valentine's Day" });
            this.Occasions.Add(new Occasion { Name = "Easter" });
            this.Occasions.Add(new Occasion { Name = "Christmas" });
            this.Occasions.Add(new Occasion { Name = "Halloween" });
            this.Occasions.Add(new Occasion { Name = "BirthdayParty" });
            this.Occasions.Add(new Occasion { Name = "Healthy diet plans" });
            this.Occasions.Add(new Occasion { Name = "Dinner" });
            this.Occasions.Add(new Occasion { Name = "Lunch" });
            this.Occasions.Add(new Occasion { Name = "Breakfast" });
            this.Occasions.Add(new Occasion { Name = "Wedding" });

            // Adding Recipes
            this.Recipes.Add(new Recipe
            {
                Title = "Coconut chilli chicken",
                Description = "Peel and discard the outer leaves of the lemongrass-they can sometimes be tough. Cut the inner leaves into short lengths and put in the food processor.Peel the ginger, then slice into thin pieces and add to the lemongrass. Chop the chillies, discarding their stems and add to the ginger with the peeled garlic. Roughly chop the stems and half of the leaves of the coriander to add to the food processor, reserving the rest for later.Grate the lime zest into the food processor, reserving the limes for later, then turn the machine on and let it chop everything to a coarse paste.Add a little groundnut oil and scrape the sides down with a spatula if it sticks.Add the fish sauce, soy sauce and the tomatoes and process for a few seconds longer.Warm a further tablespoon of groundnut oil in a deep pan over a moderate to high heat and use it to brown the chicken pieces, turning them so they colour nicely on both sides.Lift the chicken pieces out and pour away anything more than a tablespoon of oil and juices.Add the spice paste and let it fry over a moderate heat for two minutes till fragrant, stirring almost constantly, then return the chicken to the pan. Pour over the coconut milk, stir, cover and leave to simmer over a low heat for 15 - 20 minutes.Meanwhile halve and stone the apricots and leave them to one side.Test the chicken for doneness making certain it’s cooked right the way through, then add the apricots.Leave to simmer for a few minutes, then add the juice of the limes and the reserved coriander leaves.",
                Author = user,
                CreatedOn = DateTime.Now.AddDays(rand.Next(-5, 5)),
                CookingTime = "from 1 hour to 1 and a half hour",
                Season = Season.Autumn,
                Occasion = this.Occasions[6],
                RecipeImage = "https://s-media-cache-ak0.pinimg.com/564x/34/57/97/34579714aa0b76c78a071e031f7102a7.jpg",
                Ingredients = new List<Ingredient>()
                    {
                        new Ingredient()
                        {
                            Name = "lemongrass",
                            Quantity = "3 plump stalks",
                            IngredientDetails = "Although lemon grass is central to Asian cuisine, especially Thai, it works well in Western dishes, too. This mixing of flavours is sometimes called 'fusion'.Lemongrass look a little like fat spring onions, with the same swollen base, but the stalk is woodier, and composed of tightly packed grey-green leaves.The fragrance and flavour is unique - lemony, but sweet -and is quite subtle until the stalk is cut or bashed. The stalks are available freeze - dried, too.",
                            IngredientImage = "http://changinghabits.com.au/blogs/lemongrass.jpg"
                        },
                        new Ingredient()
                        {
                            Name = "ginger",
                            Quantity = "50g / 2oz",
                            IngredientDetails = "Ginger is a fiery root with rough beige skin and hard, juicy, pale yellow flesh. It can be used as a spice, fresh or dried and ground to a powder. The fresh, juicy root has a sweetly pungent taste and a perfume - like scent that makes it suitable for sweet or savoury dishes, whereas the dried ground root is much more fiery.Young ginger can also be preserved in sugar syrup or crystallised and rolled in sugar - in both cases it is then known as stem ginger.Ginger is popular in cuisines throughout Asia and Europe.",
                            IngredientImage = "http://www.herbalremediesadvice.org/images/Ginger-Root-Benefits.jpg"
                        },
                        new Ingredient()
                        {
                            Name = "hot red chillies",
                            Quantity = "2",
                            IngredientDetails = "Chilli peppers are a small, fiery variety of capsicum. They can be green, yellow, orange, red or black. There are more than 200 known varieties and they differ greatly in size, colour and level of hotness.In general, the smaller the chilli, the more potent, but it's worth bearing in mind that individual chillies of the same variety and even from the same plant can contain different levels of capsaicin, the volatile oil that gives chilli its heat. There is an official heat scale for chillies known as The Scoville scale, developed by Wilbur Scoville in 1912. A sweet pepper scores 0 on the scale, Jalapeño and chipotle chillies score anything between 2,500 to 10,000 and habañero and Scotch bonnet score 80,000 to 300,000 plus! Chillies work well in sweet as well as savoury dishes: a little chilli helps to cut through the richness of the chocolate.",
                            IngredientImage = "http://cornishchillicompany.co.uk/wp-content/uploads/2014/09/chillies-1200x800.jpg"
                        },
                        new Ingredient()
                        {
                            Name = "garlic",
                            Quantity = "2 cloves",
                            IngredientDetails = "Garlic is technically neither herb nor spice but a member of the same family as onions and leeks. There are many varieties and they differ in size, pungency and colour.The most widely used European variety has a white / grey papery skin and pinkish-grey cloves and is grown in southern France. The bulbs found on sale are actually dried (in the sun), though we tend to consider them fresh.Smoked garlic is dried garlic that has been smoked to give it a golden colour and mellow smoky flavour.You can also buy garlic purée and garlic salt(or garlic granules).They don't have the juicy perfume of bulb garlic but are useful when making spice rubs.",
                            IngredientImage = "https://upload.wikimedia.org/wikipedia/commons/f/fb/Allium_sativum._Restra_de_allos_de_Oroso-_Galiza.jpg"
                        },
                        new Ingredient()
                        {
                            Name = "coriander",
                            Quantity = "a bunch",
                            IngredientDetails = "The small, creamy brown seeds of the coriander plant give dishes a warm, aromatic and slightly citrus flavour totally different to fresh coriander leaves.They are commonly used in Indian cooking as well as featuring in Asian, Middle Eastern and Mediterranean dishes.",
                            IngredientImage = "http://ichef.bbci.co.uk/food/ic/food_16x9_608/foods/c/coriander_fresh_16x9.jpg"
                        },
                        new Ingredient()
                        {
                            Name = "lime",
                            Quantity = "1",
                            IngredientDetails = "This small, green citrus fruit is a staple of Asian cuisine and is used mainly for its juice, although lime zest and leaves are also used in cooking.It has a stronger, more bitter taste than lemon.The juice can be squeezed into cocktails or sprinkled over finished dishes to enhance their flavour; it effectively 'cooks' raw fish in ceviche.Key lime pie is a famous dessert from Florida traditionally made with a special variety of limes called Key limes.",
                            IngredientImage = "https://encrypted-tbn3.gstatic.com/images?q=tbn:ANd9GcTSAXZocYogZJuUB6IfywTtZOtSiQ8rCsuwKEimwTO0P3-wWvul"
                        },
                        new Ingredient()
                        {
                            Name = "groundnut oil",
                            Quantity = "2 tbsp",
                            IngredientDetails = "A sweet and flavorful edible oil, peanut oil, also called groundnut oil, is made from Arachis hypogea, a low-growing, annual plant that is the lone member of the Fabaceae(Leguminosae) family.Despite the word “nut” in its name, peanut is actually a legume and grows underground, as opposed to other nuts like walnuts and almonds, which grow on trees (hence are called tree nuts).",
                            IngredientImage = "http://cdn2.stylecraze.com/wp-content/uploads/2013/08/4810-peanut-oil-for-skin-hair-and-health.jpg"
                        }
                    },
                Comments = new List<Comment>()
                {
                    new Comment()
                    {
                        Content = "Very delicious one!",
                        PostedBy = this.Users[1]
                    }
                },
                Likes = new List<Like>()
                {
                    new Like() { Value = true, Author = this.Users[0] },
                    new Like() { Value = true, Author = this.Users[1] },
                    new Like() { Value = true, Author = this.Users[2] }
                }
            });
            this.Recipes.Add(new Recipe
            {
                Title = "Raspberry and cream cupcakes",
                Description = "Preheat the oven to 180C/350F/Gas 4. Line a 12-hole muffin tin with paper cases. Place all of the cupcake ingredients, except the raspberries, into a food processor and mix until well combined. Add more milk, if Put one spoonful of the mixture into the cases, then follow with 2-3 raspberries, and another spoonful of mixture. Bake for 15-20 minutes, or until risen and golden-brown. Remove from the oven and set aside to cool for 10 minutes. Meanwhile, for the icing, beat the butter in a bowl until light and fluffy. Carefully stir in the icing sugar and continue to beat Decorate the cupcakes with the icing and top each cupcake with a raspberry.",
                Author = user,
                CreatedOn = DateTime.Now.AddDays(rand.Next(-5, 5)),
                CookingTime = "from 1 and a half hour to 2 hours",
                Season = Season.Spring,
                Occasion = this.Occasions[0],
                RecipeImage = "http://archive.canolainfo.org/quadrant/media/recipes/images/raspberry_cream_cupcakes_bweb.jpg"
            });

            // Adding Article Categories
            this.Categories.Add(new Category { Name = "Did you know?" });
            this.Categories.Add(new Category { Name = "Cooking techniques" });
            this.Categories.Add(new Category { Name = "Travel with Taste it!" });
            this.Categories.Add(new Category { Name = "Healthy" });
            this.Categories.Add(new Category { Name = "Vincere est vivere!" });

            // Adding Articles
            this.Articles.Add(new Article
            {
                Title = "World's Scariest Foods",
                Author = user,
                Category = this.Categories[2],
                Content = "Some say that a vacation isn't complete without trying the local foods, and with culinary tourism stronger than ever, people are even more adventurous about braving unfamiliar dishes. But as much as you may love to try new delicacies, there are plenty of exotic specialties you may think twice about seeing on your plate. Work up an appetite (or not) - these scary foods are notorious for stinking, looking weird and even causing death! Barbecued Bat (Indonesia) - Indonesia has some interesting dishes; the award for “most unusual” goes to the barbecued bat, served at local restaurants and street carts. Batman would be appalled, yet others find the dish quite delish. Cooks normally singe off the fur, then remove the wings and head. Depending on the size of the bat, the body is chopped up for stew or stir-fry (bones and all). Can't take the gamey smell (or taste) of the cave-dwelling mammal? Ask for extra garlic, pepper and chili. Try it at: Many street carts in Jakarta wheel up a good bat, but if you want a truly unforgettable experience, head to Tomohon Market in North Sulawesi, an otherwise macabre market that’s home to the motherload of bats (as well as pigs, monkeys, pythons and other animals). Another  one is Puffer Fish (Japan) - Japan may be known for preparing the world's best sushi, but here's one fish they might want to leave in the ocean. The puffer fish (or \"fugu\") is so poisonous (100 times more potent than cyanide!) it can kill someone -- literally -- as the diner who gets a lethal dose of the toxins can quickly submit to asphyxiation. Toxins must be removed so carefully that chefs need to be specially trained, licensed and certified by the government. The transparent fish tastes mild and clean but considering it's one of the most dangerous foods in the world, we say stick with tuna. Try it at: Although puffer fish is found throughout Japan, the restaurant chain Zuboraya (in Osaka) is recognized that serves it best.",
                CreatedOn = DateTime.Now.AddDays(rand.Next(-5, 5)),
                ArticleImage = "http://i.telegraph.co.uk/multimedia/archive/03084/puffer_fish_3084634b.jpg"
            });
        }

        public User Author { get; set; }

        public List<Occasion> Occasions { get; set; }

        public List<Recipe> Recipes { get; set; }

        public List<Category> Categories { get; set; }

        public List<Article> Articles { get; set; }

        public List<User> Users { get; set; }
    }
}