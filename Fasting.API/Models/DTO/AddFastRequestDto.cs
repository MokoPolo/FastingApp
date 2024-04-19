using System.ComponentModel.DataAnnotations;
using Fasting.API.Models.Dto;

namespace Fasting.API.Models.Dto;

public class AddFastRequestDto
{
    [Required]
    public DateTime Start { get; set; }

    // public DateTime End { get; set; }
    [Required]
    public int Duration { get; set; }
    // public int Id { get; set; }
}
