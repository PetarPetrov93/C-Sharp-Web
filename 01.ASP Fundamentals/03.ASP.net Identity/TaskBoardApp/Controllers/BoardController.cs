using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TaskBoardApp.Data;
using TaskBoardApp.ViewModels.Board;
using TaskBoardApp.ViewModels.Task;

namespace TaskBoardApp.Controllers
{
    [Authorize]
    public class BoardController : Controller
    {
        private readonly TasakBoardAppDbContext data;

        public BoardController(TasakBoardAppDbContext _context)
        {
            data = _context;
        }
        public async Task<IActionResult> All()
        {
            var boards = await data.Boards
                .Select(b => new BoardViewModel()
                {
                    Id = b.Id,
                    Name = b.Name,
                    Tasks = b.Tasks
                            .Select(t => new TaskViewModel()
                            {
                                Id = t.Id,
                                Title = t.Title,
                                Description = t.Description,
                                Owner = t.Owner.UserName ?? string.Empty,
                            })
                            .ToArray()
                })
                .AsNoTracking()
                .ToArrayAsync();

            return View(boards);
        }
    }
}
