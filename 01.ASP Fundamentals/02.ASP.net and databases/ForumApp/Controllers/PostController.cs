using ForumApp.Core.Contracts;
using ForumApp.Core.Models;
using Microsoft.AspNetCore.Mvc;

namespace ForumApp.Controllers
{
    public class PostController : Controller
    {
        private readonly IPostService postService;

        public PostController(IPostService _postService)
        {
            postService = _postService;
        }
        public async Task<IActionResult> Index()
        {
            IEnumerable<PostModel> models = await postService.GetAllPostsAsync();

            return View(models);
        }

        public IActionResult Add() => View();

        [HttpPost]
        public async Task<IActionResult> Add(PostModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            try
            {
                await postService.AddAsync(model);
            }
            catch (Exception)
            {

                ModelState.AddModelError(string.Empty, "Unexpected error occured, please try again!");
                return View(model);
            }

            return RedirectToAction(nameof(Index));
        }

        public async Task<IActionResult> Edit(string id)
        {
            PostModel? model = await postService.GetByIdAsync(id);

            if (model == null)
            {
                ModelState.AddModelError(string.Empty, "Invalid post!");
            }

            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(PostModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            try
            {
                await postService.EditAsync(model);
            }
            catch (Exception)
            {

                ModelState.AddModelError(string.Empty, "Unexpected error occured!");
                return View(model);
            }

            return RedirectToAction(nameof(Index));
        }

        public async Task<IActionResult> Delete(string id)
        {
            await postService.DeleteAsync(id);

            return RedirectToAction(nameof(Index));
        }
    }
}
