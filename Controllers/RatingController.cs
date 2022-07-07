using System;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using RestaurantRaterAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace RestaurantRaterAPI.Controllers;


    [ApiController]
    [Route("[controller]")]
    public class RatingController
    {
        private RestaurantDbContext _context;
        public RatingController(RestaurantDbContext context) {
            _context = context;
        }


        [HttpPost]
        public async Task<IActionResult> PostRating([FromForm] RatingEdit model) 
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            _context.Ratings.Add(new Rating() 
            {
                FoodScore = model.FoodScore,
                CleanlinessScore = model.CleanlinessScore,
                AtmosphereScore = model.AtmosphereScore,
                RestaurantId = model.RestaurantId,
            });

            await _context.SaveChangesAsync();

            return Ok();
        }

        
    }
