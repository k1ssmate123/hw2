using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using foodAPI.Data;
using foodAPI.Entities;
using foodAPI.Entities.Dtos;

namespace foodAPI.Logic
{
    public class IngredientAmountLogic
    {
        Repository<IngredientAmount> repository;

        Mapper mapper;

        public IngredientAmountLogic(Repository<IngredientAmount> repository, DtoProvider provider)
        {
            this.repository = repository;
            this.mapper = provider.Mapper;
        }

        public async Task AddIngredientToFood(AddIngredientToFoodDto dto)
        {
            await repository.CreateAsync(mapper.Map<IngredientAmount>(dto));
        }

    }
}
