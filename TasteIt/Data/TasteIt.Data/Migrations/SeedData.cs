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
                    new Like() { Value = true, Author = this.Users[1] }
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
                RecipeImage = "http://archive.canolainfo.org/quadrant/media/recipes/images/raspberry_cream_cupcakes_bweb.jpg",
                Ingredients = new List<Ingredient>()
                {
                    new Ingredient()
                    {
                        Name = "butter",
                        Quantity = "180g/6oz",
                        IngredientDetails = "Butter is made from churning cream and is a kitchen essential. Without it, cakes, biscuits and pastries wouldn't have the same melting richness and tender texture. It's also used in many classic sauces, such as beurre blanc, beurre noisette, beurre meunier and hollandaise. Added at the end of cooking, it gives richness and gloss to sauces. With a fat content of 80 per cent, butter isn't exactly diet food, but a little goes a long way.",
                        IngredientImage = "http://www.greenprophet.com/wp-content/uploads/freshly-made-butter.jpg"
                    },
                    new Ingredient()
                    {
                       Name = "caster sugar",
                        Quantity = "180g/6oz",
                        IngredientDetails = "This is the British term for sugar with small grains that are between granulated and icing sugar in terms of fineness. It is sometimes spelled castor sugar, and is known as ‘superfine’ sugar in America. Caster sugar is obtained from sugar cane or sugar beet, and is valued for its quick-dissolving properties. The usual refined white variety of caster sugar will have been treated to remove molasses, and so will be free-flowing.",
                        IngredientImage = "http://f.tqn.com/y/candy/1/W/Z/O/-/-/bowl-of-sugar.jpg"
                    },
                    new Ingredient()
                    {
                        Name = "flour",
                        Quantity = "180g/6ozplain",
                        IngredientDetails = "Flour is the finely milled meal of cereal grains. The term mostly used to refer to wheat flour. However, nuts such as chestnuts, root vegetables like potatoes, seeds such as buckwheat, and pulses such as chickpeas can also be made into flour. Wheat flour is a staple of European, North American, Middle Eastern, African and South Asian cuisines. It’s graded according to whether it is made from hard wheat, soft wheat, or a mixture of the two; and whether the grain’s bran and germ are removed or left in. It is normally used in dishes where raising agents are not required.",
                        IngredientImage = "http://blog.ideasinfood.com/.a/6a00d83451f83a69e2016762d115b0970b-pi"
                    },
                    new Ingredient()
                    {
                        Name = "baking powder",
                        Quantity = "1 heaped tsp",
                        IngredientDetails = "A raising agent used in cakes, biscuits and breads. Commercial baking powder contains bicarbonate of soda and tartaric acid (with a dried starch or flour to absorb any moisture during storage). When these chemicals become moist and warm they react and give off carbon dioxide, which causes foods to rise.",
                        IngredientImage = "http://www.bbcgoodfood.com/sites/default/files/glossary/baking-powder-cropped.jpg"
                    },
                    new Ingredient()
                    {
                        Name = "milk",
                        Quantity = "3-4 tbsp",
                        IngredientDetails = "A highly nutritious liquid, milk is a very versatile kitchen ingredient. In the UK, cows’ milk is the most popular milk, although goats’ milk is increasing in popularity, and sheep and water buffalo milks are also occasionally available. Not only do animal milks vary significantly in terms of their nutritional content (although all are valuable sources of protein, calcium, vitamins and minerals), but also milk from the same source can differ according to such factors as the animal’s diet, the time of milking, and the breed concerned – Jersey and Guernsey cattle, for example, are famous for their ultra-creamy milk, which is sold as Channel Island or gold-top milk.",
                        IngredientImage = "https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcSwuO81MRowL6CiLpBUKH5st9a1KnuWW2gBshfCIGzL7DfXFr_l"
                    },
                    new Ingredient()
                    {
                        Name = "eggs",
                        Quantity = "2 free-range",
                        IngredientDetails = "Eggs are a useful source of protein, iodine and essential vitamins and are almost indispensable to the cook. Hens' eggs are the type of egg most frequently used in cooking. Duck eggs, gull eggs and quail eggs are less frequently used and are generally eaten on their own, rather than in baking. Quail eggs are small with dark-brown speckled shells. Duck eggs are larger than hens' eggs and richer in flavour, lending a creamy depth to baked dishes. Goose eggs and ostrich eggs are even bigger and for this reason are often blown out and decorated for Easter. Gulls' eggs are not widely available, but if you do come across them, serve them in much the same way as quails' eggs.",
                        IngredientImage = "http://punchbowlsocial.com/wp-content/uploads/2015/02/eyg.jpg"
                    },
                    new Ingredient()
                    {
                        Name = "raspberries",
                        Quantity = "150g/5oz",
                        IngredientDetails = "Fill a Victoria sponge with fresh raspberries for a taste of summer, or use them in a classic summer pudding. Try visiting a pick your own farm for the freshest raspberries.",
                        IngredientImage = "http://weknowyourdreamz.com/images/raspberries/raspberries-04.jpg"
                    },
                    new Ingredient()
                    {
                        Name = "food colouring",
                        Quantity = "small drop red",
                        IngredientDetails = "Food coloring, or color additive, is any dye, pigment or substance that imparts color when it is added to food or drink. They come in many forms consisting of liquids, powders, gels, and pastes. Food coloring is used both in commercial food production and in domestic cooking. Due to its safety and general availability, food coloring is also used in a variety of non-food applications including cosmetics, pharmaceuticals, home craft projects and medical devices.",
                        IngredientImage = "http://1.bp.blogspot.com/-pQhFoipAu-U/UaRy82UerCI/AAAAAAAAAW0/Y0xlCzsV0Fc/s1600/Rainbow+layer+cake.jpg"
                    }
                },
                Comments = new List<Comment>()
                {
                    new Comment()
                    {
                        Content = "Thank you for the good recipe!",
                        PostedBy = this.Users[1]
                    },
                    new Comment()
                    {
                        Content = "I love it!",
                        PostedBy = this.Users[2]
                    }
                },
                Likes = new List<Like>()
                {
                    new Like() { Value = true, Author = this.Users[0] },
                    new Like() { Value = true, Author = this.Users[1] },
                    new Like() { Value = true, Author = this.Users[2] }
                }
            });

            // Adding Article Categories
            this.Categories.Add(new Category { Name = "Did you know?" });
            this.Categories.Add(new Category { Name = "Cooking techniques" });
            this.Categories.Add(new Category { Name = "Travel with Taste it!" });
            this.Categories.Add(new Category { Name = "Healthy" });

            // Adding Articles
            this.Articles.Add(new Article
            {
                Title = "WORLD'S SCARIEST FOODS",
                Author = user,
                Category = this.Categories[2],
                Content = "Some say that a vacation isn't complete without trying the local foods, and with culinary tourism stronger than ever, people are even more adventurous about braving unfamiliar dishes. But as much as you may love to try new delicacies, there are plenty of exotic specialties you may think twice about seeing on your plate. Work up an appetite (or not) - these scary foods are notorious for stinking, looking weird and even causing death! Barbecued Bat (Indonesia) - Indonesia has some interesting dishes; the award for “most unusual” goes to the barbecued bat, served at local restaurants and street carts. Batman would be appalled, yet others find the dish quite delish. Cooks normally singe off the fur, then remove the wings and head. Depending on the size of the bat, the body is chopped up for stew or stir-fry (bones and all). Can't take the gamey smell (or taste) of the cave-dwelling mammal? Ask for extra garlic, pepper and chili. Try it at: Many street carts in Jakarta wheel up a good bat, but if you want a truly unforgettable experience, head to Tomohon Market in North Sulawesi, an otherwise macabre market that’s home to the motherload of bats (as well as pigs, monkeys, pythons and other animals). Another  one is Puffer Fish (Japan) - Japan may be known for preparing the world's best sushi, but here's one fish they might want to leave in the ocean. The puffer fish (or \"fugu\") is so poisonous (100 times more potent than cyanide!) it can kill someone -- literally -- as the diner who gets a lethal dose of the toxins can quickly submit to asphyxiation. Toxins must be removed so carefully that chefs need to be specially trained, licensed and certified by the government. The transparent fish tastes mild and clean but considering it's one of the most dangerous foods in the world, we say stick with tuna. Try it at: Although puffer fish is found throughout Japan, the restaurant chain Zuboraya (in Osaka) is recognized that serves it best.",
                CreatedOn = DateTime.Now.AddDays(rand.Next(-5, 5)),
                ArticleImage = "http://i.telegraph.co.uk/multimedia/archive/03084/puffer_fish_3084634b.jpg"
            });
            this.Articles.Add(new Article
            {
                Title = "ITALIAN EATING RULES",
                Author = user,
                Category = this.Categories[2],
                Content = "Americans have all sort of rules and laws they follow, such as rules involving queuing (an art technique perfected in Singapore where the queue is king). By contrast, Italians have very few rules and most of those can be broken. For example, in Italy, there is a minimum drinking age but it's not really respected. Situation changes entirely when it comes to food. Yes. Italians do have eating rules! For example, my friend George from New York City once wanted to order a cafe latte with his Mexican meal - right in front of me!!! It took me a while to dissuade him... I hope no restaurant in Italy would ever allow its customers to have cappuccino together with pasta!  I have never been brave enough to order pasta 'alle vongole' and cappuccino together to test this rule: if you have more courage than I do, try that combination and see what happens.  I just realized that Italy, the place where there are almost no rules (for example on the road where the only rule is you don't stay in the left lane on an autostrada except to pass), has in fact very strict eating rules. The following rules are aimed to correct common American (unacceptable!) mistakes... Even McDonald's in Italy serves cappuccino for breakfast. In Italy, forget eggs and bacon or sausages for breakfast except possibly in a hotel that caters to American or English tastes. Cappuccino and brioche are one of the few 'legal' options. Maybe a yogurt. Probably having tea is already pushing it too far... Coffee may be drunk with fruit or desert but never with the main meal. In addition, traditionally coffees with milk (cappuccinos and lattes) are for breakfast. Lunch and dinner are followed by espressos, or, at most an espresso macchiato (this is a rule that my wife likes to break, but she likes to live dangerously and can talk back in Italian if someone challenges her). The Italian main meal is traditionally multi-course: restaurants like to serve you first and second plates and do not appreciate it when Americans insist on having one thing (although they have been getting more used to it in recent times). But keep in mind that Italian portion sizes are smaller than American's, and the mixture they serve (pasta/rice first, followed by meat/fish/vegetables, followed by fruit) is a relatively healthy balance. You may get fewer calories and a healthier, more balanced meal by eating three courses in Italy, rather than one, giant entrée covered with cheese in the United States. ",
                CreatedOn = DateTime.Now.AddDays(rand.Next(-5, 5)),
                ArticleImage = "http://travelblog.goaheadtours.com/wp-content/uploads/trattoria-full.jpg"
            });
            this.Articles.Add(new Article
            {
                Title = "HOW TO BOIL EGGS",
                Author = user,
                Category = this.Categories[1],
                Content = "Always start with eggs that are at room temperature to best predict the cooking time and minimise cracking. For a soft-boiled egg, lower the egg into gently boiling water with a slotted spoon. Allow three and a half minutes for a medium-sized egg and four minutes for a large egg. The yolk will be runny and the white just set. Cook for a further minute if you like your soft boiled eggs a little firmer.For a hard-boiled egg, start the egg in cold water and bring up to the boil. Once the water is gently boiling, set the timer for between 7-10 minutes depending on how well cooked you like your eggs. The longer you boil the egg, the firmer it will be. Once cooked, plunge the hard-boiled egg into plenty of cold water for one minute. Drain and cover with more cold water. This will prevent the egg from over-cooking in its residual heat. Cracking the shell with the back of a spoon during cooling will also make the egg easier to peel.",
                CreatedOn = DateTime.Now.AddDays(rand.Next(-5, 5)),
                ArticleImage = "https://encrypted-tbn1.gstatic.com/images?q=tbn:ANd9GcSidPaihMLDA0KAWY-Z80noBWL0nIRzWPifeBvzLT5-8YCsaNTmqA"
            });
            this.Articles.Add(new Article
            {
                Title = "LEARNING TO CHOP: SLICING AN ONION",
                Author = user,
                Category = this.Categories[1],
                Content = "With a sharp knife and practice, you'll be slicing like a pro in no time. Peel the onion, leaving the root intact.Cut the onion in half through the root. With the onion flat on the chopping board, cut off the root at an angle. Trim away the top of the onion. Hold one side of the onion between your little finger and thumb. Place your other fingers on top of the onion. Angle the fingernail of your middle (or longest) finger and use that fingernail to guide and buffer the blade as it slices the onion very finely from one edge to the other. Meanwhile, with the hand holding the knife, ease the blade further up the onion with each cut.",
                CreatedOn = DateTime.Now.AddDays(rand.Next(-5, 5)),
                ArticleImage = "http://www.canadianliving.com/blogs/food/files/2014/03/sliced-onions.jpg"
            });
            this.Articles.Add(new Article
            {
                Title = "HOW TO COOK PERFECT RICE",
                Author = user,
                Category = this.Categories[1],
                Content = "Long-grain or basmati rice should be light and fluffy when perfectly cooked. To make sure you get good results every time, wash the rice in cold water until it runs clear. Drain the rice and put into a medium saucepan. Pour in water so that it covers the rice by 1.5cm/5/8in. Add a generous pinch of salt. Bring to the boil and then reduce the heat so that the water is simmering. Cover with a tight-fitting lid. White rice will cook in 10-12 minutes. When ready to serve, fluff the rice with a fork to separate the grains.",
                CreatedOn = DateTime.Now.AddDays(rand.Next(-5, 5)),
                ArticleImage = "http://www.thehungrymouse.com/wp-content/uploads/2011/09/DSCN0618.jpg"
            });
            this.Articles.Add(new Article
            {
                Title = "HOW TO PIPE CHOCOLATE DECORATIONS",
                Author = user,
                Category = this.Categories[1],
                Content = "Create easy decorations for cakes by piping chocolate onto non-stick acetate, baking parchment or a silicone mat. Fill a piping bag with tempered chocolate and snip off the tip. Slowly and steadily draw any shape you like with the chocolate onto your sheet or silicone mat. You could try hearts, spirals or waffles. For more complicated designs or consistent shapes, draw a template onto a piece of paper. Place this on baking tray and cover with a sheet of clear acetate so that you can follow the lines. Leave until completely set, or place in the fridge for 10 minutes to set faster so that it’s hard enough to peel off the acetate. When your shapes are ready, carefully lift off with a palette knife and place onto your iced cake.",
                CreatedOn = DateTime.Now.AddDays(rand.Next(-5, 5)),
                ArticleImage = "http://thechocolateaddict.com/blog/wp-content/uploads/2014/03/ChocolateLaceDoilyBEST.jpg"
            });
            this.Articles.Add(new Article
            {
                Title = "HOW TO COOK STEAK",
                Author = user,
                Category = this.Categories[1],
                Content = "Bring your steak to room temperature to ensure even cooking. Cut small slits across the line of fat on the side of the steak if it is very thick. This stops it buckling as it cooks. Drizzle some oil over the fat and meat. Sprinkle with salt and rub in. Season with pepper as well if you like. Place a griddle pan or heavy based frying pan over a high heat for at least five minutes. Hold the steak on the hot pan, standing it up on the fatty edge. Hold it there for 10-20 seconds until the fat begins to run onto the pan. Lay the steak on its side. Turn down the heat if your steak is very thick. On average, cook for two minutes on each side for a rare steak, three minutes for medium, and four minutes for well-done. However, the thickness of the steak will alter the cooking time. Pressing the steak down with a spatula will give a good brown crust. Once cooked to your liking, leave the steak to rest on a warm plate for five minutes, so the juices will settle evenly within the meat, while also allowing the meat to relax and become more tender.",
                CreatedOn = DateTime.Now.AddDays(rand.Next(-5, 5)),
                ArticleImage = "http://www.bisonbasics.com/recipes/rib_loin/images/steak_400.jpg"
            });
            this.Articles.Add(new Article
            {
                Title = "ADRENAL FATIGUE, THE STRESS SYNDROME OF THE 21ST CENTURY",
                Author = user,
                Category = this.Categories[0],
                Content = "Adrenal fatigue. In this blog I would like to discuss the greatest epidemic of Western society, next to insulin resistance: adrenal fatigue, also called burnout. Adrenal fatigue may occur when we are chronically exposed to stress. Next to checking the symptoms, it is possible to have a cortisol profile determined by a physician, using saliva tests. Make sure the physician concerned knows what adrenal fatigue is. Regular medical protocols only involve cortisol values for Addison's disease and Cushing's syndrome.It is very important, after reading the symptoms and if you suspect adrenal fatigue, to tackle the causes. Try to find out which stress sources have the most impact on you. Focus on these sources and determine, if necessary by consulting a coach, how this stress may be reduced in order to allow your adrenal glands to be restored. Be aware of the fact that, if adrenal fatigue is actually the case, it will not suffice to go on a week's holiday.Food: Too much sugar, chemical E numbers, pesticides, and food for which you may be intolerant or allergic may be stress sources that can be avoided. The Hormone Balance Diet is hypoallergenic, and chemical E numbers and pesticides are avoided. Still, you may have a rare intolerance or allergy that is not included in this programme. Therefore, it is wise to keep a diary to find out whether other allergens may play a part.",
                CreatedOn = DateTime.Now.AddDays(rand.Next(-5, 5)),
                ArticleImage = "http://foodmatters.tv/images/articles/stressed-ancient-wisdom-from-taoist-monk.jpg"
            });
            this.Articles.Add(new Article
            {
                Title = "EATING ORGANIC ON A BUDGET. IT’S POSSIBLE!",
                Author = user,
                Category = this.Categories[3],
                Content = "I used to be green with envy when my friends who were working full-time jobs bought organically grown healthy foods while I was in grad school and keeping expenses tight. With many people struggling to pay the bills, organic foods produced without chemicals or additives seem like an unattainable luxury only a few can actually afford. While it wasn’t easy in grad school to budget for foods that kept me feeling healthy, happy, and strong, with a little research, I found that there are ways to keep your diet green and your pockets green too! First: Eat with the seasons. I love eating seasonal produce. When I started to tailor my diet according to the seasons, I noticed how my body would change as well. Did you know that in the winter months the body actually calls for more food? Body fat is an evolutionary adaptation to insulate us from cold weather and even provides us with an emergency source of caloric energy. When you purchase food, you’re paying for packaging costs as well, which can add up. When purchasing in bulk, you not only get a little workout, but you aren’t paying for all of the packaging associated with single items. When I buy organics in bulk I buy nuts, grains, and dried fruit. This really does save you a lot and is good for the environment too. I know what you’re probably thinking… “Yeah right, I don’t have the time to grow anything to feed my family with! It’s busy enough to go to the market and shop for groceries.”  I am not saying that you need to start a greenhouse, but you may have fun and save money by growing some produce. I suggest planting basil or tomatoes to start with. If you don’t feel like starting from a seed, you could even buy an already fruitful plant and just maintain it. ",
                CreatedOn = DateTime.Now.AddDays(rand.Next(-5, 5)),
                ArticleImage = "http://www.joyoushealth.com/wp-content/uploads/2015/03/JH_ShopOrganic_Blog.jpg"
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