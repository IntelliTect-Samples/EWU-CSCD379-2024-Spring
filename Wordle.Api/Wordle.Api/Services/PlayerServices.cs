using Microsoft.EntityFrameworkCore;
using Wordle.Api.Models;

namespace Wordle.Api.Services
{
    public class PlayerServices(WordleDbContext Db)
    {
        private static object _lock = new();
        public WordleDbContext Db { get; set; } = Db;


        public async Task AddPlayer(string name, int attempts)
        {
            Player? player = await Db.Players.FirstOrDefaultAsync(player => player.Name == name);

            if (player is null) {
                lock (_lock)
                {
                    player = new()
                    {
                        Name = name,
                        GameCount = 1,
                        AverageAttempts = attempts
                    };

                    Db.Players.Add(player);
                }

            }
            else
            {
                player.GameCount++;
                player.AverageAttempts = (attempts + player.AverageAttempts) / (player.GameCount);
            }
            Db.SaveChanges();

        }

        public  IEnumerable<Player> TopTenPlayers(){

            return Db.Players.OrderBy(player => player.AverageAttempts).ThenBy(player => player.GameCount).Take(10);

            }
}

}
