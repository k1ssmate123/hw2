using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using foodAPI.Data.Helpers;

namespace foodAPI.Entities
{
    public class IngredientAmount : IIdEntity
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public string Id { get; set; } = Guid.NewGuid().ToString();

        public string FoodItemId { get; set; }

        public virtual FoodItem FoodItem { get; set; }

        public string IngredientId { get; set; }

        public virtual Ingredient Ingredient { get; set; }  

        public double AmountInGrams { get; set; }


    }
}
