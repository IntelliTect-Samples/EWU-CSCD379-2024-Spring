import { expect, test } from "vitest";
import { tellJoke } from "~/Assignment1_CSCD379/EWU-CSCD379-2024-Spring/wordle-web/scripts/joke.ts";

test('returns Correct! 😄 if the punchline is correct', () => {
  const punchline = 'because they make up everything';
  expect(tellJoke(punchline)).toBe('Correct! 😄');
});

test('returns the correct answer if punchline is incorrect', () => {
  const incorrectPuncline = 'This is not the correct punchline';
  const answer = 'because they make up everything';
  expect(tellJoke(incorrectPuncline)).toBe('Nope, the correct answer is: ${answer}.');
});
