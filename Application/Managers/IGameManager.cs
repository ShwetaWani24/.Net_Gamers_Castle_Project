using Entities;
using System.Collections.Generic;

namespace Application.Managers
{
    public interface IGameManager
    {
        List<Game> GetAllGames();
        Game GetGameById(int id);
        void AddGame(Game game);
        void UpdateGame(Game game);
        void DeleteGame(int id);
    }
}