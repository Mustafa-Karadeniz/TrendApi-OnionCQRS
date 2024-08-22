using TrendApi.Domain.Common;

namespace TrendApi.Domain.Entites;

public class Category : EntityBase
{
    public Category()
    {
        
    }
    public Category(int parentId, string name, int priorty)
    {
        ParentId = parentId;
        Name = name;
        Priorty = priorty;
    }

    public  int ParentId { get; set; }
    public string Name { get; set; }
    public int Priorty { get; set; }

    //one-to-many relationships established(tr:bire çok ilişki kurdum)
    public ICollection<Detail> Details { get; set; }
    public ICollection<ProductCategory> ProductCategories { get; set; }
}
