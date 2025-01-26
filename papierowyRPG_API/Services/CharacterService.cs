using Microsoft.EntityFrameworkCore;
using papierowyRPG_API.Database;
using papierowyRPG_API.Models;

namespace papierowyRPG_API.Services;

public class CharacterService(UserContext context) : ICharacterService, IDisposable
{
    public Character? GetCharacter(int UserId, int GameId)
    {
        var characterEntity = from character in context.Characters
            where character.Game.ID == GameId && character.User.ID == UserId
                select character;
        try
        {
            return characterEntity.Single();

        }
        catch (InvalidOperationException)
        {
            return null;
        }
    }

    public bool EditCharacter(Character character)
    {
        context.Characters.Update(character);
        try
        {
            context.SaveChanges();
        }
        catch (DbUpdateException)
        {
            return false;
        }
        return true;
    }

    public void Dispose()
    {
        Dispose(true);
        GC.SuppressFinalize(this);
    }

    private void Dispose(bool disposing)
    {
        if (disposing)
        {
            context.Dispose();
        }
    }
}