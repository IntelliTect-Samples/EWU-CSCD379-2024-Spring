// @vitest-environment nuxt
import { expect, test } from "vitest";
import { Game } from "~/scripts/game";

test("game", () => {
  // create game and check if it's created
  const game = new Game("GAMES");
  expect(game.secretWord.length).toBe(5);
});

test("guess-word", () => {
  const game = new Game("BLOOM");
  game.guess.addLetter("Z");
  game.guess.addLetter("Z");
  game.guess.addLetter("Z");
  game.guess.addLetter("Z");
  game.guess.addLetter("Z");
  game.guess.addLetter("Z");
  expect(game.guess.letters.length).toBe(5);
});
