
using foodAPI.Entities.Dtos.Ingredients;

using foodAPI.Logic.IngredientLogic;

using Microsoft.AspNetCore.Mvc;

namespace foodAPI.Endpoint.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class IngredientController
    {
        IngredientLogic logic;

        public IngredientController(IngredientLogic logic)
        {
            this.logic = logic;
        }

        [HttpGet]
        public IEnumerable<IngredientViewDto> Get()
        {
            return logic.ReadAll();
        }


        [HttpGet("{id}")]
        public IngredientViewDto GetById(string id)
        {
            return logic.Read(id);
        }


        [HttpDelete("{id}")]
        public async Task Delete(string id)
        {
            await logic.Delete(id);
        }

        [HttpPut("{id}")]
        public async Task Update(string id, [FromBody] IngredientCreateUpdateDto dto)
        {
            await logic.Update(id, dto);
        }

        [HttpPost]
        public async Task Create(IngredientCreateUpdateDto dto)
        {
            await logic.Create(dto);
        }
    }
}
