import { expect, test } from "vitest";
import { Game } from "~/scripts/game";
import { WordList } from "~/scripts/wordList";
import { updateValidWords } from "~/scripts/wordListUtils";


test("wordList init", () => {
  const game = new Game(6);
  expect(updateValidWords(game).length).equal(WordList.length);
});

test("none right", () => {
  const game = new Game(6);
  game.startNewGame("HELLO");
  game.guess.addLetter("A");
  game.guess.addLetter("P");
  game.guess.addLetter("A");
  game.guess.addLetter("R");
  game.guess.addLetter("T");
  game.submitGuess();

  expect(updateValidWords(game)).not.toContain("hands");
  expect(updateValidWords(game)).not.toContain("snare");
  expect(updateValidWords(game)).not.toContain("traps");
  expect(updateValidWords(game)).not.toContain("apart");
  expect(updateValidWords(game)).not.toContain("aptly");

  expect(updateValidWords(game)).toContain("hello");
  expect(updateValidWords(game)).toContain("holds");
  expect(updateValidWords(game)).toContain("smell");
  expect(updateValidWords(game)).toContain("messy");
  expect(updateValidWords(game)).toContain("elves");
});

test("some right", () => {
  const game = new Game(6);
  game.startNewGame("TRAPS");
  game.guess.addLetter("P");
  game.guess.addLetter("A");
  game.guess.addLetter("R");
  game.guess.addLetter("T");
  game.guess.addLetter("Y");
  game.submitGuess();

  expect(updateValidWords(game)).not.toContain("buggy");
  expect(updateValidWords(game)).not.toContain("phlox");
  expect(updateValidWords(game)).not.toContain("pants");

  expect(updateValidWords(game)).toContain("traps");
});

test("most right", () => {
  const game = new Game(6);
  game.startNewGame("ELDER")
  game.guess.addLetter("E");
  game.guess.addLetter("M");
  game.guess.addLetter("B");
  game.guess.addLetter("E");
  game.guess.addLetter("R");
  game.submitGuess();

  expect(updateValidWords(game)).not.toContain("boomy");
  expect(updateValidWords(game)).not.toContain("snare");
  expect(updateValidWords(game)).not.toContain("traps");

  expect(updateValidWords(game)).toContain("edger");
  expect(updateValidWords(game)).toContain("egger");
  expect(updateValidWords(game)).toContain("ender");
});
