import { LetterState } from "./letter";
import { WordList } from "./wordList";

export class WordService {
  static validGuessedWords(guesses: string[], stateArray: LetterState[][]): string[] {
    const validWords = new Set<string>();

    for(let j = 0; j < guesses.length; j++){
      const currentGuess: string = guesses[j];
      const states: LetterState[] =  stateArray[j];

      const isValidWord = WordList.filter(word => {
        let isValid = true;

        for(let i = 0; i < word.length; i++) {
          const guessedChar = (i < currentGuess.length) ? currentGuess[i].toLowerCase() : null;
          const isCorrectPosition = word[i] === guessedChar;
          const isInWord = word.includes(guessedChar);

          switch (states[i]) {
            case LetterState.Correct:
              if(!isCorrectPosition) isValid = false;
              break;
            case LetterState.Misplaced:
              if(isCorrectPosition || !isInWord) isValid = false;
              break;
            case LetterState.Wrong:
              if(isInWord) isValid = false;
              break;
            case LetterState.Unknown:
              break;
          }
          if (!isValid) break;
        }
        return isValid;
      });
      isValidWord.forEach(word => validWords.add(word));
    }
    return Array.from(validWords);
  }
}
