using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using PomeloCase.Core.Entites;
using PomeloCase.Core.Entities;
using PomeloCase.Data.Repositories;

namespace PomeloCase.Data
{
    public class DataRepository 
    {
        private DatabaseContext _context;
        public DataRepository(DatabaseContext context) 
        
        {
            
            _context = context;
            PostViewsRepository = new Lazy<PostViewsRepository>(() => new PostViewsRepository(_context));
            CategoryRepository = new Lazy<Repository<Category>>(() => new Repository<Category>(_context));
            UserRepository = new Lazy<Repository<User>>(() => new Repository<User>(_context));
            PostRepository = new Lazy<PostRepository>(() => new PostRepository(_context));
            PostCategoriesRepository = new Lazy<BaseRepository<PostsCategories>>(() => new BaseRepository<PostsCategories>(_context));

        }
        public Lazy<PostViewsRepository> PostViewsRepository;

        public Lazy<Repository<User>> UserRepository;
        public Lazy<Repository<Category>> CategoryRepository;
        public Lazy<PostRepository> PostRepository;

        public Lazy<BaseRepository<PostsCategories>> PostCategoriesRepository;
        /*
        public void Dispose()
        {
            while (!_context.Database.CanConnect())
            {

            };
            _context?.Dispose();
        }*/
    }
}
