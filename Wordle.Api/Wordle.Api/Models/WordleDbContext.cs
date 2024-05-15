﻿using Microsoft.EntityFrameworkCore;

namespace Wordle.Api.Models
{
  
    public class WordleDbContext:DbContext
    {
        public DbSet<WordOfTheDay> WordsOfTheDays { get; set; }
        public DbSet<Game> Games { get; set; }
        public DbSet<Word> Words { get; set; }
        
        public WordleDbContext(DbContextOptions<WordleDbContext> options)
            : base(options)
        {
        }
    }
}
