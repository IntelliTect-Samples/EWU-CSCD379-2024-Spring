import { expect, test } from "vitest";
import { tellJoke } from "~/scripts/joke.ts";

test('returns Correct! 😄 if the punchline is correct', () => {
  const punchline = 'because they make up everything';
  expect(tellJoke(punchline)).toBe('Correct! 😄');
});

test('returns the correct answer if punchline is incorrect', () => {
  const incorrectPuncline = 'this is not the correct punchline';
  expect(tellJoke(incorrectPuncline)).toBe('Nope, the correct answer is: because they make up everything.');
});
