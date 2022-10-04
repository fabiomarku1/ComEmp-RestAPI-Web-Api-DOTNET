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
    public class EmployeeConfiguration:IEntityTypeConfiguration<Employee>
    {
        public void Configure(EntityTypeBuilder<Employee> builder)
        {
            builder.HasData(
                new Employee
                {
                    Id=1,
                    Name = "Fabio Marku",
                    Age = 21,
                    Position = "DIRECTOR",
                    CompanyId = 11
                },
                new Employee
                {
                    Id=2,
                    Name = "MarkuFabio",
                    Age = 24,
                    Position = "Employee",
                    CompanyId = 22,
                }
                
                );


        }
    }
}
