import { LetterState } from "./letter";
import { WordList } from "./wordList";


export class WordService {
  getValidWords(game: Game): string[] {
    return WordList.filter(word => this.validWords(word, game));
  }

  private validWords(word: string, game: Game): boolean {
    for (const { char, state } of game.guessedLetters) {
      const letter = char.toLowerCase();

      if(word.includes(letter) && state === LetterState.Wrong) return false;
      if(!word.includes(letter) && (state === LetterState.Correct || state === LetterState.Misplaced)) return false;
      if(word.includes(letter) && (state === LetterState.Correct || state === LetterState.Misplaced) && word.indexOf(letter) !== game.secretWord.toLowerCase().indexOf(letter)) return false;
    }
    return true;
  }
}



  /*static validGuessedWords(guesses: string[], stateArray: LetterState[][]): string[] {
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
  }*/

