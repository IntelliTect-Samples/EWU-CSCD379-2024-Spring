import { WordList } from "./wordList";
import { Game } from '~/scripts/game';
import { Letter, LetterState } from '~/scripts/letter';
import { Word } from '~/scripts/word';

export class WordEngine {
    
  static validGuessedWords(currentGuess: string, states: LetterState[]): string[] {
    return WordList.filter(word => {
      let isValid = true;
      for(let i = 0; i < word.length; i++) {
        const guessedChar = (i < currentGuess.length) ? currentGuess[i].toLowerCase() : ''; // Use an empty string as a fallback
        const isCorrectPosition = word[i] === guessedChar;
        const isInWord = word.includes(guessedChar);

        switch (states[i]) {
          case LetterState.Correct:
            if (!isCorrectPosition) isValid = false;
            break;
          case LetterState.Misplaced:
            if (isCorrectPosition || !isInWord) isValid = false;
            break;
          case LetterState.Wrong:
            if (isInWord) isValid = false;
            break;
          case LetterState.Unknown:
            break;
        }
        if (!isValid) break;
      }
      return isValid;
    });
  }
}
