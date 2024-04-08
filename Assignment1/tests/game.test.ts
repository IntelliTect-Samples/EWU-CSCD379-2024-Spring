import { expect, test } from 'vitest';
import { checkGuess, message, guess, messageType } from '../scripts/game';


test('checkGuess should display error message for invalid input', () => {
    // Set up initial state
    const guess = 'abc'; // Invalid input
    
    // Call the function
    checkGuess();
    
    // Assert the expected behavior
    expect(message.value).toBe('Please enter a valid number between 1 and 100.');
    expect(messageType.value).toBe('error');
  });
  
  test('checkGuess should display warning message for guess lower than secret number', () => {
    // Set up initial state
    const guess = '30'; // Lower than secretNumber
    
    // Call the function
    checkGuess();
    
    // Assert the expected behavior
    expect(message.value).toBe('Too low! Try again.');
    expect(messageType.value).toBe('warning');
  });
  
  test('checkGuess should display warning message for guess higher than secret number', () => {
    // Set up initial state
    const guess = '70'; // Higher than secretNumber
    
    // Call the function
    checkGuess();
    
    // Assert the expected behavior
    expect(message.value).toBe('Too high! Try again.');
    expect(messageType.value).toBe('warning');
  });
