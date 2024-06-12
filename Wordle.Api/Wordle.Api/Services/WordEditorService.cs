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
        if (_context.Words.Any(w => w.Text == wordDto.Word))
        {
            throw new InvalidOperationException("Word already exists.");
        }

        var word = new Word
        {
            Text = wordDto.Word,
            IsCommon = wordDto.IsCommon
        };
        _context.Words.Add(word);
        await _context.SaveChangesAsync();
    }

    public async Task<Word?> DeleteWordById(int id)
    {
        var wordToDelete = await _context.Words.FindAsync(id);
        if (wordToDelete != null)
        {
            _context.Words.Remove(wordToDelete);
            await _context.SaveChangesAsync();
        }
        return wordToDelete;
    }

    public async Task<Word?> UpdateWord(int id, WordDto wordDto)
    {
        var wordToUpdate = await _context.Words.FindAsync(id);
        if (wordToUpdate != null)
        {
            wordToUpdate.IsCommon = wordDto.IsCommon;
            await _context.SaveChangesAsync();
        }
        return wordToUpdate;
    }
}
