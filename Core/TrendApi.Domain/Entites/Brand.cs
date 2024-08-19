﻿
using TrendApi.Domain.Common;

namespace TrendApi.Domain.Entites
{
    public class Brand : EntityBase
    {
        public Brand()
        {
            
        }
        public Brand(string name)
        {
            Name = name;
        }
        public required string Name { get; set; }
    }
}