using Bogus;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TrendApi.Domain.Entites;


namespace TrendApi.Persistence.Configurations;

public class BrandConfiguration : IEntityTypeConfiguration<Brands>
{
    public void Configure(EntityTypeBuilder<Brands> builder)
    {
        builder.Property(x => x.Name).HasMaxLength(256);
        

        Faker faker = new("tr");
        Brands brand1 = new()
        {
            Id = 1,
            Name = faker.Commerce.Department(),
            CreatedDate = DateTime.Now,
            IsDeleted = false
        };
        Brands brand2 = new()
        {
            Id = 1,
            Name = faker.Commerce.Department(),
            CreatedDate = DateTime.Now,
            IsDeleted = false
        };
        Brands brand3 = new()
        {
            Id = 1,
            Name = faker.Commerce.Department(),
            CreatedDate = DateTime.Now,
            IsDeleted = true
        };
        builder.HasData(brand1,brand2,brand3);
    }
}
