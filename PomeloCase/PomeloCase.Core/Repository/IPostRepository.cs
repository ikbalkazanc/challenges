using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using PomeloCase.Core.Entites;

namespace Core.Contracts.Repository
{
    public interface IPostRepository : IRepository<Post>
    {
        Task<List<Post>> Filter(int page, int size);
        Task<List<Post>> Filter(int page, int size, Guid categoryId);

        Task<Dictionary<Post, int>> GetMostPopularPost(int size);
    }
}