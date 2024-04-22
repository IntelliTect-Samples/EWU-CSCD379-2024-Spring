import { computed, ComputedRef, reactive, toRefs  } from 'vue';
import { LetterState, Letter } from "./letter";
import { WordList } from "./wordList";
import { Word } from "./word";

export enum GameState {
  Playing,
  Won,
  Lost,
}

export class Game {
  public maxAttempts: number;
  public guesses: Word[];
  public secretWord: string;
  public guessIndex: number;
  public gameState: GameState;
  public guessedLetters: Letter[];

  constructor(maxAttempts: number = 6) {
    this.maxAttempts = maxAttempts;
    this.secretWord = '';
    this.guessIndex = 0;
    this.gameState = GameState.Playing;
    this.guessedLetters = [];
    this.guesses = [];
    this.startNewGame();
  }

  public startNewGame() {
    this.guessIndex = 0;
    this.gameState = GameState.Playing;
    this.guessedLetters = [];

    // Get random word from word list
    this.secretWord =
      WordList[Math.floor(Math.random() * WordList.length)].toUpperCase();
    console.log(this.secretWord);

    // Populate guesses with the correct number of empty words
    this.guesses = [];
    for (let i = 0; i < this.maxAttempts; i++) {
      this.guesses.push(
        new Word({ maxNumberOfLetters: this.secretWord.length })
      );
    }
  }

  public get currentGuess(): Word {
    return this.guesses[this.guessIndex];
  }

  public removeLastLetter(): void {
    if (this.gameState === GameState.Playing) {
      this.currentGuess.removeLastLetter();
    }
  }

  public addLetter(letter: string): void {
    if (this.gameState === GameState.Playing && letter.length === 1) {
      this.currentGuess.addLetter(letter);
    }
  }

  public submitGuess(): void {
    if (this.gameState !== GameState.Playing) return;
    if (!this.currentGuess.isFilled) return;
    if (!this.currentGuess.isValidWord()) {
      this.currentGuess.clear();
      return;
    }

    const isCorrect = this.currentGuess.compare(this.secretWord);
    this.updateGuessedLetters();

    if (isCorrect) {
      this.gameState = GameState.Won;
    } else {
      if (this.guessIndex >= this.maxAttempts - 1) {
        this.gameState = GameState.Lost;
      } else {
        this.guessIndex++;
      }
    }
  }

  get validWords(): string[] {
    return WordList.filter(word => this.guesses.every(guess => guess.isCompatibleWith(word)));
  }

  public addGuess(word: string): void {
    if (this.gameState === GameState.Playing && word.length === this.secretWord.length) {
      this.currentGuess.fill(word.toUpperCase());
    }
  }

  public updateGuessedLetters(): void {
    for (const letter of this.currentGuess.letters) {
      const index = this.guessedLetters.findIndex(
        (existingLetter) => existingLetter.char === letter.char
      );
      if (index !== -1) {
        if (letter.state !== LetterState.Correct) {
          this.guessedLetters[index] = letter;
        }
      } else {
        this.guessedLetters.push(letter);
      }
    }
  }
}

// Create a reactive instance of Game to be used across the application
const gameInstance = reactive(new Game());

export function useGame() {
  // Create reactive references for the game instance properties and methods
  return {
    ...toRefs(gameInstance),
    // Directly return the reactive reference for validWords
    validWords: gameInstance.validWords,
    addGuess: gameInstance.addGuess.bind(gameInstance),
    startNewGame: gameInstance.startNewGame.bind(gameInstance),
    submitGuess: gameInstance.submitGuess.bind(gameInstance),
    updateGuessedLetters: gameInstance.updateGuessedLetters.bind(gameInstance),
  };
}
