import { expect, test } from 'vitest'
import { Game } from '../scripts/game'

test('adds 1 + 2 to equal 3', () => {
  expect(1 + 2).toBe(3);
})

test('check string for name', () => {
  expect('Hello, World!').toMatch('Hello');
})

test('check object for property', () => {
  expect({ name: 'John' }).toHaveProperty('name');
})

test('check game guess word property', () => {
  const game = new Game('hello');
  expect(game.wordToGuess).toBe('hello');
})

test('check game guess word wrong', () => {
  const game = new Game('hello');
  expect(game.wordToGuess).not.toBe('world');
})
