import { WordList } from "./wordList";
import { Game } from "./game";
import { LetterState } from "./letter";

export function filterValidWords(game: Game): string[] {
  return WordList.filter((word) => {
    for (let i = 0; i < game.guessedLetters.length; i++) {
      const letterObj = game.guessedLetters[i];
      const letterChar = letterObj.char.toLowerCase();

      const indexOfLetterInWord = word.indexOf(letterChar);
      const indexOfLetterInSecretWord = game.secretWord
        .toLowerCase()
        .indexOf(letterChar);
      if (
        word.includes(letterChar) &&
        game.guessedLetters[i].state === LetterState.Wrong
      ) {
        return false;
      }
      if (
        !word.includes(letterChar) &&
        (letterObj.state === LetterState.Correct ||
          letterObj.state === LetterState.Misplaced)
      ) {
        return false;
      }
      if (
        word.includes(letterChar) &&
        (letterObj.state === LetterState.Correct ||
          letterObj.state === LetterState.Misplaced) &&
        indexOfLetterInWord !== indexOfLetterInSecretWord
      ) {
        return false;
      }
    }
    return true;
  });
}