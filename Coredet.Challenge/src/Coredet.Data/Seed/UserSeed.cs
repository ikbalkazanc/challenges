using System;
using Coredet.Core.Entities;
using Microsoft.EntityFrameworkCore;

namespace Coredet.Data.Seed
{
    public class UserSeed : IEntityTypeConfiguration<User>
    {
    public UserSeed()
    {
      
    }
    public void Configure(Microsoft.EntityFrameworkCore.Metadata.Builders.EntityTypeBuilder<User> builder)
    {
        builder.HasData(
            new User { Id = Guid.NewGuid(), Name = "ikbalkazanc", Password = "123",IsDeleted = false,CreatedDate = DateTime.UtcNow}
        );
    }
    }
}