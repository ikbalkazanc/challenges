using System;
using Coredet.Core.Entities;
using Microsoft.EntityFrameworkCore;

namespace Coredet.Data.Seed
{
    public class ProductSeed : IEntityTypeConfiguration<Product>
    {
        public ProductSeed()
        {

        }
        public void Configure(Microsoft.EntityFrameworkCore.Metadata.Builders.EntityTypeBuilder<Product> builder)
        {
            builder.HasData(
                new Product { Id = Guid.NewGuid(), Name = "Beygir At", Price = 50,ImageUrl = "https://cdn.britannica.com/96/1296-050-4A65097D/gelding-bay-coat.jpg", IsDeleted = false, CreatedDate = DateTime.UtcNow },
                new Product { Id = Guid.NewGuid(), Name = "Safkan Arap At", Price = 50, ImageUrl = "https://cdn.britannica.com/96/1296-050-4A65097D/gelding-bay-coat.jpg", IsDeleted = false, CreatedDate = DateTime.UtcNow },
                new Product { Id = Guid.NewGuid(), Name = "Alaca Kısrak At", Price = 50, ImageUrl = "https://cdn.britannica.com/96/1296-050-4A65097D/gelding-bay-coat.jpg", IsDeleted = false, CreatedDate = DateTime.UtcNow },
                new Product { Id = Guid.NewGuid(), Name = "Rahvan At", Price = 50, ImageUrl = "https://media.gq.com/photos/56e71c0b14cbe0637b261d7f/4:3/w_2260,h_1695,c_limit/horseinsuit2.jpg", IsDeleted = false, CreatedDate = DateTime.UtcNow },
                new Product { Id = Guid.NewGuid(), Name = "Doru At", Price = 50, ImageUrl = "https://cdn.britannica.com/96/1296-050-4A65097D/gelding-bay-coat.jpg", IsDeleted = false, CreatedDate = DateTime.UtcNow },
                new Product { Id = Guid.NewGuid(), Name = "Şişme Mont At", Price = 50, ImageUrl = "http://cdn.shopify.com/s/files/1/0420/2528/7847/products/Horse-Rug-Liner-Black-Test.jpg?v=1631720831", IsDeleted = false, CreatedDate = DateTime.UtcNow },
                new Product { Id = Guid.NewGuid(), Name = "Binek At At", Price = 50, ImageUrl = "https://cdn.britannica.com/96/1296-050-4A65097D/gelding-bay-coat.jpg", IsDeleted = false, CreatedDate = DateTime.UtcNow },
                new Product { Id = Guid.NewGuid(), Name = "Tinker Güzeli At", Price = 50, ImageUrl = "https://cdn.britannica.com/96/1296-050-4A65097D/gelding-bay-coat.jpg", IsDeleted = false, CreatedDate = DateTime.UtcNow },
                new Product { Id = Guid.NewGuid(), Name = "Kör At", Price = 50, ImageUrl = "https://www.horze.eu/dw/image/v2/AATB_PRD/on/demandware.static/-/Sites-hz-master-catalog/default/dwa5525f47/Harryshorse/331637_BL.jpg?sw=1600&sh=1600&q=100", IsDeleted = false, CreatedDate = DateTime.UtcNow },
                new Product { Id = Guid.NewGuid(), Name = "Midilli At", Price = 50, ImageUrl = "https://cdn.britannica.com/96/1296-050-4A65097D/gelding-bay-coat.jpg", IsDeleted = false, CreatedDate = DateTime.UtcNow },
                new Product { Id = Guid.NewGuid(), Name = "Beygir", Price = 50, ImageUrl = "https://cdn.britannica.com/96/1296-050-4A65097D/gelding-bay-coat.jpg", IsDeleted = false, CreatedDate = DateTime.UtcNow }
            );
        }
    }
}