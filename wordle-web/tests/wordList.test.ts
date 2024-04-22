import { describe, it, test, expect } from 'vitest';
import { Game } from '~/scripts/game';
import { myWordList } from '~/scripts/wordList';
import { ValidWordsUtils } from '~/scripts/validWordsUtils';

test('validWords', () => {
  let game = new Game(6);
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
  let game = new Game(6);
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
