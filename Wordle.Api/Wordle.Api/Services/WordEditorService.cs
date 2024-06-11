using Wordle.Api.Dtos;
using Wordle.Api.Models;
using Microsoft.EntityFrameworkCore;

public class WordEditorService
{
    private readonly WordleDbContext _context;

    public WordEditorService(WordleDbContext context)
    {
        _context = context;
    }

    public async Task AddWord(WordDto wordDto)
    {
        var word = new Word
        {
            Text = wordDto.Word,
            IsCommon = wordDto.IsCommon
        };
        _context.Words.Add(word);
        await _context.SaveChangesAsync();
    }

    public async Task DeleteWord(string word)
    {
        var wordToDelete = await _context.Words.FirstOrDefaultAsync(w => w.Text == word);
        if (wordToDelete != null)
        {
            _context.Words.Remove(wordToDelete);
            await _context.SaveChangesAsync();
        }
    }

    public async Task UpdateWord(WordDto wordDto)
    {
        var wordToUpdate = await _context.Words.FirstOrDefaultAsync(w => w.Text == wordDto.Word);
        if (wordToUpdate != null)
        {
            wordToUpdate.IsCommon = wordDto.IsCommon;
            await _context.SaveChangesAsync();
        }
    }
}