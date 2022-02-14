using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Core.Contracts.Repository;
using Microsoft.EntityFrameworkCore;
using PomeloCase.Core.Entites;
using PomeloCase.Core.Entities;

namespace PomeloCase.Data.Repositories
{
    public class PostRepository : Repository<Post>, IPostRepository
    {
        private DbSet<PostsCategories> _postCatagoriesDbSet;
        private DbSet<Category> _categoryDbSet;
        private DbSet<PostViews> _postViewsDbSet;

        public PostRepository(DatabaseContext context) : base(context)
        {
            _postCatagoriesDbSet = context.Set<PostsCategories>();
            _categoryDbSet = context.Set<Category>();
            _postViewsDbSet = context.Set<PostViews>();
        }

        public async Task<List<Post>> Filter(int page, int size)
        {
            var posts = await _dbset.Where(x =>  !x.IsDeleted).Skip(page * size).OrderByDescending(x => x.CreatedDate).Skip(page * size).Take(size).ToListAsync();

            return posts;
        }

        public  async Task<List<Post>> Filter(int page, int size, Guid categoryId)
        {
            var postIdQuery = _postCatagoriesDbSet.Where(x => x.CategoryId == categoryId).Select(x=>x.PostId);

            var posts = await _dbset.Where(x => postIdQuery.Contains(x.Id) && !x.IsDeleted).OrderByDescending(x=>x.CreatedDate).Skip(page * size).Take(size).ToListAsync();

            return posts;
        }

        public async Task<Dictionary<Post,int>> GetMostPopularPost(int size)
        {
            var posts = await _postViewsDbSet.OrderByDescending(x => x.ViewsCount).Take(size).Join(_dbset,x=>x.PostId,y=>y.Id,(views,post)=>new
            {
                Views = views.ViewsCount,
                Post = post
            }).ToDictionaryAsync(x=>x.Post,y=>y.Views);
            return posts;
        }
    }
}