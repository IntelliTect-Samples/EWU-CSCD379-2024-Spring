import { Letter, LetterState } from "./letter";
import { WordList } from "./wordList";

interface WordOptions {
  maxNumberOfLetters?: number;
  word?: string;
}

export class Word {
  public letters: Letter[];

  constructor(wordOptions: WordOptions) {
    if (wordOptions.word) {
      this.letters = wordOptions.word.split("").map(char => new Letter(char));
    } else if (wordOptions.maxNumberOfLetters) {
      this.letters = Array.from({ length: wordOptions.maxNumberOfLetters }, () => new Letter(""));
    } else {
      throw new Error("WordOptions must have either maxNumberOfLetters or word");
    }
  }

  public addLetter(newLetter: string): void {
    const emptyLetterIndex = this.letters.findIndex(letter => !letter.char);
    if (emptyLetterIndex !== -1) {
      this.letters[emptyLetterIndex].char = newLetter;
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
    return this.letters.every(letter => letter.char);
  }

  public compare(secretWordString: string): boolean {
    secretWordString = secretWordString.toLowerCase();
    const secretWordLetters = secretWordString.split('');
    let isMatch = true;

    // First pass for correct letters
    this.letters.forEach((letter, index) => {
      if (letter.char.toLowerCase() === secretWordLetters[index]) {
        letter.state = LetterState.Correct;
        secretWordLetters[index] = null; // This letter is correctly positioned
      }
    });

    // Second pass for misplaced and wrong letters
    this.letters.forEach((letter, index) => {
      if (letter.state !== LetterState.Correct) {
        if (secretWordLetters.includes(letter.char.toLowerCase())) {
          letter.state = LetterState.Misplaced;
          secretWordLetters[secretWordLetters.indexOf(letter.char.toLowerCase())] = null; // Remove to prevent double matching
        } else {
          letter.state = LetterState.Wrong;
          isMatch = false;
        }
      }
    });

    return isMatch;
  }

  public get word(): string {
    return this.letters.map(letter => letter.char).join("");
  }

  public isValidWord(): boolean {
    return WordList.includes(this.word.toLowerCase());
  }

  public clear(): void {
    this.letters.forEach(letter => {
      letter.char = "";
      letter.state = LetterState.Unknown;
    });
  }

  public isCompatibleWith(otherWordString: string): boolean {
    // This method is not needed for the Wordle logic and can be removed if not used elsewhere
    return true;
  }

  public fill(wordString: string): void {
    wordString.split('').forEach((char, index) => {
      if (index < this.letters.length) {
        this.letters[index].char = char.toUpperCase();
      }
    });
  }
}
