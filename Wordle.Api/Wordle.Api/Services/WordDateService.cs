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
	    {
            if(wordDateDTO.GameCount != 0){
                //GameCount, AverageAttempts, AverageSeconds, PlayerList
                wordDateDTO.GameCount = existingWordDate.GameCount + 1;
                wordDateDTO.AverageAttempts = (((existingWordDate.AverageAttempts * existingWordDate.GameCount) + wordDateDTO.AverageAttempts)/ wordDateDTO.GameCount);
                wordDateDTO.AverageSeconds = (((existingWordDate.AverageSeconds * existingWordDate.GameCount) + wordDateDTO.AverageSeconds) / wordDateDTO.GameCount);
                //string name = wordDateDTO.PlayerList[0];
                //wordDateDTO.PlayerList = existingWordDate.PlayerList;
                //wordDateDTO.PlayerList.push(name);
                Db.WordDates.Entry(existingWordDate).CurrentValues.SetValues(wordDateDTO);
            }
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
        DateTime dateTime = DateTime.UtcNow.Date;
        string curDate = dateTime.Month + "/" + dateTime.Day + "/" + dateTime.Year;
        for(int i = 0; i<10; i++){
            string newDate = getPreviousDate(curDate, i);
            WordDateDTO wordDate = new()
            {
                Date = newDate,
                GameCount = 0,
                AverageAttempts = 0,
                AverageSeconds = 0,
                //PlayerList = wordDateDTO.PlayerList
            };
            await AddWordDate(wordDate);
        }
        return await Db.WordDates.OrderByDescending(p => p.Date).Take(numberOfWordDates).ToArrayAsync();
    }

    private string getPreviousDate(string date, int offset){
        string[] curDate = date.Split("/");
        int month = Int32.Parse(curDate[0]);
        int day = Int32.Parse(curDate[1]);
        int year = Int32.Parse(curDate[2]);
        if((day - offset) < 1){
            month -= 1;
            day = day + 30 - offset;
        }
        else{
            day -= offset;
        }
        return month +"/" + day +"/" + year;
    }
}