using ForumApp.Infrastructure.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ForumApp.Infrastructure.Data.Seeding
{
    internal class PostSeeder
    {
        internal Post[] GeneratePosts()
        {
            ICollection<Post> posts = new HashSet<Post>();
            Post currentPost;

            currentPost = new Post()
            {
                Title = "My first post",
                Content = "This is the content of my first post."
            };
            posts.Add(currentPost);

            currentPost = new Post()
            {
                Title = "My second post",
                Content = "This is the content of my second post."
            };
            posts.Add(currentPost);

            currentPost = new Post()
            {
                Title = "My third post",
                Content = "This is the content of my third post."
            };
            posts.Add(currentPost);

            return posts.ToArray();
        }
    }
}
