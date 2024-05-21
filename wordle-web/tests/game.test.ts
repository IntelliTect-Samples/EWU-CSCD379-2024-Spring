// @vitest-environment nuxt
import { beforeEach, expect, test } from "vitest";
import { Game } from "~/scripts/game";
import { LetterState } from "~/scripts/letter";
import { GameStats } from "~/scripts/gameStats";

test("game", () => {
  // create game and check if it's created
  const game = new Game();
  game.startNewGame("autos");
  expect(game.secretWord.length).toBe(5);
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
