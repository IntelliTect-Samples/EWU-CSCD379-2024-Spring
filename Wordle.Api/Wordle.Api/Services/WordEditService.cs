using Microsoft.EntityFrameworkCore;
using Wordle.Api.Dtos;
using Wordle.Api.Models;

namespace Wordle.Api.Services;

public class WordEditService(WordleDbContext Db)
{
    public WordleDbContext Db { get; set; } = Db;

    public async Task AddWord(WordDto wordToAdd)
    {
        if (wordToAdd.Word.Length != 5)
        {
            return;
        }

        Word word = new Word()
        {
            Text = wordToAdd.Word,
            IsCommon = wordToAdd.IsCommon
        };

        Db.Words.Add(word);

        await Db.SaveChangesAsync();
    }

    public async Task RemoveWord(string wordToRemove)
    {
        Word? word = await Db.Words.FirstOrDefaultAsync(word => word.Text.ToLower() == wordToRemove.ToLower());

        if(word is not null)
        {
            Db.Words.Remove(word);
            await Db.SaveChangesAsync();
        }

    }

    public async Task UpdateWord(WordDto wordToUpdate)
    {
        Word? word = await Db.Words.FirstOrDefaultAsync(word => word.Text.ToLower() == wordToUpdate.Word.ToLower());

        if (word is not null)
        {
            word.IsCommon = wordToUpdate.IsCommon;

            await Db.SaveChangesAsync();
        }

    }
}

