import { Word } from "./word";

export class Game {
  public maxAttempts: number;
  public guesses: Word[] = [];
  public secretWord: string;
  public guessIndex: number = 0;

  constructor(secretWord: string, maxAttempts: number = 6) {
    this.secretWord = secretWord;
    this.maxAttempts = maxAttempts;

    // Populate guesses with the correct number of empty words
    for (let i = 0; i < this.maxAttempts; i++) {
      this.guesses.push(
        new Word({ maxNumberOfLetters: this.secretWord.length })
      );
    }
  }

  public get guess() {
    return this.guesses[this.guessIndex];
  }

  public removeLastLetter() {
    this.guess.removeLastLetter();
  }

  public addLetter(letter: string) {
    this.guess.addLetter(letter);
  }

  public submitGuess() {
    this.guess.compare(this.secretWord);
    this.guessIndex++;
  }
}
