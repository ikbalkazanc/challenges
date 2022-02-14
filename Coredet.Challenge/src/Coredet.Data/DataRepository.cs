using System;
using System.Data;
using Data.Repository;
using Microsoft.EntityFrameworkCore;

namespace Coredet.Data.Repository
{
    public class DataRepository
    {
        private CoredetContext _context;
        public DataRepository(CoredetContext context)
        {
            _context = context;
            UserRepository = new Lazy<UserRepository>(() => new UserRepository(_context));
            ProductRepository = new Lazy<ProductRepository>(() => new ProductRepository(_context));
            BasketRepository = new Lazy<BasketRepository>(() => new BasketRepository(_context));
            BasketProductsRepository = new Lazy<BasketProductsRepository>(() => new BasketProductsRepository(_context));

        }

        public Lazy<UserRepository> UserRepository;
        public Lazy<ProductRepository> ProductRepository;
        public Lazy<BasketRepository> BasketRepository;
        public Lazy<BasketProductsRepository> BasketProductsRepository;
    }
}
