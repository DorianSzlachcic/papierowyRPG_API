using Microsoft.EntityFrameworkCore;
using papierowyRPG_API.Database;
using papierowyRPG_API.Models;

namespace papierowyRPG_API.Services;

public class CharacterService(UserContext context) : ICharacterService, IDisposable
{
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