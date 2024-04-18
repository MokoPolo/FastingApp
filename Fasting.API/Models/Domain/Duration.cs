namespace Fasting.API.Models.Domain;

public class Duration
{
    public int Id { get; set; }
    public int Length { get; set; }

    public required string Name { get; set; }
}
