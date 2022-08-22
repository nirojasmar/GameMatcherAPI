using Microsoft.AspNetCore.Mvc;
using GameMatcherAPI.Models;
using GameMatcherAPI.Services;
using Serilog;

namespace GameMatcherAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RatingController : ControllerBase
    {
        private readonly RatingDAO _ratingDAO;
        private readonly UserDAO _userDAO;

        public RatingController(RatingDAO ratingDAO, UserDAO userDAO)
        {
            _ratingDAO = ratingDAO;
            _userDAO = userDAO;
        }
        // GET: RatingController
        [HttpGet(Name = "Ratings")]
        public async Task<List<Rating>> Get() =>
            await _ratingDAO.GetAsync();

        [HttpGet(template: "User/{user_id}", Name ="RatingsByUser")]
        public async Task<List<Rating>?> GetUserRatings(string user_id)
        {
            var user = await _userDAO.GetByIdAsync(user_id);
            if (user == null)
            {
                Log.Error("404: User {user_id} Not Found");
                return null;
            }
            return await _ratingDAO.GetRatingsByUserAsync(user_id);
        }

        [HttpGet("{id}")]
        public async Task<Rating> GetRatingById(string id) =>
            await _ratingDAO.GetRatingAsync(id);

        [HttpPost]
        public async Task<IActionResult> InsertRating(Rating rating)
        {
            var user = await _userDAO.GetByIdAsync(rating.User);
            if (user == null)
            {
                Log.Error("404: User {user_id} Not Found");
                return NotFound();
            }
            Log.Warning("Inserting {rating} on User {user}");
            user.Rating.Add(rating);
            await _userDAO.UpdateAsync(user.Name, user);
            await _ratingDAO.InsertAsync(rating);
            return CreatedAtAction(nameof(Get), new { id = rating.Id }, rating);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateRating(string id, Rating updatedRating)
        {
            var oldRating = await _ratingDAO.GetRatingAsync(id);
            if(oldRating == null)
            {
                Log.Error("Rating with id {id} Not Found, Aborting...");
                return NotFound();
            }

            updatedRating.Id = oldRating.Id;
            await _ratingDAO.UpdateAsync(id, updatedRating);
            return NoContent();
        }
        
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteRating(string id)
        {
            var oldRating = await _ratingDAO.GetRatingAsync(id);
            if (oldRating == null)
            {
                Log.Error("Rating with id {id} Not Found, Aborting...");
                return NotFound();
            }

            await _ratingDAO.DeleteAsync(id);
            return NoContent();
        }
    }
}
