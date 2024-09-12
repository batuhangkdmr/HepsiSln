﻿using HepsiAPI.Domain.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HepsiAPI.Domain.Entities
{
    public class Category: EntityBase,IEntityBase
    {
        public Category()
        {
            
        }
        public Category(int parentId, string name, int priory)
        {
            ParentId = parentId;
            Name = name;
            Priory = priory;
        }
        public  int ParentId { get; set; }
        public  string Name { get; set; }
        public  int Priorty { get; set; }
        public int Priory { get; }
        public ICollection<Detail> Details { get; set; }
        public ICollection<Product> Products { get; set; }
    }
}
