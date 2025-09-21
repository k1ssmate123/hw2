using AutoMapper;
using foodAPI.Data;
using foodAPI.Entities;
using foodAPI.Entities.Dtos.Food;
using foodAPI.Entities.Dtos.Ingredients;
namespace foodAPI.Logic.Food
{
    public class FoodLogic
    {
        public Repository<FoodItem> repository;
      
        Mapper mapper;
        public FoodLogic(Repository<FoodItem> repository, DtoProvider provider)
        {
            this.repository = repository;
            mapper = provider.Mapper;
        }

        public IEnumerable<FoodItemViewDto> ReadAll()
        {
            return repository.GetAll().Select(x => mapper.Map<FoodItemViewDto>(x)).ToList();
        }


        public FoodItemViewDto Read(string id)
        {
            return mapper.Map<FoodItemViewDto>(repository.FindById(id));
        }

        public async Task Delete(string id)
        {
            await repository.DeleteByIdAsync(id);
        }

        public async Task Update(string id, FoodItemCreateDeleteAddDto dto)
        {
            var foodToUpdate = repository.FindById(id);
            if (foodToUpdate != null && foodToUpdate.Id == id)
            {
                mapper.Map(dto, foodToUpdate);
                await repository.UpdateAsync(foodToUpdate);
            }
        }

        public async Task Create(FoodItemCreateDeleteAddDto dto)
        {
            var food = mapper.Map<FoodItem>(dto);
            await repository.CreateAsync(food);
        }

    
    }
}
