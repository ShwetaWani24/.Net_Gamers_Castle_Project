using Application.Contexts;
using Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Application.Managers
{
    public class GameManager : IGameManager
    {
        public List<Game> GetAllGames()
        {
            try
            {
                using (var context = new MyDbContext())
                {
                    return context.Game.ToList();
                }
            }
            catch (Exception e)
            {
                throw new Exception("Error retrieving games.", e);
            }
        }

        public Game GetGameById(int id)
        {
            try
            {
                using (var context = new MyDbContext())
                {
                    return context.Game.Find(id);
                }
            }
            catch (Exception e)
            {
                throw new Exception("Error retrieving game by ID.", e);
            }
        }

        public void AddGame(Game game)
        {
            try
            {
                using (var context = new MyDbContext())
                {
                    context.Game.Add(game);
                    context.SaveChanges();
                }
            }
            catch (Exception e)
            {
                throw new Exception("Error adding game.", e);
            }
        }

        public void UpdateGame(Game game)
        {
            try
            {
                using (var context = new MyDbContext())
                {
                    context.Game.Update(game);
                    context.SaveChanges();
                }
            }
            catch (Exception e)
            {
                throw new Exception("Error updating game.", e);
            }
        }

        public void DeleteGame(int id)
        {
            try
            {
                using (var context = new MyDbContext())
                {
                    var game = context.Game.Find(id);
                    if (game != null)
                    {
                        context.Game.Remove(game);
                        context.SaveChanges();
                    }
                }
            }
            catch (Exception e)
            {
                throw new Exception("Error deleting game.", e);
            }
        }
    }
}