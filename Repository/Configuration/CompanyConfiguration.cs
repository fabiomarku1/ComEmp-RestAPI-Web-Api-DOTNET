using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entities.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Repository.Configuration
{ 
    public class CompanyConfiguration : IEntityTypeConfiguration<Company>
    {
        public void Configure(EntityTypeBuilder<Company> builder)
        {
            builder.HasData(
                new Company
                {
                    Id= 11,
                    Name="Fabio",
                    Address = "Lezhe",
                    Country = "Albania"
                },
                new Company
                {
                    Id = 22,
                    Name = "Marku",
                    Address = "Tirane",
                    Country = "Albania"
                }
            );

        }
    }
}
