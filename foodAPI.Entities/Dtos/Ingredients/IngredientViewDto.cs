using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace foodAPI.Entities.Dtos.Ingredients
{
    public class IngredientViewDto
    {
        public string Name { get; set; } = string.Empty;
        public int Calorie { get; set; } = 0;
    }
}
