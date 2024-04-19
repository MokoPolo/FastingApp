using System.ComponentModel.DataAnnotations;

namespace Fasting.API.Models.Dto;

public class DurationDto
{
    public int Id { get; set; }
    public int Length { get; set; }

    [Required]
    public required string Name { get; set; }
}
