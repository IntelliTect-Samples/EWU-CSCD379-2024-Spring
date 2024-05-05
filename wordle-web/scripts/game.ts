import { LetterState, type Letter } from "./letter";
import { Word } from "./word";
import { WordList } from "./wordList";
import { findValidWords } from "./ValidWordList";


export class Game {
  public maxAttempts: number;
  public guesses: Word[] = [];
  public secretWord: string = "";
  public guessIndex: number = 0;
  public gameState: GameState = GameState.Playing;
  public guessedLetters: Letter[] = [];
  //public validWordList: string[] = [];

  constructor(secretWord: string, maxAttempts: number = 6) {
    this.maxAttempts = maxAttempts;
    this.secretWord = secretWord.toUpperCase();
    this.startNewGame();
  }

  public startNewGame() {
    this.guessIndex = 0;
    this.gameState = GameState.Playing;
    this.guessedLetters = [];
    
    // Populate guesses with the correct number of empty words
    this.guesses = [];
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
    if (this.gameState === GameState.Playing) {
      this.guess.removeLastLetter();
    }
  }

  public addLetter(letter: string) {
    if (this.gameState === GameState.Playing) {
      this.guess.addLetter(letter);
    }
  }

  public submitGuess() {
    if (this.gameState !== GameState.Playing) return;
    if (!this.guess.isFilled) return;
    if (!this.guess.isValidWord()) {
      this.guess.clear();
      return;
    }

    const isCorrect = this.guess.compare(this.secretWord);
    this.updateGuessedLetters();
    //this.validWordList = findValidWords(this.guesses, this.guessIndex, this.validWordList);


    if (isCorrect) {
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
