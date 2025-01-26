namespace papierowyRPG_API.Models;

public class SkillDTO
{
    public required string Name { get; set; }
    public required string Description { get; set; }
    public required int[] Stats { get; set; }
}