import { LetterState } from "./letter";
import { WordList } from "./wordList";

export class WordService {
  static validGuessedWords(currentGuess: string, states: LetterState[]): string[] {
    return WordList.filter(word => {
      for(let i = 0; i < word.length; i++) {
        const guessedChar = currentGuess[i].toLowerCase();
        const isCorrectPosition = word[i] === guessedChar;
        const isInWord = word.includes(guessedChar);

        switch (states[i]) {
          case LetterState.Correct:
            if(!isCorrectPosition) return false;
            break;
          case LetterState.Misplaced:
            if(isCorrectPosition || !isInWord) return false;
            break;
          case LetterState.Wrong:
            if(isInWord) return false;
            break;
          case LetterState.Unknown:
            break;
        }
      }
      return true;
    });
  }
}
