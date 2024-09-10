using HepsiAPI.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace Persistence.Configurations
{
    public class CategoryConfiguration : IEntityTypeConfiguration<Category>
    {
        public void Configure(EntityTypeBuilder<Category> builder)
        {
            Category caretegory1 = new()
            {
                Id = 1,
                Name = "Elektirik",
                Priorty = 1,
                ParentId = 0,
                IsDeleted = false,
                CreatedDate = DateTime.Now
            };
            Category caretegory2 = new()
            {
                Id = 2,
                Name = "Moda",
                Priorty = 2,
                ParentId = 0,
                IsDeleted = false,
                CreatedDate = DateTime.Now
            };
            Category parent1 = new()
            {
                Id = 3,
                Name = "Bilgisayar",
                Priorty = 1,
                ParentId = 1,
                IsDeleted = false,
                CreatedDate = DateTime.Now
            };
            Category parent2 = new()
            {
                Id = 4,
                Name = "Kadın",
                Priorty = 1,
                ParentId = 2,
                IsDeleted = false,
                CreatedDate = DateTime.Now
            };
            builder.HasData(caretegory1, caretegory2, parent1, parent2);
        }
    }
}
