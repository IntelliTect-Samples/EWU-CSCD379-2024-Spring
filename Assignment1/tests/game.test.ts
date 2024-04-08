import { expect, test } from 'vitest';
import { checkGuess, message, guess, messageType } from '../scripts/game';
  
  test('checkGuess should ask for a valid number', () => {
    // Set up initial state
    const guess = '1'; // Lower than secretNumber
    
    // Call the function
    checkGuess();
    
    // Assert the expected behavior
    expect(message.value).toBe('Please enter a valid number between 1 and 100.');
  });