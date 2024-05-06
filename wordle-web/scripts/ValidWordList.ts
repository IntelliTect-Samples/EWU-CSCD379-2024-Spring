import { Letter, LetterState } from "./letter";
import { WordList } from "./wordList";
import { Game, } from "./game";

export function findValidWords(game: Game): string[] {
  console.log("start");
  let validWordList = WordList;
  for(let i = 0; i < game.guessedLetters.length; i++) {
    const letter = game.guessedLetters[i];
    console.log(letter.char);
    if(letter.state === LetterState.Wrong) {
      validWordList = validWordList.filter((word) => !word.includes(letter.char.toLowerCase()));
      console.log(letter.char);
    }
    if(letter.state === LetterState.Correct || letter.state === LetterState.Misplaced) {
      validWordList = validWordList.filter((word) => word.includes(letter.char.toLowerCase()));
      validWordList = validWordList.filter((word) => (!(word.includes(letter.char.toLowerCase()) &&
        word.indexOf(letter.char.toLowerCase()) !== game.secretWord.toLowerCase().indexOf(letter.char.toLowerCase())
      )));
    }
  }
  return validWordList;
}