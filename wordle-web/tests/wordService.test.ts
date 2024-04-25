import { expect, test } from "vitest";
import { Game } from "~/scripts/game";
import {WordList } from "~/scripts/wordList";
import { LetterState } from "~/scripts/letter";
import { WordService } from "~/scripts/wordService";

const wordService = new WordService();


// guess right, gives back word
test('WordService single guess test results in word', () => {
  const game = new Game();
  game.secretWord = "aargh";

  game.guess.addLetter("a");
  game.guess.addLetter("a");
  game.guess.addLetter("r");
  game.guess.addLetter("g");
  game.guess.addLetter("h");
  game.submitGuess();

  expect(wordService.getValidWords(game)).toContain("aargh");
});

// guess wrong, gets rid of word
test('WordService single wrong guess test results in word removed', () => {
  const game = new Game();
  game.secretWord = "aargh";

  game.guess.addLetter("a");
  game.guess.addLetter("b");
  game.guess.addLetter("a");
  game.guess.addLetter("c");
  game.guess.addLetter("a");
  game.submitGuess();

  expect(wordService.getValidWords(game)).not.toContain("abaca");
});

// guesses words around it, returns correct since its the only option left
test('WordService guess two words similar, contains word', () => {
  const game = new Game();
  game.secretWord = "abaca";

  game.guess.addLetter("a");
  game.guess.addLetter("b");
  game.guess.addLetter("a");
  game.guess.addLetter("c");
  game.guess.addLetter("i");
  game.submitGuess();

  game.guess.addLetter("a");
  game.guess.addLetter("b");
  game.guess.addLetter("a");
  game.guess.addLetter("c");
  game.guess.addLetter("k");
  game.submitGuess();

  expect(wordService.getValidWords(game)).toContain("abaca");
});
