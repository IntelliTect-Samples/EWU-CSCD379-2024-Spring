// @vitest-environment nuxt
import { expect, test } from "vitest";
import { Game } from "~/scripts/game";
import { LetterState } from "~/scripts/letter";

test("game", () => {
  // create game and check if it's created
  const game = new Game("autos");
  expect(game.wordToGuess.length).toBe(5);
});

test("guess-word", () => {
  const game = new Game("autos");
  game.guess("tangs");
  expect(game.guesses[0].letters[0].state).toBe(LetterState.Misplaced);
  expect(game.guesses[0].letters[1].state).toBe(LetterState.Misplaced);
  expect(game.guesses[0].letters[2].state).toBe(LetterState.Wrong);
  expect(game.guesses[0].letters[3].state).toBe(LetterState.Wrong);
  expect(game.guesses[0].letters[4].state).toBe(LetterState.Correct);

  game.guess("flick");
  expect(game.guesses[1].letters[0].state).toBe(LetterState.Wrong);
  expect(game.guesses[1].letters[1].state).toBe(LetterState.Wrong);
  expect(game.guesses[1].letters[2].state).toBe(LetterState.Wrong);
  expect(game.guesses[1].letters[3].state).toBe(LetterState.Wrong);
  expect(game.guesses[1].letters[4].state).toBe(LetterState.Wrong);

  game.guess("autos");
  expect(game.guesses[2].letters[0].state).toBe(LetterState.Correct);
  expect(game.guesses[2].letters[1].state).toBe(LetterState.Correct);
  expect(game.guesses[2].letters[2].state).toBe(LetterState.Correct);
  expect(game.guesses[2].letters[3].state).toBe(LetterState.Correct);
  expect(game.guesses[2].letters[4].state).toBe(LetterState.Correct);
});

test("max-attempts stops guesses appending at 6", () => {
  const game = new Game("autos");
  game.guess("trips");
  game.guess("grabs");
  game.guess("woops");
  game.guess("jumps");
  game.guess("jumps");
  game.guess("jumps");
  game.guess("jumps");

  expect(game.guesses.length).toBe(6);
});

test("won gamestate", () => {
  const game = new Game("autos");
  game.guess("autos");
  expect(game.gameState).toBe(1);
});

test("loss gamestate", () => {
  const game = new Game("autos");
  game.guess("wrong");
  game.guess("wrong");
  game.guess("wrong");
  game.guess("wrong");
  game.guess("wrong");
  game.guess("wrong");

  expect(game.gameState).toBe(2);
});

test("playing gamestate", () => {
  const game = new Game("autos");
  game.guess("check");
  game.guess("tangs");

  expect(game.gameState).toBe(0);
});
