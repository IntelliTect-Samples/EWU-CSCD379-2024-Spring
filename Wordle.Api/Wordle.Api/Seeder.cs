using Wordle.Api.Models;
using Wordle.Api.Services;
using System.Threading.Tasks;

namespace Wordle.Api
{
    public static class Seeder
    {
        public static async Task SeedAsync(WordleDbContext db)
        {
            if (!db.Words.Any())
            {
                foreach (var word in WordOfTheDayService.WordList())
                {
                    db.Words.Add(new Word { Text = word });
                }

                await db.SaveChangesAsync();
            }
        }
    }
}