using System;
using System.Linq;
using System.Threading.Tasks;
using Wordle.Api.Models;
using Wordle.Api.Services;

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

            if (!db.WordsOfTheDays.Any())
            {
                var words = db.Words.ToList();
                foreach (var word in words)
                {
                    db.WordsOfTheDays.Add(new WordOfTheDay { WordId = word.WordId, Date = DateOnly.FromDateTime(DateTime.UtcNow.AddDays(-words.IndexOf(word))) });
                }
                await db.SaveChangesAsync();
            }

            if (!db.Players.Any())
            {
                var players = new[]
                {
                    new Player { Name = "Gandalf", GameCount = 10, AverageAttempts = 1.2, AverageSecondsPerGame = 120 },
                    new Player { Name = "Aragorn", GameCount = 8, AverageAttempts = 4.1, AverageSecondsPerGame = 140 },
                    new Player { Name = "Legolas", GameCount = 12, AverageAttempts = 2.9, AverageSecondsPerGame = 110 },
                    new Player { Name = "Frodo", GameCount = 9, AverageAttempts = 3.0, AverageSecondsPerGame = 130 },
                    new Player { Name = "Merlin", GameCount = 15, AverageAttempts = 1.6, AverageSecondsPerGame = 115 },
                    new Player { Name = "Elminster", GameCount = 11, AverageAttempts = 2.8, AverageSecondsPerGame = 125 },
                    new Player { Name = "Drizzt", GameCount = 13, AverageAttempts = 3.4, AverageSecondsPerGame = 120 },
                    new Player { Name = "Harry", GameCount = 10, AverageAttempts = 3.6, AverageSecondsPerGame = 122 },
                    new Player { Name = "Gimli", GameCount = 7, AverageAttempts = 4.0, AverageSecondsPerGame = 150 },
                    new Player { Name = "Ron", GameCount = 8, AverageAttempts = 4.6, AverageSecondsPerGame = 145 }
                };

                db.Players.AddRange(players);
                await db.SaveChangesAsync();
            }

            if (!db.Games.Any())
            {
                var wordsOfTheDay = db.WordsOfTheDays.ToList();
                var players = db.Players.ToList();
                var random = new Random();

                foreach (var player in players)
                {
                    for (int i = 0; i < player.GameCount; i++)
                    {
                        var wordOfTheDay = wordsOfTheDay[random.Next(wordsOfTheDay.Count)];
                        var game = new Game
                        {
                            Attempts = random.Next(1, 7),
                            IsWin = random.Next(0, 2) == 1,
                            DateAttempted = DateTime.UtcNow.AddDays(-random.Next(1, 30)),
                            WordId = wordOfTheDay.WordId,
                            WordOfTheDayId = wordOfTheDay.WordOfTheDayId,
                        };
                        db.Games.Add(game);
                    }
                }

                await db.SaveChangesAsync();
            }
        }
    }
}
