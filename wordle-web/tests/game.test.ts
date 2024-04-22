// @vitest-environment nuxt
import { test, expect } from 'vitest';
import { Game } from '~/scripts/game';
import { LetterState } from '~/scripts/letter';

test('game', () => {
  // create game and check if it's created
  const game = new Game();
  expect(game.secretWord.length).toBe(5);
});
