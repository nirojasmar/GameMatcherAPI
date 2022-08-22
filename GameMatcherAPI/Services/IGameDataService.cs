﻿using MongoDB.Bson;
using GameMatcherAPI.Models;

namespace GameMatcherAPI.Services
{
    public interface IGameDataService
    {
        Task<List<Game>> GetAsync();
        Task<Game> GetGameByIdAsync(string id);
        Task InsertAsync(Game game);
        Task UpdateAsync(string id, Game game);
        Task DeleteAsync(string id);
    }
}
