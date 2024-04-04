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

    for (const [i, guessedLetter] of wordToGuess.letters.entries()) {
      if (guessedLetter.state === LetterState.Unknown) {
        for (const [j, letter] of this.letters.entries()) {
          if ( letter.state === LetterState.Unknown &&
            letter.char === guessedLetter.char) {
            this.letters[j].state = LetterState.Misplaced;
            guessedLetter.state = LetterState.Misplaced;
            break;
          }
          this.letters[j].state = LetterState.Wrong;
        }
      }
    }
  }
}
