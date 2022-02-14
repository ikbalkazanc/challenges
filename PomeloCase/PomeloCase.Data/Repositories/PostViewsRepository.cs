using System;
using System.Linq;
using System.Threading.Tasks;
using Core.Contracts.Repository;
using Microsoft.EntityFrameworkCore;
using PomeloCase.Core.Entities;

namespace PomeloCase.Data.Repositories
{
    public class PostViewsRepository : BaseRepository<PostViews>, IPostViewsRepository
    {
        public PostViewsRepository(DatabaseContext context) : base(context)
        {
            
        }

        public async Task<PostViews> View(Guid PostId)
        {
            var views = await _dbset.Where(x => x.PostId == PostId).FirstOrDefaultAsync();
            if (views == null)
            {
                views = new PostViews()
                {
                    Id = new Guid(),
                    ViewsCount = 1,
                    PostId = PostId
                };

                await this.AddAsync(views);
                
            }
            else
            {
                views.ViewsCount++;
                await this.Update(views);
            }

            return views;
        }
    }
}