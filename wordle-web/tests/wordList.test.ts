import { describe, it, test, expect } from 'vitest';
import { Game } from '~/scripts/game';
import { myWordList } from '~/scripts/wordList';
import { ValidWordsUtils } from '~/scripts/validWordsUtils';

test('validWords', () => {
  let game = new Game();
  game.secretWord = 'ABACA';

  let utils = new ValidWordsUtils();
  game.addLetter('A');
  game.addLetter('A');
  game.addLetter('R');
  game.addLetter('G');
  game.addLetter('H');
  game.submitGuess();
  let validWords = utils.validWords(game);
  expect(validWords[0].toUpperCase()).toBe('ABACA');
});

test('validWords_wrongGuess_firstResultIsAARGH', () => {
  let game = new Game();
  game.secretWord = 'AARGH';

  let utils = new ValidWordsUtils();
  game.addLetter('A');
  game.addLetter('A');
  game.addLetter('R');
  game.addLetter('F');
  game.addLetter('F');
  let testWords = utils.validWords(game);
  expect(testWords[0].toUpperCase()).toBe('AARGH');
});
describe("validated words with validWords method and wordlist", () => {
  it("the test should match aargh to aargh", () => {
    let game = new Game(6);
    game.secretWord = 'aargh';

    let utils = new ValidWordsUtils();
    game.addLetter('a');
    game.addLetter('a');
    game.addLetter('r');
    game.addLetter('f');
    game.addLetter('f');
    let testWords = utils.validWords(game);
    expect(testWords[0]).toBe('aargh');
  })
  it("catch should not match with aargh but should match with aargh", () => {
    let game = new Game(6);
    game.secretWord = 'aargh';

    let utils = new ValidWordsUtils();
    game.addLetter('c');
    game.addLetter('a');
    game.addLetter('t');
    game.addLetter('c');
    game.addLetter('h');
    let testWords = utils.validWords(game);
    expect(testWords[0]).toBe('aargh');
    expect(testWords[0]).not.toBe('catch');
  })
  it("Guess should match index 1 on array of guesses", () => {
    let game = new Game(6);
    const guessArray = ["catch", "aargh", "apple", "beets"];
    game.secretWord = 'aargh';

    let utils = new ValidWordsUtils();
    game.addLetter('a');
    game.addLetter('a');
    game.addLetter('r');
    game.addLetter('f');
    game.addLetter('f');
    let testWords = utils.validWords(game);
    expect(testWords[0]).toBe('aargh');
    expect(testWords[0]).toBe(guessArray[1]);
  })
  it("Guess should match index 1 on array of guesses and not index 0 of guess array", () => {
    let game = new Game(6);
    const guessArray = ["catch", "aargh", "apple", "beets"];
    game.secretWord = 'aargh';

    let utils = new ValidWordsUtils();
    game.addLetter('a');
    game.addLetter('a');
    game.addLetter('r');
    game.addLetter('f');
    game.addLetter('f');
    let testWords = utils.validWords(game);
    expect(testWords[0]).toBe('aargh');
    expect(testWords[0]).not.toBe(guessArray[0]);
    expect(testWords[0]).toBe(guessArray[1]);
  })
  it("Check that the fourth 4 in the wordList is not our secrect word", () => {
    let game = new Game(6);
    game.secretWord = 'aargh';
  
    let utils = new ValidWordsUtils();
    let testWords = utils.validWords(game);
    expect(testWords[4]).not.toBe(game.secretWord);
  })
  it("checks a split word with the the guessed word", () => {
    let game = new Game(6);
    game.secretWord = 'aargh';
    const str= 'aargh';
    const guessedLetters = str.split('');
    let utils = new ValidWordsUtils();
    let testWords = utils.validWords(game);
    expect(testWords[0].charAt(0)).toBe(guessedLetters[0]);
    expect(testWords[0].charAt(1)).toBe(guessedLetters[1]);
    expect(testWords[0].charAt(2)).toBe(guessedLetters[2]);
    expect(testWords[0].charAt(3)).toBe(guessedLetters[3]);
    expect(testWords[0].charAt(4)).toBe(guessedLetters[4]);
  })
  it("this is another match of aargh to aaragh with splitting", () => {
    let game = new Game(6);
    game.secretWord = 'aargh';

    let utils = new ValidWordsUtils();

    let testWords = utils.validWords(game);
    expect(testWords[0].charAt(0)).toBe('a');
    expect(testWords[0].charAt(1)).toBe('a');
    expect(testWords[0].charAt(2)).toBe('r');
    expect(testWords[0].charAt(3)).toBe('g');
    expect(testWords[0].charAt(4)).toBe('h');
  })

});