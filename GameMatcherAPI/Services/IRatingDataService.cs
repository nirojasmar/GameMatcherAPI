using GameMatcherAPI.Models;
using MongoDB.Bson;

namespace GameMatcherAPI.Services
{
    public interface IRatingDataService
    {
        List<Rating> GetAllRatings();
        Rating GetRatingByAuthor(string id);
        Rating InsertRating(Rating rating);
        Rating UpdateRating(Rating rating);
        bool DeleteRating(string id);
    }
}
