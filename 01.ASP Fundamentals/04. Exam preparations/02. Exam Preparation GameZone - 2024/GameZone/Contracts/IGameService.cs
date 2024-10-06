using GameZone.Data.Models;
using GameZone.Models;

namespace GameZone.Contracts
{
    public interface IGameService
    {
        // gets all the games on the All page
        Task<IEnumerable<AllGamesViewModel>> GetAllGamesAsync();

        // creates and adds a new game
        Task AddGameAsync(AddGameViewModel model, string userId);

        // gets all the genres
        Task<AddGameViewModel> GetGenresAsync();

        // gets all the games of the logged-in user
        Task<IEnumerable<AllGamesViewModel>> AllZonedAsync(string userId);

        // adds a game to the logged-in user's collection
        Task AddGameToMyZoneAsync(string userId, Game model);

        //finds and returns a game by given ID
        Task<Game> GetGameByIdAsync(int id);

        //gets the game to edit and loads the Genres
        Task<EditGameViewModel> GetEditModelAsync(int id);

        //edits the game
        Task EditGameAsync(EditGameViewModel model, Game game);

        //Removes the game from the logged in user's collection
        Task StrikeOutAsync(string userId, Game game);

        //Game Details
        Task<GameDetailsViewModel> GetGameDetails(int id);

        //Delete game
        Task DeleteGameAsync(Game game);
    }

}
