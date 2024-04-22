import { describe, expect, it, beforeEach } from 'vitest';
import { Game, GameState } from '~/scripts/game';
import { LetterState } from '~/scripts/letter';

describe('Game', () => {
  let game: Game;

  beforeEach(() => {
    game = new Game(6);
    game.secretWord = 'MAGIC'; // Set the secretWord for test predictability
  });

  it('initializes with a secret word "MAGIC"', () => {
    expect(game.secretWord).toBe('MAGIC');
  });

  it('starts with the correct number of guesses', () => {
    expect(game.guesses).toHaveLength(game.maxAttempts);
  });

  it('allows letters to be added to a guess', () => {
    game.addLetter('M');
    game.addLetter('A');
    const expectedLetters = ['M', 'A', '', '', ''].map(char => ({ char: char, state: LetterState.Unknown }));
    expect(game.guess.letters).toEqual(expectedLetters);
  });

  it('correctly processes a correct guess', () => {
    'MAGIC'.split('').forEach(char => game.addLetter(char));
    game.submitGuess();
    expect(game.gameState).toBe(GameState.Won);
  });

  it('correctly processes an incorrect guess', () => {
    'WRONG'.split('').forEach(char => game.addLetter(char));
    game.submitGuess();
    expect(game.gameState).toBe(GameState.Playing);
    expect(game.guessIndex).toBe(1);
  });

  it('ends the game as lost after the maximum number of incorrect guesses', () => {
    for (let i = 0; i < game.maxAttempts; i++) {
      'WRONG'.split('').forEach(char => game.addLetter(char));
      game.submitGuess();
    }
    expect(game.gameState).toBe(GameState.Lost);
  });
});
