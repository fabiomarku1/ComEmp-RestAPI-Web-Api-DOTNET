using System.ComponentModel.DataAnnotations;

namespace Shared.DTO;

public abstract record CompanyForManipulationDto
{
    [Required]
    [MaxLength(20, ErrorMessage = "Maximum length is 20 characters")]
    public string? Name { get; init; }

    [Required]
    [MaxLength(20, ErrorMessage = "Maximum length is 20 characters")]
    public string? Address { get; init; }

    [Required]
    [MaxLength(20, ErrorMessage = "Maximum length is 20 characters")]
    public string? Country { get; init; }


    public IEnumerable<EmployeeForCreationDto>? Employees { get; init; }
}