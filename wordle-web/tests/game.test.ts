// @vitest-environment nuxt
import { test, expect } from 'vitest';
import { LetterState } from '~/scripts/letter';
import { Game, GameOption } from '~/scripts/game';

test('game', () => {
  // create game and check if it's created
  const game = new Game(GameOption.SelectedWord);
  game.postScores = false;
  game.startNewGame('autos');
  expect(game.secretWord.length).toBe(5);
});

test('guess-word', () => {
  const game = new Game(GameOption.SelectedWord);
  game.postScores = false;
  game.startNewGame('autos');
  game.setGuessLetters('tangs');
  game.submitGuess();
  expect(game.guesses[0].letters[0].state).toBe(LetterState.Misplaced);
  expect(game.guesses[0].letters[1].state).toBe(LetterState.Misplaced);
  expect(game.guesses[0].letters[2].state).toBe(LetterState.Wrong);
  expect(game.guesses[0].letters[3].state).toBe(LetterState.Wrong);
  expect(game.guesses[0].letters[4].state).toBe(LetterState.Correct);

  game.setGuessLetters('autos');
  game.submitGuess();
  expect(game.guesses[1].letters[0].state).toBe(LetterState.Correct);
  expect(game.guesses[1].letters[1].state).toBe(LetterState.Correct);
  expect(game.guesses[1].letters[2].state).toBe(LetterState.Correct);
  expect(game.guesses[1].letters[3].state).toBe(LetterState.Correct);
  expect(game.guesses[1].letters[4].state).toBe(LetterState.Correct);
});
