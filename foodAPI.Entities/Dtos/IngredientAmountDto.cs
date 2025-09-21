using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace foodAPI.Entities.Dtos
{
    public class IngredientAmountDto
    {
        public string IngredientName { get; set; }
        public decimal Amount { get; set; }
    }
}
