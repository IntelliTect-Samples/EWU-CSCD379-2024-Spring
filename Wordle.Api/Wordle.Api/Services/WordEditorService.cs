using Microsoft.EntityFrameworkCore;
using Wordle.Api.Models;

namespace Wordle.Api.Services;

public class WordEditorService(WordleDbContext Db) 
{
    public async Task<bool> DeleteWordAsync(string word)
    {
        var wordToDelete = await Db.Words.FirstOrDefaultAsync(w => string.Equals(w.Text, word.ToLower()));
        if (wordToDelete == null)
        {
            return false;
        }

        Db.Words.Remove(wordToDelete);
        await Db.SaveChangesAsync();
        return true;
    }
    
    public async Task<bool> AddWordAsync(string word)
    {
        if ( word.Length != 5 || await Db.Words.AnyAsync(w => string.Equals(w.Text, word.ToLower())))
        {
            return false;
        }
        
        var wordToAdd = new Word { Text = word.ToLower() };
        await Db.Words.AddAsync(wordToAdd);
        await Db.SaveChangesAsync();
        return true;
    }
}