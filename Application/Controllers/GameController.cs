using Microsoft.AspNetCore.Mvc;
using Application.Services;
using Entities;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace Application.Controllers
{
    public class GameController : Controller
    {
        private readonly IGameService _gameService;

        public GameController(IGameService gameService)
        {
            _gameService = gameService;
        }

        // GET: Game
        public IActionResult Index()
        {
            var games = _gameService.GetAllGames();
            return View(games);
        }
        public IActionResult Index1()
        {
            var games = _gameService.GetAllGames();
            return View(games);
        }
       



        // GET: Game/Details/5
        public IActionResult Details(int id)
        {
            var game = _gameService.GetGameById(id);
            if (game == null)
            {
                return NotFound();
            }
            return View(game);
        }

        // GET: Game/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Game/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Game game)
        {
            if (ModelState.IsValid)
            {
                _gameService.AddGame(game);
                return RedirectToAction(nameof(Index));
            }
            return View(game);
        }

        // GET: Game/Edit/5
        public IActionResult Edit(int id)
        {
            var game = _gameService.GetGameById(id);
            if (game == null)
            {
                return NotFound();
            }
            return View(game);
        }

        // POST: Game/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(int id, Game game)
        {
            if (id != game.GameId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                _gameService.UpdateGame(game);
                return RedirectToAction(nameof(Index));
            }
            return View(game);
        }

        // GET: Game/Delete/5
        public IActionResult Delete(int id)
        {
            var game = _gameService.GetGameById(id);
            if (game == null)
            {
                return NotFound();
            }
            return View(game);
        }
       
        public IActionResult CheckCompatibility ()
        {
           
            return View();
        }

        // POST: Game/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(int id)
        {
            _gameService.DeleteGame(id);
            return RedirectToAction(nameof(Index));
        }
    }
}