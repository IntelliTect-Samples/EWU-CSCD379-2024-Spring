// @vitest-environment nuxt
import { test, expect } from 'vitest';
import { Game } from '~/scripts/game';
import { LetterState } from '~/scripts/letter';

test('game', () => {
  // create game and check if it's created
  const game = new Game();
  expect(game.secretWord.length).toBe(5);
});

test('array', () => {
  const array = [0, 1, 2, 3, 4];
  const num = array.at(-1);
  expect(num).toBe(array[-1]);
});
