import { Letter, LetterState } from "./letter";
import { WordList } from "./wordList";

export class Word {
  public letters: Letter[];

  constructor(wordOptions: WordOptions) {
    if (wordOptions.word) {
      this.letters = wordOptions.word.split("").map((char) => new Letter(char));
    } else if (wordOptions.maxNumberOfLetters) {
      this.letters = [];
      for (let i = 0; i < wordOptions.maxNumberOfLetters; i++) {
        this.letters.push(new Letter(""));
      }
    } else {
      throw new Error(
        "WordOptions must have either maxNumberOfLetters or word"
      );
    }
  }

  public addLetter(newLetter: string): void {
    for (const letter of this.letters) {
      if (!letter.char) {
        letter.char = newLetter;
        break;
      }
    }
  }

  public removeLastLetter(): void {
    for (let i = this.letters.length - 1; i >= 0; i--) {
      if (this.letters[i].char) {
        this.letters[i].char = "";
        break;
      }
    }
  }
  public get isFilled(): boolean {
    return this.letters.every((letter) => letter.char);
  }

  public compare(secretWordString: string): boolean {
    const secretWord = new Word({ word: secretWordString });
    let isMatch = true;

    for (const [i, letter] of secretWord.letters.entries()) {
      if (letter.char === this.letters[i].char) {
        this.letters[i].state = LetterState.Correct;
        letter.state = LetterState.Correct;
      }else{
        isMatch = false;
      }
    }
    for (const guessedLetter of this.letters) {
      if (guessedLetter.state === LetterState.Unknown) {
        for (const toGuessLetter of secretWord.letters) {
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

    return isMatch;
  }

  public get word(): string {
    return this.letters.map((x) => x.char).join("");
  }

  public isValidWord() {
    return WordList.includes(this.word.toLowerCase());
  }

  public clear() {
    for (const letter of this.letters) {
      letter.char = "";
    }
  }
}

class WordOptions {
  maxNumberOfLetters?: number = 0;
  word?: string | null = null;
}
