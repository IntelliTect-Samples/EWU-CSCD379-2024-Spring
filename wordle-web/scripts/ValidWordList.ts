import { Letter, LetterState } from "./letter";
import { Word } from "./word";
import { WordList } from "./wordList";
import { Game, } from "./game";

export class ValidWordList {
  public static findValidWords(guesses: Word[], guessIndex: number, validWordList: string[]): string[] {
    for(let i = 0; i < guesses[0].word.length; i++) {
      const letter = guesses[guessIndex].letters[i];
      if(letter.state === LetterState.Wrong) {
        validWordList = validWordList.filter((word) => word.indexOf(letter.char) === -1);
      }
      if(letter.state === LetterState.Correct) {
        validWordList = validWordList.filter((word) => word[i] === letter.char);
      }
      if(letter.state === LetterState.Misplaced) {
        validWordList = validWordList.filter((word) => word[i] !== letter.char);
      }
    }
    return validWordList;
  }
}