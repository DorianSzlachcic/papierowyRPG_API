namespace papierowyRPG_API.Models;

public class ItemDTO
{
    public required string Name { get; set; }
    public required string Description { get; set; }
    public int[] Stats { get; set; }
}