using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using foodAPI.Entities.Dtos.Food;
using foodAPI.Entities.Dtos.Ingredients;

namespace foodAPI.Entities.Dtos.IngredientAmount
{
    public class AddIngredientToFoodDto
    {
        public string FoodItemId { get; set; }
        public string IngredientId { get; set; }
        public double AmountInGrams { get; set; }
    }
}
