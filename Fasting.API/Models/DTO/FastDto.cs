namespace Fasting.API.Models.Dto;

public class FastDto
{
    public required DateTime Start { get; set; }

    // public DateTime End { get; set; }
    public required int Duration { get; set; }

    public required int Id { get; set; }
}
