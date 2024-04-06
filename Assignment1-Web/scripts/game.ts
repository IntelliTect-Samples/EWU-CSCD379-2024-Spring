import { Word } from "./word";

export class Game {
  public maxAttempts: number = 6;
  public guesses: Word[] = [];
  public wordToGuess: string;

  constructor(wordToGuess: string) {
    this.wordToGuess = wordToGuess;
  }

  public guess(guess: string) {
    const word = new Word(guess);
    word.compare(this.wordToGuess);
    this.guesses.push(word);
  }
}