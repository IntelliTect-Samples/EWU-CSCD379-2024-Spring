using Azure.Core;
using Microsoft.EntityFrameworkCore;
using Wordle.Api.Dtos;
using Wordle.Api.Models;

namespace Wordle.Api.Services;

public class WordDateService(WordleDbContext Db)
{

    public async Task<WordDate?> GetWordDate(string date)
    {
        return await Db.WordDates.FirstOrDefaultAsync(p => p.Date == date);
    }

    public async Task AddWordDate(WordDateDTO wordDateDTO)
    {
	    WordDate? existingWordDate = Db.WordDates.FirstOrDefault(wordDate => wordDate.Date == wordDateDTO.Date);

	    if (existingWordDate != null)
	    {   //GameCount, AverageAttempts, AverageSeconds, PlayerList
            wordDateDTO.GameCount = existingWordDate.GameCount + 1;
            wordDateDTO.AverageAttempts = (((existingWordDate.AverageAttempts * existingWordDate.GameCount) + wordDateDTO.AverageAttempts)/ wordDateDTO.GameCount);
            wordDateDTO.AverageSeconds = (((existingWordDate.AverageSeconds * existingWordDate.GameCount) + wordDateDTO.AverageSeconds) / wordDateDTO.GameCount);
            //string name = wordDateDTO.PlayerList[0];
            //wordDateDTO.PlayerList = existingWordDate.PlayerList;
            //wordDateDTO.PlayerList.push(name);
		    Db.WordDates.Entry(existingWordDate).CurrentValues.SetValues(wordDateDTO);
	    }
	    else
	    {
		    WordDate wordDate = new()
		    {
			    Date = wordDateDTO.Date,
			    GameCount = wordDateDTO.GameCount,
			    AverageAttempts = wordDateDTO.AverageAttempts,
			    AverageSeconds = wordDateDTO.AverageSeconds,
                //PlayerList = wordDateDTO.PlayerList
		    };
		    await Db.WordDates.AddAsync(wordDate);
	    }
	    
	    await Db.SaveChangesAsync();

    }
    
    public async Task<WordDate[]> GetRecentWordDates(int numberOfWordDates)
    {
        return await Db.WordDates.OrderBy(p => p.Date).Take(numberOfWordDates).ToArrayAsync();
    }
}