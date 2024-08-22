using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TrendApi.Domain.Common;

namespace TrendApi.Domain.Entites;

public class ProductCategory :IEntityBase
{
    public int ProductId { get; set; }
    public int CategoryId { get; set; }
    public Product Product { get; set; }
    public Category Category { get; set; }
}
