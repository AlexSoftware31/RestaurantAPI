using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using RestaurantWebAPI.Dto;
using System.Text.Json;
using WebApi.Entities.Models;
using WebApi.Services.Interfaces;


namespace RestaurantWebAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    [Authorize]
    public class MealController(IMealServices mealServices) : ControllerBase
    {
        private readonly IMealServices _mealServices = mealServices;

        [HttpGet(Name = "GetMeals")]
        public async Task<IActionResult> Get()
        {
            var meals = await _mealServices.GetAllMeals();

            return Ok(meals);
        }

        [HttpPost]
        public async Task<IActionResult> Post(MealDto mealDto)
        {
            if (mealDto == null)
            {
                return BadRequest(mealDto);
            }

            Meal meal = new(mealDto.Id, mealDto.Name, mealDto.Price, mealDto.Description, mealDto.Image);

            await _mealServices.Add(meal);

            return Created("", new { message = "Meal created!" });
        }

        [HttpPut]
        public async Task<IActionResult> Update(MealDto mealDto)
        {
            if (mealDto == null)
            {
                return BadRequest(mealDto);
            }

            Meal meal = new(mealDto.Id, mealDto.Name, mealDto.Price, mealDto.Description, mealDto.Image);

            await _mealServices.Update(meal);

            return Ok(new { message = "Meal updated!" });
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(string id)
        {
            if (id == null)
            {
                return BadRequest();
            }

            Meal meal = await _mealServices.FindById(id);

            await _mealServices.Remove(meal);

            return Ok(new { message = "Meal deleted!" });
        }
    }
}
