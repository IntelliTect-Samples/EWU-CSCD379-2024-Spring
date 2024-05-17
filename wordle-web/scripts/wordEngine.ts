import { WordList } from "./wordList";
import { Game } from "./game";
import { LetterState } from "./letter";

export function filterValidWords(game: Game): string[] {
  return WordList.filter((word) => {
    for (const letterObj of game.guessedLetters) {
      const letterChar = letterObj.char.toLowerCase();
      const wordLowerCase = word.toLowerCase();
      const isLetterInWord = word.includes(letterChar);
      const isLetterCorrect = letterObj.state === LetterState.Correct;
      const isLetterMisplaced = letterObj.state === LetterState.Misplaced;
      const indexOfLetterInWord = word.indexOf(letterChar);
      const indexOfLetterInSecretWord = game.secretWord.toLowerCase().indexOf(letterChar);

      if (isLetterInWord && letterObj.state === LetterState.Wrong) {
        return false;
      }

      if (!isLetterInWord && (isLetterCorrect || isLetterMisplaced)) {
        return false;
      }

      if (isLetterInWord && (isLetterCorrect || isLetterMisplaced) && indexOfLetterInWord !== indexOfLetterInSecretWord) {
        return false;
      }
    }

    return true;
  });
}
