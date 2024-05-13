using Wordle.Api.Models;
using Wordle.Api.Services;
using Wordle.Api.Data;

namespace Wordle.Api;
public static class Seeder
{
    public static async Task Seed(AppDbContext db)
    {
        if (!db.Words.Any())
        {
            foreach(var word in WordOfTheDayService.WordList())
            {
                db.Words.Add(new Word() { Text = word });
            }

            await db.SaveChangesAsync();
        }
    }
}
