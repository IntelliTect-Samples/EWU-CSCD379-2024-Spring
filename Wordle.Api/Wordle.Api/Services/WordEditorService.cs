using Microsoft.EntityFrameworkCore;
using Wordle.Api.Dtos;
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
    
    public async Task<(List<WordDto>, int TotalCount)> GetWordsAsync(string search, int page, int itemsPerPage, bool isCommonFilter)
    {

        var query = Db.Words.AsQueryable();

        if (!string.IsNullOrEmpty(search))
        {
            query = query.Where(w => w.Text.Contains(search.ToLower()));
        }

        if (isCommonFilter)
        {
            query = query.Where(w => w.IsCommon);
        }

        var totalCount = await query.CountAsync();
        var words = await query
            .Skip((page - 1) * itemsPerPage)
            .Take(itemsPerPage)
            .Select(w => new WordDto { Text = w.Text, IsCommon = w.IsCommon })
            .ToListAsync();

        return (words, totalCount);
    }
    
    public async Task<bool> SetIsCommonAsync(string word, bool isCommon)
    {
        var wordToEdit = await Db.Words.FirstOrDefaultAsync(w => string.Equals(w.Text, word.ToLower()));
        if (wordToEdit == null)
        {
            return false;
        }

        wordToEdit.IsCommon = isCommon;
        await Db.SaveChangesAsync();
        return true;
    }
}