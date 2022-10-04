using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Models
{
    public class Employee
    {
        [Column("EmployeeId")]
        public int Id { get; set; }

        [Required(ErrorMessage = "Employee name is required")]
        [MaxLength(20,ErrorMessage = "Maximum length name is 30 characters")]
        public string? Name { get; set; }

        [Required(ErrorMessage = "Age is a required field")]
        public int Age { get; set; }

        [Required(ErrorMessage = "Position is a required field")]
        [MaxLength(20,ErrorMessage = "Maximum length for the position is 20 char")]
        public string? Position { get; set; }


        [ForeignKey(nameof(Company))]
        public int CompanyId { get; set; }
        public Company? Company { get; set; }
    }
}
