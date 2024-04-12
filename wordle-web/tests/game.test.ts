// @vitest-environment nuxt
import { expect, test } from "vitest";
import { Game } from "~/scripts/game";
import { LetterState } from "~/scripts/letter";

test("game", () => {
  // create game and check if it's created
  const game = new Game(6);
  expect(game.secretWord.length).toBe(5);
});

test("guess-word", () => {
  const game = new Game(6);
  game.guess.addLetter("Z");
  game.guess.addLetter("Z");
  game.guess.addLetter("Z");
  game.guess.addLetter("Z");
  game.guess.addLetter("Z");
  game.guess.addLetter("Z");
  expect(game.guess.isFilled()).toBe(true);
});
