import { describe, it, test, expect } from 'vitest';
import { Game } from '~/scripts/game';
import { ValidWordsUtils } from '~/scripts/validWordsUtils';
import Axios from 'axios';

const wordList = [
  'AARGH',
  'ABACA',
  'HELLO',
  'THINK',
  'PEACH',
  'BEACH',
  'WHICH',
];

const wordList2 = ['ABACA', 'ABODE', 'TAROT'];

describe('validWords_enteredLettersIn_returnsCorrectWordAndLength', () => {
  it('enteredA_returnsFirstTwoWords', () => {
    let game = new Game();
    game.startNewGame('HELLO');
    game.addLetter('A');
    let utils = new ValidWordsUtils(game, wordList);
    let validWords = utils.validWords();
    expect(validWords.length).toBe(2);
    expect(validWords[0]).toBe('AARGH');
    expect(validWords[1]).toBe('ABACA');
  });
  it('enteredAA_returnsAARGH', () => {
    let game = new Game();
    game.startNewGame('HELLO');
    game.addLetter('A');
    game.addLetter('A');
    let utils = new ValidWordsUtils(game, wordList);
    let validWords = utils.validWords();
    expect(validWords.length).toBe(1);
    expect(validWords[0]).toBe('AARGH');
  });
  it('noLettersEntered_returnsFullList', () => {
    let game = new Game();
    game.startNewGame('HELLO');
    let utils = new ValidWordsUtils(game, wordList);
    let validWords = utils.validWords();
    expect(validWords.length).toBe(7);
  });
  it('submittedGuessAndEnteredLetters', () => {
    let game = new Game();
    game.startNewGame('THINK');
    let utils = new ValidWordsUtils(game, wordList);
    game.addLetter('H');
    game.addLetter('E');
    game.addLetter('L');
    game.addLetter('L');
    game.addLetter('O');
    game.submitGuess();
    game.addLetter('A');
    let validWords = utils.validWords();
    expect(validWords.length).toBe(1);
    expect(validWords[0]).toBe('AARGH');
  });
  it('minimumOfDiscoveredLettersFoundInNewWord', () => {
    let game = new Game();
    game.startNewGame('GONNA');
    let utils = new ValidWordsUtils(game, wordList2);
    game.addLetter('T');
    game.addLetter('A');
    game.addLetter('R');
    game.addLetter('O');
    game.addLetter('T');
    game.submitGuess();
    let validWords = utils.validWords();
    expect(validWords.length).toBe(1);
    expect(validWords[0]).toBe('ABODE');
  });
});

describe('validWords_submittedGuess_returnsCorrectWordAndLength', () => {
  it('wrongLetterEliminatesAllOtherWordListWords', () => {
    let game = new Game();
    game.startNewGame('ABACA');
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
  it('misplacedLetterLeavesThreeWords', () => {
    let game = new Game();
    game.startNewGame('THINK');
    let utils = new ValidWordsUtils(game, wordList);
    game.addLetter('H');
    game.addLetter('E');
    game.addLetter('L');
    game.addLetter('L');
    game.addLetter('O');
    game.submitGuess();
    let validWords = utils.validWords();
    expect(validWords.length).toBe(3);
    expect(validWords[0]).toBe('AARGH');
    expect(validWords[1]).toBe('THINK');
    expect(validWords[2]).toBe('WHICH');
  });
  it('correctLetterLeavesOneWord', () => {
    let game = new Game();
    game.startNewGame('AARGH');
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
    game.startNewGame('PEACH');
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
