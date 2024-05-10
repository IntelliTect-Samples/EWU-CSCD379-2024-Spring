using Microsoft.EntityFrameworkCore;
using Wordle.Api.Dtos;
using Wordle.Api.Models;

namespace Wordle.Api.Services
{
    public class PlayerServices(WordleDbContext Db)
    {
        private static object _lock = new();
        public WordleDbContext Db { get; set; } = Db;


        public async Task SavePlayer(Score score)
        {
            Player? player = await Db.Players.FirstOrDefaultAsync(player => player.Name == score.Name);

            if (player is null) {
                lock (_lock)
                {
                    player = new()
                    {
                        Name = score.Name,
                        GameCount = 1,
                        AverageAttempts = score.Attempts,
                        AverageSeconds = score.Seconds
                    };

                    Db.Players.Add(player);
                }

            }
            else
            {
                player.GameCount++;
                player.AverageAttempts = (score.Attempts + player.AverageAttempts) / (player.GameCount);
                player.AverageSeconds = (score.Seconds + player.AverageSeconds) / (player.GameCount);
            }
            Db.SaveChanges();

        }

        public  IEnumerable<PlayerDto> TopTenPlayers(){

            return Db.Players.OrderBy(player => player.AverageAttempts).ThenBy(player => player.GameCount).ThenBy(player => player.AverageSeconds).Select(player =>
            new PlayerDto()
            { Name = player.Name, GameCount = player.GameCount, AverageAttempts = player.AverageAttempts, AverageSeconds = player.AverageSeconds }).Take(10);

            }
}

}
