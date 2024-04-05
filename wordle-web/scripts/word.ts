import { Letter, LetterState } from "./letter";

export class Word {
  public letters: Letter[];

  constructor(word: string) {
    this.letters = word.split("").map((char) => new Letter(char));
  }

  public compare(wordToGuessInput: string): void {
    const wordToGuess = new Word(wordToGuessInput);

    for (const [i, letter] of wordToGuess.letters.entries()) {
      if (letter.char === this.letters[i].char) {
        this.letters[i].state = LetterState.Correct;
        letter.state = LetterState.Correct;
      }
    }
    // TODO: Fix this. :)
    for (const guessedLetter of this.letters) {
      if (guessedLetter.state === LetterState.Unknown) {
        for (const toGuessLetter of wordToGuess.letters) {
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
}
