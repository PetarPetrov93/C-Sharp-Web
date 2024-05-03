using ForumApp.Core.Contracts;
using ForumApp.Core.Models;
using ForumApp.Infrastructure.Data;
using ForumApp.Infrastructure.Data.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace ForumApp.Core.Services
{
    public class PostService : IPostService
    {
        private readonly ForumAppDbContext context;

        public PostService(ForumAppDbContext _context)
        {
            context = _context;
        }

        public async Task<IEnumerable<PostModel>> GetAllPostsAsync()
        {
            return await context.Posts
                .Select(p => new PostModel() 
                {
                    Id = p.Id.ToString(),
                    Title = p.Title,
                    Content = p.Content
                })
                .AsNoTracking()
                .ToListAsync();
        }
        public async Task AddAsync(PostModel model)
        {
            var entity = new Post()
            {
                Title = model.Title,
                Content = model.Content
            };

            await context.Posts.AddAsync(entity);
            await context.SaveChangesAsync();
        }

        public async Task<PostModel?> GetByIdAsync(string id)
        {
            return await context.Posts
                .Where(p => p.Id.ToString() == id)
                .Select(p => new PostModel()
                {
                    Id = p.Id.ToString(),
                    Title = p.Title,
                    Content = p.Content
                })
                .AsNoTracking()
                .FirstOrDefaultAsync();
        }

        public async Task EditAsync(PostModel model)
        {
            Post entity = await context.Posts
                .FirstAsync(p => p.Id.ToString().Equals(model.Id));

            entity.Title = model.Title;
            entity.Content = model.Content;

            await context.SaveChangesAsync();
        }

        public async Task DeleteAsync(string id)
        {
            Post entity = await context.Posts.FirstOrDefaultAsync(p => p.Id.ToString() == id);

            if (entity == null)
            {
                throw new ApplicationException("Invalid Post!");
            }

            context.Posts.Remove(entity);
            await context.SaveChangesAsync();
        }
    }
}
