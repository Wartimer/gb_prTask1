using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace gb_prTasks8_4
{
    public class Recipe
    {
        public string Title { get; set; }

        public int CookingTime{ get; set; }

        public int Rating { get; set; }

        public List<string> Ingredients { get; set; }


        public Recipe() { }

        public Recipe(string title, List<string> ingredients, int cookingTime, int rating)
        {
            Title = title;
            CookingTime = cookingTime;
            Rating = rating;
            Ingredients = ingredients;
        }

    }
}
