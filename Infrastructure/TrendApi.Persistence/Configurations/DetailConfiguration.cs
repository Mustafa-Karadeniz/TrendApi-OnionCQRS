using Bogus;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TrendApi.Domain.Entites;

namespace TrendApi.Persistence.Configurations;

public class DetailConfiguration : IEntityTypeConfiguration<Detail>
{
    public void Configure(EntityTypeBuilder<Detail> builder)
    {
        Faker faker = new("tr");
        Detail detail1 = new()
        {
            Id = 1,
            Title = faker.Lorem.Sentences(1),
            Description = faker.Lorem.Sentences(5),
            CategoryId = 1,
            CreatedDate = DateTime.Now,
            IsDeleted = false,
        };
        Detail detail2 = new()
        {
            Id = 2,
            Title = faker.Lorem.Sentences(2),
            Description = faker.Lorem.Sentences(3),
            CategoryId = 3,
            CreatedDate = DateTime.Now,
            IsDeleted = false,
        };
        Detail detail3 = new()
        {
            Id = 3,
            Title = faker.Lorem.Sentences(3),
            Description = faker.Lorem.Sentences(4),
            CategoryId = 4,
            CreatedDate = DateTime.Now,
            IsDeleted = false,
        };
        builder.HasData(detail1, detail2, detail3);
    }
}
