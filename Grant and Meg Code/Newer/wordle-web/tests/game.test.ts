// @vitest-environment nuxt
import { beforeEach, expect, test } from "vitest";
import { Game } from "~/scripts/game";
import { LetterState } from "~/scripts/letter";
import AxiosMockAdapter from "axios-mock-adapter";
import axios from "axios";
import { GameStats } from "~/scripts/gameStats";

let mock: AxiosMockAdapter;

beforeEach(() => {
  mock = new AxiosMockAdapter(axios);
});

test("game", () => {
  // create game and check if it's created
  const game = new Game();
  game.startNewGame("autos");
  expect(game.secretWord.length).toBe(5);
});

test("guess-word", () => {
  const game = new Game();

  const word = "autos";

  const mockGameStats = new GameStats();
  mockGameStats.word = "autos";
  mockGameStats.averageGuesses = 0;
  mockGameStats.totalTimesPlayed = 0;
  mockGameStats.totalWins = 0;
  mockGameStats.totalLosses = 0;

  mock.onPost().reply(200, mockGameStats);

  game.startNewGame(word);
  game.setGuessLetters("tangs");
  game.submitGuess();
  expect(game.guesses[0].letters[0].state).toBe(LetterState.Misplaced);
  expect(game.guesses[0].letters[1].state).toBe(LetterState.Misplaced);
  expect(game.guesses[0].letters[2].state).toBe(LetterState.Wrong);
  expect(game.guesses[0].letters[3].state).toBe(LetterState.Wrong);
  expect(game.guesses[0].letters[4].state).toBe(LetterState.Correct);

  game.setGuessLetters(word);
  game.submitGuess();
  expect(game.guesses[1].letters[0].state).toBe(LetterState.Correct);
  expect(game.guesses[1].letters[1].state).toBe(LetterState.Correct);
  expect(game.guesses[1].letters[2].state).toBe(LetterState.Correct);
  expect(game.guesses[1].letters[3].state).toBe(LetterState.Correct);
  expect(game.guesses[1].letters[4].state).toBe(LetterState.Correct);

});