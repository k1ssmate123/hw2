using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using foodAPI.Entities;
using foodAPI.Entities.Dtos.Food;
using foodAPI.Entities.Dtos.Ingredients;
using foodAPI.Entities.Dtos;

namespace foodAPI.Logic
{
    public class DtoProvider
    {
        public Mapper Mapper { get; }

        public DtoProvider()
        {
            Mapper = new Mapper(new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<FoodItem, FoodItemViewDto>()
        .ForMember(dest => dest.Ingredients, opt => opt.MapFrom(src => src.IngredientAmounts))
        .ForMember(dest => dest.CaloriesAll, opt => opt.MapFrom(src => src.IngredientAmounts
            .Sum(ia => (ia.AmountInGrams * ia.Ingredient.Calorie/100))));  


                cfg.CreateMap<IngredientAmount, IngredientAmountDto>()
                    .ForMember(dest => dest.IngredientName, opt => opt.MapFrom(src => src.Ingredient.Name))
                    .ForMember(dest => dest.Amount, opt => opt.MapFrom(src => src.AmountInGrams));


                cfg.CreateMap<FoodItemCreateDeleteAddDto, FoodItem>();

                cfg.CreateMap<IngredientCreateUpdateDto, Ingredient>();
                cfg.CreateMap<IngredientDeleteAddDto, Ingredient>();
                cfg.CreateMap<Ingredient, IngredientViewDto>();
                cfg.CreateMap<AddIngredientToFoodDto, IngredientAmount>();
            }));
        }
    }
}
