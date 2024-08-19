using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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
