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
  game.startNewGame();
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
