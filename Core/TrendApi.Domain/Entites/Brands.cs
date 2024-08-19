
using TrendApi.Domain.Common;

namespace TrendApi.Domain.Entites
{
    public class Brands : EntityBase
    {
        public Brands()
        {
            
        }
        public Brands(string name)
        {
            Name = name;
        }
        public required string Name { get; set; }
    }
}
