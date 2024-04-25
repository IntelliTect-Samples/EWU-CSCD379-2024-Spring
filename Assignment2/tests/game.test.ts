import { expect, test } from "vitest";
import { Game } from "~/scripts/game";
import { WordList } from "~/scripts/wordList";
import { updateValidWords } from "~/scripts/wordListUtils";

//These first two were here before, accidentally deleted at some point ig
test("game", () => {
    // create game and check if it's created
    const game = new Game(6);
    expect(game.secretWord.length).toBe(5);
    expect(game.maxAttempts).toBe(6);
    expect(updateValidWords(game)).toContain(game.secretWord.toLowerCase());
});

test("guess-word", () => {
    const game = new Game(6);
    game.guess.addLetter("Z");
    game.guess.addLetter("Z");
    game.guess.addLetter("Z");
    game.guess.addLetter("Z");
    game.guess.addLetter("Z");
    game.guess.addLetter("Z");
    expect(game.guess.letters.length).toBe(5);
    expect(game.guess.word).toBe("ZZZZZ");
});


test("wordList init", () => {
  const game = new Game(6);
  expect(updateValidWords(game).length).equal(WordList.length);
});

test("none right", () => {
  const game = new Game(6);
  game.secretWord = "HELLO";
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
  game.secretWord = "TRAPS";
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
  game.secretWord = "ELDER";
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