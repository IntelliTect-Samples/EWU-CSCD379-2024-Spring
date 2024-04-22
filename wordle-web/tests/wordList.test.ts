import { describe, it, test, expect } from 'vitest';
import { Game } from '~/scripts/game';
import { myWordList } from '~/scripts/wordList';
import { ValidWordsUtils } from '~/scripts/validWordsUtils';

const wordList = [
  'AARGH',
  'ABACA',
  'HELLO',
  'THINK',
  'PEACH',
  'BEACH',
  'WHICH',
];

describe('validWords_enteredLettersIn_returnsCorrectWordAndLength', () => {
  it('enteredA_returnsFirstTwoWords', () => {
    let game = new Game();
    game.secretWord = 'HELLO';
    game.addLetter('A');
    let utils = new ValidWordsUtils(game, wordList);
    let validWords = utils.validWords();
    expect(validWords.length).toBe(2);
    expect(validWords[0]).toBe('AARGH');
    expect(validWords[1]).toBe('ABACA');
  });
  it('enteredAA_returnsAARGH', () => {
    let game = new Game();
    game.secretWord = 'HELLO';
    game.addLetter('A');
    game.addLetter('A');
    let utils = new ValidWordsUtils(game, wordList);
    let validWords = utils.validWords();
    expect(validWords.length).toBe(1);
    expect(validWords[0]).toBe('AARGH');
  });
  it('noLettersEntered_returnsFullList', () => {
    let game = new Game();
    game.secretWord = 'HELLO';
    let utils = new ValidWordsUtils(game, wordList);
    let validWords = utils.validWords();
    expect(validWords.length).toBe(7);
  });
  it('submittedGuessAndEnteredLetters', () => {
    let game = new Game();
    game.secretWord = 'THINK';
    let utils = new ValidWordsUtils(game, wordList);
    game.addLetter('H');
    game.addLetter('E');
    game.addLetter('L');
    game.addLetter('L');
    game.addLetter('O');
    game.submitGuess();
    game.addLetter('A');
    let validWords = utils.validWords();
    expect(validWords.length).toBe(2);
    expect(validWords[0]).toBe('AARGH');
    expect(validWords[1]).toBe('ABACA');
  });
});

describe('validWords_submittedGuess_returnsCorrectWordAndLength', () => {
  it('wrongLetterEliminatesAllOtherWordListWords', () => {
    let game = new Game();
    game.secretWord = 'ABACA';
    let utils = new ValidWordsUtils(game, wordList);
    game.addLetter('A');
    game.addLetter('A');
    game.addLetter('R');
    game.addLetter('G');
    game.addLetter('H');
    game.submitGuess();
    let validWords = utils.validWords();
    expect(validWords[0]).toBe('ABACA');
    expect(validWords.length).toBe(1);
  });
  it('misplacedLetterLeavesTwoWords', () => {
    let game = new Game();
    game.secretWord = 'THINK';
    let utils = new ValidWordsUtils(game, wordList);
    game.addLetter('H');
    game.addLetter('E');
    game.addLetter('L');
    game.addLetter('L');
    game.addLetter('O');
    game.submitGuess();
    let validWords = utils.validWords();
    expect(validWords.length).toBe(4);
    expect(validWords[0]).toBe('AARGH');
    expect(validWords[1]).toBe('ABACA');
    expect(validWords[2]).toBe('THINK');
    expect(validWords[3]).toBe('WHICH');
  });
  it('correctLetterLeavesOneWord', () => {
    let game = new Game();
    game.secretWord = 'AARGH';
    let utils = new ValidWordsUtils(game, wordList);
    game.addLetter('A');
    game.addLetter('B');
    game.addLetter('A');
    game.addLetter('C');
    game.addLetter('A');
    game.submitGuess();
    let validWords = utils.validWords();
    expect(validWords.length).toBe(1);
    expect(validWords[0]).toBe('AARGH');
  });
  it('twoGuessesLeaves', () => {
    let game = new Game();
    game.secretWord = 'PEACH';
    let utils = new ValidWordsUtils(game, wordList);
    game.addLetter('L');
    game.addLetter('E');
    game.addLetter('E');
    game.addLetter('C');
    game.addLetter('H');
    game.submitGuess();
    game.addLetter('P');
    game.addLetter('E');
    game.addLetter('E');
    game.addLetter('C');
    game.addLetter('H');
    game.submitGuess();
    let validWords = utils.validWords();
    expect(validWords.length).toBe(1);
    expect(validWords[0]).toBe(wordList[4]);
  });
});
