using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using foodAPI.Data.Helpers;

namespace foodAPI.Entities
{
    public class Ingredient : IIdEntity
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public string Id { get; set; } = Guid.NewGuid().ToString();

        public string Name { get; set; }  = string.Empty;
        public int Calorie { get; set; } = 0;

        [NotMapped]
        public virtual ICollection<IngredientAmount> IngredientAmounts { get; set; }

    }
}