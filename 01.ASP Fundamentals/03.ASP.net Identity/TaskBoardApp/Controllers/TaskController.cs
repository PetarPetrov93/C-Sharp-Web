using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Security.Claims;
using TaskBoardApp.Data;
using TaskBoardApp.ViewModels.Task;
using Task = TaskBoardApp.Data.Models.Task;

namespace TaskBoardApp.Controllers
{
    [Authorize]
    public class TaskController : Controller
    {
        private readonly TasakBoardAppDbContext data;
        public TaskController(TasakBoardAppDbContext context)
        {
            data = context;
        }

        [HttpGet]
        public async Task<IActionResult> Create()
        {
            TaskFormModel newTask = new TaskFormModel()
            {
                Boards = GetBoards()
            };
            return View(newTask);
        }

        [HttpPost]
        public async Task<IActionResult> Create(TaskFormModel taskFormModel)
        {
            if (!GetBoards().Any(b => b.Id == taskFormModel.BoardId))
            {
                ModelState.AddModelError(nameof(taskFormModel.BoardId), "Board does not exist.");
            }

            string currentUserId = GetUserId();

            if (!ModelState.IsValid)
            {
                taskFormModel.Boards = GetBoards();

                return View(taskFormModel);
            }

            Task task = new Task()
            {
                Title = taskFormModel.Title,
                Description = taskFormModel.Description,
                CreatedOn = DateTime.Now,
                BoardId = taskFormModel?.BoardId,
                OwnerId = currentUserId
            };

            await data.Tasks.AddAsync(task);
            await data.SaveChangesAsync();

            var boards = data.Boards;

            return RedirectToAction("All", "Board");
        }

        [HttpGet]
        public async Task<IActionResult> Details(int id)
        {
            var task = await data.Tasks
                .Where(t => t.Id == id)
                .Select(t => new TaskDetailsViewModel()
                {
                    Id = t.Id,
                    Title = t.Title,
                    Description = t.Description,
                    CreatedOn = t.CreatedOn.Value.ToString("dd/MM/yyyy HH:mm"),
                    Board = t.Board.Name,
                    Owner = t.Owner.UserName
                })
                .FirstOrDefaultAsync();

            if (task == null)
            {
                return BadRequest();
            }
            return View(task);
        }

        [HttpGet]
        public async Task<IActionResult> Edit(int id)
        {
            var task = await data.Tasks.FindAsync(id);
            if (task == null)
            {
                return BadRequest();
            }

            string currentUserId = GetUserId();
            if (currentUserId != task.OwnerId)
            {
                return Unauthorized();
            }

            TaskFormModel model = new TaskFormModel()
            {
                Title = task.Title,
                Description = task.Description,
                BoardId = task.BoardId,
                Boards = GetBoards()
            };

            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(int id, TaskFormModel taskModel)
        {
            var task = await data.Tasks.FindAsync(id);
            if (task == null)
            {
                return BadRequest();
            }

            string currentUserId = GetUserId();
            if (currentUserId != task.OwnerId)
            {
                return Unauthorized();
            }

            if (!GetBoards().Any(b => b.Id == taskModel.BoardId))
            {
                ModelState.AddModelError(nameof(taskModel.BoardId), "Board does not exist.");
            }

            if (!ModelState.IsValid)
            {
                taskModel.Boards = GetBoards();
                return View(taskModel);
            }

            task.Title = taskModel.Title;
            task.Description = taskModel.Description;
            task.BoardId = taskModel.BoardId;

            await data.SaveChangesAsync();

            return RedirectToAction("All", "Board");
        }

        [HttpGet]
        public async Task<IActionResult> Delete(int id)
        {
            var task = await data.Tasks.FindAsync(id);
            if (task == null)
            {
                return BadRequest();
            }

            string currentUserId = GetUserId();
            if (currentUserId != task.OwnerId)
            {
                return Unauthorized();
            }

            TaskViewModel taskModel = new TaskViewModel()
            {
                Id = task.Id,
                Title = task.Title,
                Description = task.Description,
            };

            return View(taskModel);
        }

        [HttpPost]
        public async Task<IActionResult> Delete(TaskViewModel taskModel)
        {
            var task = await data.Tasks.FindAsync(taskModel.Id);
            if (task == null)
            {
                return BadRequest();
            }

            string currentUserId = GetUserId();
            if (currentUserId != task.OwnerId)
            {
                return Unauthorized();
            }

            data.Tasks.Remove(task);
            await data.SaveChangesAsync();

            return RedirectToAction("All", "Board");
        }


        private string GetUserId()
            => User.FindFirstValue(ClaimTypes.NameIdentifier) ?? string.Empty;

        private IEnumerable<TaskBoardModel> GetBoards()
            => data.Boards
            .Select(b => new TaskBoardModel()
            {
                Id = b.Id,
                Name = b.Name,
            });
    }
}
