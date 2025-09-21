using foodAPI.Entities.Dtos.IngredientAmount;
using foodAPI.Logic.IngredientAmountLogic;
using Microsoft.AspNetCore.Mvc;

namespace foodAPI.Endpoint.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class JoinController
    {
        IngredientAmountLogic logic;

        public JoinController(IngredientAmountLogic logic)
        {
            this.logic = logic;
        }

        [HttpPost]
        public async Task AddIngredientToFood(AddIngredientToFoodDto dto)
        {
            await logic.AddIngredientToFood(dto);
        }
    }
}
