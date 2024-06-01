using Microsoft.EntityFrameworkCore;
using Wordle.Api.Dtos;
using Wordle.Api.Models;

namespace Wordle.Api.Services;

public class WordEditorService(WordleDbContext Db)
{
    public WordleDbContext Db { get; set; } = Db;

    public async Task DeleteWord(string Word)
    {
        Word? word = await Db.Words.FirstOrDefaultAsync(word => word.Text == Word);

        if(word is not null)
        {
            Db.Words.Remove(word);
            await Db.SaveChangesAsync();
        }

    }

    public async Task UpdateWord(WordDto wordToEdit)
    {
        Word? word = await Db.Words.FirstOrDefaultAsync(word => word.Text == wordToEdit.Word);

        if(word is not null)
        {
            word.IsCommonWord = wordToEdit.IsCommonWord;

            await Db.SaveChangesAsync();
        }

    }

    public async Task AddWord(WordDto wordToAdd)
    {
        Word word = new Word()
        {
            Text = wordToAdd.Word,
            IsCommonWord = wordToAdd.IsCommonWord
        };

        Db.Words.Add(word);

        await Db.SaveChangesAsync();
    }

}

