using ForumApp.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ForumApp.Core.Contracts
{
    public interface IPostService
    {
        Task<IEnumerable<PostModel>> GetAllPostsAsync();
        Task AddAsync(PostModel model);
        Task<PostModel?> GetByIdAsync(string id);
        Task EditAsync(PostModel model);
        Task DeleteAsync(string id);
    }
}
