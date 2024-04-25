// @vitest-environment nuxt
import { expect, test } from "vitest";
import { Game } from "~/scripts/game";
import { WordList } from "~/scripts/wordList";
import { LetterState } from "~/scripts/letter";
import { filterValidWords } from "~/scripts/wordEngine";

const game = new Game(6);

test("game", () => {
  game.secretWord = "HELLO"
  expect(game.secretWord.length).toBe(5);
});



test("settingSecretWordExplicitly", () => {
  const game = new Game(6);
  game.secretWord = "ALOHA"
  expect(game.secretWord.length).toBe(5);
});

test("filter doesn't exist", () => {
  expect(filterValidWords).not.toContain("applw");
  expect(filterValidWords).not.toContain("apppw");
  expect(filterValidWords).not.toContain("appzw");
});

test("filter does exist", () => {
  game.secretWord = "aloha";
  game.guess.addLetter("h");
  game.guess.addLetter("e");
  game.guess.addLetter("l");
  game.guess.addLetter("l");
  game.guess.addLetter("o");
  game.submitGuess();

  expect(filterValidWords(game)).toContain("aloha");
  
});


test("word in word list", () => {
  expect(WordList).toContain("aloha");
  expect(WordList).toContain("apple");
  expect(WordList).toContain("hello");
});

test("word not in word list", () => {
  expect(WordList).not.toContain("aaaaa");
  expect(WordList).not.toContain("ahslo");
  expect(WordList).not.toContain("nhjis");
});



test("filter start does not contain any invalid words", () => {
  expect(filterValidWords(game)).not.toContain("aaaaa");
  expect(filterValidWords(game)).not.toContain("ahslo");
  expect(filterValidWords(game)).not.toContain("nhjis");
});





