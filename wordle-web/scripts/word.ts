import { Letter, LetterState } from "./letter";

export class Word {
  public letters: Letter[];

  constructor(word: string) {
    this.letters = word.split("").map((char) => new Letter(char));
  }

  public compare(wordToGuessInput: Word): void {
    for (const [i, letter] of wordToGuessInput.letters.entries()) {
      if (letter.char === this.letters[i].char) {
        this.letters[i].state = LetterState.Correct;
        letter.state = LetterState.Correct;
      }
    }
    // TODO: Fix this. :)
    for (const guessedLetter of this.letters) {
      if (guessedLetter.state === LetterState.Unknown) {
        for (const toGuessLetter of wordToGuessInput.letters) {
          if (
            toGuessLetter.state === LetterState.Unknown &&
            toGuessLetter.char === guessedLetter.char
          ) {
            guessedLetter.state = LetterState.Misplaced;
            toGuessLetter.state = LetterState.Misplaced;
            break;
          }
        }
        if (guessedLetter.state === LetterState.Unknown) {
          guessedLetter.state = LetterState.Wrong;
        }
      }
    }
  }
  public checkForWin(): boolean {
    return this.letters.every((letter) => letter.state === LetterState.Correct);
  }
}
