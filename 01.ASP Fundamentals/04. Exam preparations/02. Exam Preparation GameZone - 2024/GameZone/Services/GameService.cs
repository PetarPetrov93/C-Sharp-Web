using GameZone.Contracts;
using GameZone.Data;
using GameZone.Data.Models;
using GameZone.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Globalization;
using static GameZone.Common.ValidationConstants.ForGame;

namespace GameZone.Services
{
    public class GameService : IGameService
    {
        private readonly GameZoneDbContext context;

        public GameService(GameZoneDbContext _context)
        {
            context = _context;
        }


        // creates and adds a new game
        public async Task AddGameAsync(AddGameViewModel model, string userId)
        {
            string dateTimeString = $"{model.ReleasedOn}";

            if (!DateTime.TryParseExact(dateTimeString, "yyyy-MM-dd", CultureInfo.InvariantCulture,
                DateTimeStyles.None, out DateTime parseDateTime))
            {
                throw new InvalidOperationException("Invalid date format.");
            }

            var newGame = new Game
            {
                Title = model.Title,
                Description = model.Description,
                ImageUrl = model.ImageUrl,
                PublisherId = userId,
                ReleasedOn = parseDateTime,
                GenreId = model.GenreId
            };

            await context.AddAsync(newGame);
            await context.SaveChangesAsync();
        }

        // adds a game to the logged-in user's collection
        public async Task AddGameToMyZoneAsync(string userId, Game model)
        {
            bool isAlreadyAdded = await context.GamersGames
                .AnyAsync(gg => gg.GamerId == userId && gg.GameId == model.Id);

            if (isAlreadyAdded)
            {
                return;
            }
            var gamerGame = new GamerGame
            {
                GamerId = userId,
                GameId = model.Id
            };

            await context.GamersGames.AddAsync(gamerGame);
            await context.SaveChangesAsync();
        }


        // gets all the games of the logged-in user
        public async Task<IEnumerable<AllGamesViewModel>> AllZonedAsync(string userId)
        {
            return await context.GamersGames
                .Where(gg => gg.GamerId == userId)
                .Select( gg => new AllGamesViewModel
                {
                    Id = gg.Game.Id,
                    Title = gg.Game.Title,
                    ImageUrl= gg.Game.ImageUrl,
                    ReleasedOn = gg.Game.ReleasedOn.ToString(DateTimeFormat),
                    Genre = gg.Game.Genre.Name,
                    Publisher = gg.Game.Publisher.UserName
                })
                .ToListAsync();
        }

        //edits the game
        public async Task EditGameAsync(EditGameViewModel model, Game game)
        {
            string dateTimeString = $"{model.ReleasedOn}";

            if (DateTime.TryParseExact(dateTimeString, DateTimeFormat, CultureInfo.InvariantCulture, DateTimeStyles.None, out DateTime parseDateTime) == false)
            {
                throw new InvalidOperationException("Invalid dat format.");
            }

            game.Title = model.Title;
            game.ImageUrl = model.ImageUrl;
            game.Description = model.Description;
            game.ReleasedOn = parseDateTime;
            game.GenreId = model.GenreId;

            await context.SaveChangesAsync();
        }

        // gets all the games on the All page
        public async Task<IEnumerable<AllGamesViewModel>> GetAllGamesAsync()
        {

            return await context.Games
                .Select(g => new AllGamesViewModel
                {
                    Id = g.Id,
                    Title = g.Title,
                    Genre = g.Genre.Name,
                    ImageUrl = g.ImageUrl,
                    ReleasedOn = g.ReleasedOn.ToString(DateTimeFormat),
                    Publisher = g.Publisher.UserName
                })
                .ToListAsync();
        }

        //gets the game to edit and loads the Genres
        public async Task<EditGameViewModel> GetEditModelAsync(int id)
        {
            var genres = await context.Genres
                .Select(g => new GenreViewModel
                {
                    Id = g.Id,
                    Name = g.Name
                })
                .ToListAsync();

            return await context.Games
                .Where(g => g.Id == id)
                .Select(g => new EditGameViewModel
                {
                    Title = g.Title,
                    Description = g.Description,
                    ImageUrl = g.ImageUrl,
                    ReleasedOn = g.ReleasedOn.ToString(DateTimeFormat),
                    GenreId = g.Id,
                    Genres = genres,
                    PublisherId = g.PublisherId
                })
                .FirstOrDefaultAsync();
        }

        //finds and returns a game by given ID
        public async Task<Game> GetGameByIdAsync(int id)
        {
            return await context.Games
                .FirstOrDefaultAsync(b => b.Id == id);
        }

        // gets all the genres
        public async Task<AddGameViewModel> GetGenresAsync()
        {
            var genres = await context.Genres
                .Select(g => new GenreViewModel
                {
                    Id = g.Id,
                    Name = g.Name
                })
                .ToListAsync();

            var model = new AddGameViewModel
            {
                Genres = genres
            };

            return model;
        }

        //Removes the game from the logged in user's collection
        public async Task StrikeOutAsync(string userId, Game game)
        {
            var gamerGame = await context.GamersGames
                .FirstOrDefaultAsync(gg => gg.GamerId == userId && gg.GameId == game.Id);

            if (gamerGame != null) 
            {
                context.GamersGames.Remove(gamerGame);
                await context.SaveChangesAsync();
            }
        }

        //Game details
        public async Task<GameDetailsViewModel> GetGameDetails(int id)
        {
            return await context.Games
                .Where(g => g.Id == id)
                .Select(g => new GameDetailsViewModel
                {
                    Id = g.Id,
                    Title = g.Title,
                    Description = g.Description,
                    ImageUrl = g.ImageUrl,
                    ReleasedOn = g.ReleasedOn.ToString(DateTimeFormat),
                    Genre = g.Genre.Name,
                    Publisher = g.Publisher.UserName
                })
                .FirstOrDefaultAsync();
        }

        //Delete game
        public Task DeleteGameAsync(Game game)
        {
            context.Games.Remove(game);
            return context.SaveChangesAsync();
        }
    }
}
