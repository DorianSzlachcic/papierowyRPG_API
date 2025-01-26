using papierowyRPG_API.Models;

namespace papierowyRPG_API.Services;

public interface ICharacterService
{
    public Character? GetCharacter(int UserId, int GameId);
    public bool EditCharacter(Character character);
}