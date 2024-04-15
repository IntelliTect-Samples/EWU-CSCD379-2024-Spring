import { expect, test } from "vitest";
import { Game } from "~/scripts/game";
import {WordList } from "~/scripts/wordList";
import { LetterState } from "~/scripts/letter";
import { WordService } from "~/scripts/wordService";

test('WordService test full word', ()=> {
  const guess = 'aargh';
  const states = [
    LetterState.Correct,
    LetterState.Correct,
    LetterState.Correct,
    LetterState.Correct,
    LetterState.Correct,
  ];

  const validWords = WordService.validGuessedWords(guess, states);
  expect(validWords).toEqual(['aargh']);
});

test('WordService test partial word', ()=> {
  const guess = 'aarg';
  const states = [
    LetterState.Correct,
    LetterState.Correct,
    LetterState.Correct,
    LetterState.Correct,
    LetterState.Unknown,
  ];

  const validWords = WordService.validGuessedWords(guess, states);
  expect(validWords).toEqual(['aargh']);
})
