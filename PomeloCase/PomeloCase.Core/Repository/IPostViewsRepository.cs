using System;
using System.Threading.Tasks;
using PomeloCase.Core.Entities;

namespace Core.Contracts.Repository
{
    public interface IPostViewsRepository : IRepository<PostViews>
    {
        Task<PostViews> View(Guid PostId);
    }
}