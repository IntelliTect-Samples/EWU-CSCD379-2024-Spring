import { LetterState, type Letter } from "./letter";
import { Word } from "./word";
import { WordList } from "./wordList";

export class Game {
  public maxAttempts: number;
  public guesses: Word[] = [];
  public secretWord: string = "";
  public guessIndex: number = 0;
  public gameState: GameState = GameState.Playing;
  public guessedLetters: Letter[] = [];

  constructor(maxAttempts: number = 6) {
    this.maxAttempts = maxAttempts;
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

  private updateGuessedLetters() {
    for (const letter of this.guess.letters) {
      // Find the index of the letter in the guessed letters array
      const index = this.guessedLetters.findIndex(
        (existingLetter) => existingLetter.char === letter.char
      );

      if (index !== -1) {
        // Do not update the letter if it is already correct
        if (this.guessedLetters[index].state !== LetterState.Correct) {
          // Do not update the letter if it wrong
          if (letter.state !== LetterState.Wrong) {
            this.guessedLetters[index] = letter;
          }
        }
      } else {
        // If the letter does not already exist, add it to the array
        this.guessedLetters.push(letter);
      }

      this.guessedLetters.push(letter);
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
