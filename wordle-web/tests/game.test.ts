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

  game.guess("autos");
  expect(game.guesses[1].letters[0].state).toBe(LetterState.Correct);
  expect(game.guesses[1].letters[1].state).toBe(LetterState.Correct);
  expect(game.guesses[1].letters[2].state).toBe(LetterState.Correct);
  expect(game.guesses[1].letters[3].state).toBe(LetterState.Correct);
  expect(game.guesses[1].letters[4].state).toBe(LetterState.Correct);
});
// Will expand tests once more features are added to the game