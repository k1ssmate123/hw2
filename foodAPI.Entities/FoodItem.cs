using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Security.Principal;
using foodAPI.Data.Helpers;

namespace foodAPI.Entities
{
    public class FoodItem : IIdEntity
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public string Id { get; set; } = Guid.NewGuid().ToString();

        public string Name { get; set; }  = string.Empty;

        [NotMapped]
        public virtual ICollection<IngredientAmount> IngredientAmounts { get; set; } 
    }
}
