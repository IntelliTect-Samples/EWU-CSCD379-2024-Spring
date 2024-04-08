import { Word } from "./word";

export enum GameState {
  Playing = 0,
  Won = 1,
  Loss = 2,
}

export class Game {
  public maxAttempts: number = 6;
  public guesses: Word[] = [];
  public wordToGuess: string;
  public state: GameState = GameState.Playing;

  constructor(wordToGuess: string) {
    this.wordToGuess = wordToGuess;
  }

  public guess(guess: string): void {
    if (this.state !== GameState.Playing) {
      return;
    }

    const word = new Word(guess);
    const guessedWord = new Word(this.wordToGuess);
    word.compare(guessedWord);
    this.guesses.push(word);
    this.updateGameState();
  }

  public updateGameState(): void {
    if (this.guesses[this.guesses.length - 1].checkForWin() === true) {
      this.state = GameState.Won;
    }
    if (this.guesses.length >= this.maxAttempts) {
      this.state = GameState.Loss;
    }
  }
}
