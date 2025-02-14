using Application.Contexts;
using Entities;
using System.Collections.Generic;
using System.Linq;

namespace Application.Services
{
    public class GameService : IGameService
    {
        private readonly MyDbContext _context;

        public GameService(MyDbContext context)
        {
            _context = context;
        }

        public IEnumerable<Game> GetAllGames()
        {
            return _context.Game.ToList();
        }

        public Game GetGameById(int id)
        {
            return _context.Game.Find(id);
        }

        public void AddGame(Game game)
        {
            _context.Game.Add(game);
            _context.SaveChanges();
        }

        public void UpdateGame(Game game)
        {
            _context.Game.Update(game);
            _context.SaveChanges();
        }

        public void DeleteGame(int id)
        {
            var game = _context.Game.Find(id);
            if (game != null)
            {
                _context.Game.Remove(game);
                _context.SaveChanges();
            }
        }
    }
}
