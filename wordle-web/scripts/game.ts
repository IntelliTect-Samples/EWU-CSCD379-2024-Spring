import { Word } from "./word";

export class Game {
  public maxAttempts: number;
  public guesses: Word[] = [];
  public secretWord: string;
  public guessIndex: number = 0;
  public gameState: GameState = GameState.Playing;

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
    if(this.gameState === GameState.Playing){
      this.guess.removeLastLetter();
    }
  }

  public addLetter(letter: string) {
    if(this.gameState === GameState.Playing){
      this.guess.addLetter(letter);
    }
  }

  public submitGuess() {
    if(this.gameState !== GameState.Playing) return;
    if(!this.guess.isFilled()) return;

    if (this.guess.compare(this.secretWord)) {
      this.gameState = GameState.Won;
    } else {
      if (this.guessIndex === this.maxAttempts - 1) {
        this.gameState = GameState.Lost;
      } else {
        this.guessIndex++;
      }
    }
  }
}

export enum GameState {
  Playing,
  Won,
  Lost,
}
