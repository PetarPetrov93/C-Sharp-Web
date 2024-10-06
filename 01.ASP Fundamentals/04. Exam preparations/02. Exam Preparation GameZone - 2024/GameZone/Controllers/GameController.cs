using GameZone.Contracts;
using GameZone.Data.Models;
using GameZone.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.CodeAnalysis.Differencing;

namespace GameZone.Controllers
{
    public class GameController : BaseController
    {
        private readonly IGameService gameService;
        public GameController(IGameService _gameService)
        {
            gameService = _gameService;
        }

        // displays all games
        [HttpGet]
        public async Task<IActionResult> All()
        {
            var model = await gameService.GetAllGamesAsync();

            return View(model);
        }

        //renders the Add game page
        [HttpGet]
        public async Task<IActionResult> Add()
        {
            AddGameViewModel model = await gameService.GetGenresAsync();
            return View(model);
        }

        //creates and adds a new game
        [HttpPost]
        public async Task<IActionResult> Add(AddGameViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            string userId = GetId();
            await gameService.AddGameAsync(model, userId);

            return RedirectToAction(nameof(All));
        }

        //displays all games of the logged-in user
        [HttpGet]
        public async Task<IActionResult> MyZone()
        {
            var model = await gameService.AllZonedAsync(GetId());

            if (model.Any() == false)
            {
                return RedirectToAction(nameof(All));
            }

            return View(model);
        }

        // adds a game to the logged-in user's collection
        [HttpGet]
        public async Task<IActionResult> AddToMyZone(int id)
        {
            Game game = await gameService.GetGameByIdAsync(id);

            if (game == null) 
            {
                return BadRequest();
            }
            
            await gameService.AddGameToMyZoneAsync(GetId(), game);
            return RedirectToAction(nameof(MyZone));
        }

        //gets the game to edit and loads the information and the genres
        [HttpGet]
        public async Task<IActionResult> Edit(int id)
        {
            EditGameViewModel model = await gameService.GetEditModelAsync(id);

            if (model == null)
            {
                return BadRequest();
            }

            if (model.PublisherId != GetId())
            {
                return Unauthorized();
            }

            return View(model);
        }

        //edits the game to edit and saves changes
        [HttpPost]
        public async Task<IActionResult> Edit(int id, EditGameViewModel model)
        {
            var game = await gameService.GetGameByIdAsync(id);

            if (game == null)
            {
                return BadRequest();
            }

            if (game.PublisherId != GetId())
            {
                return Unauthorized();
            }

            await gameService.EditGameAsync(model, game);

            return RedirectToAction(nameof(All));
        }

        //removes the game from the logged-in user's collection
        [HttpGet]
        public async Task<IActionResult> StrikeOut(int id)
        {
            var game = await gameService.GetGameByIdAsync(id);
            if (game == null) 
            {
                return BadRequest();
            }
            
            await gameService.StrikeOutAsync(GetId(), game);

            return RedirectToAction(nameof(MyZone));
        }

        //Game Details
        [HttpGet]
        public async Task<IActionResult> Details(int id)
        {
            GameDetailsViewModel game = await gameService.GetGameDetails(id);

            if (game == null)
            {
                return BadRequest();
            }

            return View(game);
        }

        //gets the game to delete details
        [HttpGet]
        public async Task<IActionResult> Delete(int id)
        {
            var game = await gameService.GetGameByIdAsync(id);

            if (game == null)
            {
                return BadRequest();
            }

            if (game.PublisherId != GetId())
            {
                return Unauthorized();
            }

            DeleteGameViewModel model = new DeleteGameViewModel
            {
                Id = game.Id,
                Title = game.Title
            };

            return View(model);
        }

        //Deletes the game
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Delete(int id, DeleteGameViewModel model)
        {
            var game = await gameService.GetGameByIdAsync(id);

            if (game == null)
            {
                return BadRequest();
            }

            await gameService.DeleteGameAsync(game);

            return RedirectToAction(nameof(All));
        }
    }
}
