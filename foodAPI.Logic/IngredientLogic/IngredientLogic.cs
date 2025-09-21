using AutoMapper;
using foodAPI.Data;
using foodAPI.Entities;
using foodAPI.Entities.Dtos.Ingredients;

namespace foodAPI.Logic.IngredientLogic
{
    public class IngredientLogic
    {
        public Repository<Ingredient> repository;

        Mapper mapper;
        public IngredientLogic(Repository<Ingredient> repository, DtoProvider provider)
        {
            this.repository = repository;
            mapper = provider.Mapper;
        }

        public IEnumerable<IngredientViewDto> ReadAll()
        {
            return repository.GetAll().Select(x => mapper.Map<IngredientViewDto>(x)).ToList();
        }


        public IngredientViewDto Read(string id)
        {
            return mapper.Map<IngredientViewDto>(repository.FindById(id));
        }

        public async Task Delete(string id)
        {
            await repository.DeleteByIdAsync(id);
        }

        public async Task Update(string id, IngredientCreateUpdateDto dto)
        {
            var foodToUpdate = repository.FindById(id);
            if (foodToUpdate != null && foodToUpdate.Id == id)
            {
                mapper.Map(dto, foodToUpdate);
                await repository.UpdateAsync(foodToUpdate);
            }
        }

        public async Task Create(IngredientCreateUpdateDto dto)
        {
            var food = mapper.Map<Ingredient>(dto);
            await repository.CreateAsync(food);
        }


    }
}
