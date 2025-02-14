using Entities;
using System.Collections.Generic;

namespace Application.Services
{
    public interface IGameService
    {
        IEnumerable<Game> GetAllGames();
        Game GetGameById(int id);
        void AddGame(Game game);
        void UpdateGame(Game game);
        void DeleteGame(int id);
    }
}
