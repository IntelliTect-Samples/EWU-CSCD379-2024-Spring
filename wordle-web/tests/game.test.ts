// @vitest-environment nuxt
import { test, expect } from 'vitest';
import { Game } from '~/scripts/game';

test('game', () => {
  // create game and check if it's created
  const game = new Game('HELLO');
  expect(game.secretWord.length).toBe(5);
});
