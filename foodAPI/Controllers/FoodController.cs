using System.Runtime.InteropServices;
using foodAPI.Entities.Dtos.Food;
using foodAPI.Entities.Dtos.Ingredients;
using foodAPI.Logic.FoodLogic;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace foodAPI.Endpoint.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class FoodController
    {
        FoodLogic logic;

        public FoodController(FoodLogic logic)
        {
            this.logic = logic;
        }

        [HttpGet]
        public IEnumerable<FoodItemViewDto> Get()
        {
            return logic.ReadAll();
        }


        [HttpGet("{id}")]
        public FoodItemViewDto GetById(string id)
        {
            return logic.Read(id);
        }


        [HttpDelete("{id}")]
        public async Task Delete(string id)
        {
            await logic.Delete(id);
        }

        [HttpPut("{id}")]
        public async Task Update(string id, [FromBody] FoodItemCreateDeleteAddDto dto)
        {   
            await logic.Update(id, dto);
        }

        [HttpPost]
        public async Task Create(FoodItemCreateDeleteAddDto dto)
        {
            await logic.Create(dto);
        }

    }
}
