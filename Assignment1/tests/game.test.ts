import { expect, test } from 'vitest'

test('adds 1 + 2 to equal 3', () => {
  expect(1 + 2).toBe(3);
})

test('check string for name', () => {
  expect('Hello, World!').toMatch('Hello');
})

test('check object for property', () => {
  expect({ name: 'John' }).toHaveProperty('name');
})