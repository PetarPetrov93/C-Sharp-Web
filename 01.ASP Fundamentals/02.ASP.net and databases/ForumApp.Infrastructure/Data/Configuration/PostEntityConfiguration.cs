using ForumApp.Infrastructure.Data.Models;
using ForumApp.Infrastructure.Data.Seeding;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ForumApp.Infrastructure.Data.Configuration
{
    public class PostEntityConfiguration : IEntityTypeConfiguration<Post>
    {
        private PostSeeder postseeder;

        public PostEntityConfiguration()
        {
            postseeder = new PostSeeder();
        }
        public void Configure(EntityTypeBuilder<Post> builder)
        {
            builder.HasData(postseeder.GeneratePosts());
        }
    }
}
