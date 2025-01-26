namespace papierowyRPG_API.Models;

public class CharacterDTO
{
    public int Id { get; set; }
    public int GameId { get; set; }
    public required string Name { get; set; }
    public required string Description { get; set; }
    public required string Story { get; set; }
    public required int[] Stats { get; set; }
    public required string? NewNote { get; set; }
    public required ItemDTO? NewItem { get; set; }
    public required SkillDTO? NewSkill { get; set; }
}