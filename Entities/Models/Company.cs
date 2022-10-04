using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Models
{
    public class Company
    {
        [Column("CompanyId")]
        public int Id { get; set; }

        [Required(ErrorMessage ="Company name is required")]
        [MaxLength(60,ErrorMessage = "Maximum name length is 60 char")]
        public string? Name { get; set; }

        [Required(ErrorMessage = "Company address is required")]
        [MaxLength(60,ErrorMessage= "Maximum length for address is 60 char")]
        public string? Address { get; set; }
        public string? Country { get; set; }
        public DateTime DateCreated { get; set; } = DateTime.Now;

        public ICollection<Employee>? Employees { get; set; }

    }
}
