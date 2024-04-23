import { expect, test } from "vitest";
import { Game } from "~/scripts/game";
import {WordList } from "~/scripts/wordList";
import { LetterState } from "~/scripts/letter";
import { WordService } from "~/scripts/wordService";

test('WordService test full word', ()=> {
  const guess = ['aargh'];
  const states = [[
    LetterState.Correct,
    LetterState.Correct,
    LetterState.Correct,
    LetterState.Correct,
    LetterState.Correct,
  ]];

  const validWords = WordService.validGuessedWords(guess, states);
  expect(validWords).toEqual(['aargh']);
});

test('WordService test partial word', ()=> {
  const guess = ['aarg'];
  const states = [[
    LetterState.Correct,
    LetterState.Correct,
    LetterState.Correct,
    LetterState.Correct,
    LetterState.Unknown,
  ]];

  const validWords = WordService.validGuessedWords(guess, states);
  expect(validWords).toEqual(['aargh']);
})

test('WordService test partial word, results in multiple words', ()=> {
  const guess = ['abac'];
  const states = [[
    LetterState.Correct,
    LetterState.Correct,
    LetterState.Correct,
    LetterState.Correct,
    LetterState.Unknown,
  ]];

  const validWords = WordService.validGuessedWords(guess, states);
  expect(validWords[0]).toEqual('abaca');
  expect(validWords[1]).toEqual('abaci');
  expect(validWords[2]).toEqual('aback');
});

test('WordService test wrongplaced letters full word, results in aargh', ()=> {
  const guess = ["aragh"];
  const states = [[
    LetterState.Correct,
    LetterState.Misplaced,
    LetterState.Misplaced,
    LetterState.Correct,
    LetterState.Correct,
  ]];

  const validWords = WordService.validGuessedWords(guess, states);
  expect(validWords).toEqual(['aargh']);
});
