// @vitest-environment nuxt
import { expect, test } from "vitest";
import { Game } from "~/scripts/game";

test("startNewGame secret word length is 5", async () => {
  // create game and check if it's created
  const game = new Game();
  await game.startNewGame();
  expect(game.secretWord.length).toBe(5);
});

test("submitGuess valid guess increases guess index ", async () => {
  const game = new Game();
  await game.startNewGame();

  game.addLetter("S");
  game.addLetter("M");
  game.addLetter("A");
  game.addLetter("L");
  game.addLetter("L");
  game.addLetter("S");
  game.submitGuess();
  expect(game.guessIndex).toBe(1);
});

test("submitGuess invaid guess does not increase guess index ", async () => {
  const game = new Game();
  await game.startNewGame();

  game.addLetter("Z");
  game.addLetter("Z");
  game.addLetter("Z");
  game.addLetter("Z");
  game.addLetter("Z");
  game.addLetter("Z");
  game.submitGuess();
  expect(game.guessIndex).toBe(0);
});
