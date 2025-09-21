using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using foodAPI.Entities.Dtos.IngredientAmount;
using foodAPI.Entities.Dtos.Ingredients;

namespace foodAPI.Entities.Dtos.Food
{
    public class FoodItemViewDto
    {
        public string Name { get; set; } = string.Empty;

        public virtual ICollection<IngredientAmountDto> Ingredients { get; set; }

        public int CaloriesAll { get; set; } = 0;
    }
}
