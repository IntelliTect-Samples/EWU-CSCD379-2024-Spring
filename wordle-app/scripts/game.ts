import { LetterState, type Letter } from "./letter";
import { Word } from "./word";
import { WordList } from "./wordList";
import nameUserNameDialog from "../pages/index.vue"
import stopwatch from "../pages/index.vue"
import Axios from "axios";

export class Game {
  public maxAttempts: number;
  public guesses: Word[] = [];
  //public secretWord: string = "";
  public guessIndex: number = 0;
  public gameState: GameState = GameState.Playing;
  public guessedLetters: Letter[] = [];

  private _secretWord: string = "";
  private set secretWord(value: string) {
    this._secretWord = value.toUpperCase();
  }
  public get secretWord(): string {
    return this._secretWord;
  }

  constructor(maxAttempts: number = 6) {
    this.maxAttempts = maxAttempts;
    this.gameState = GameState.Initializing;
  }

  public async startNewGame() {
    // Load the game
    this.gameState = GameState.Initializing;

    // Reset default values
    this.guessIndex = 0;
    this.guessedLetters = [];

    // Get a random word
    await this.getWordOfTheDayFromApi();

    // Populate guesses with the correct number of empty words
    this.guesses = [];
    for (let i = 0; i < this.maxAttempts; i++) {
      this.guesses.push(
        new Word({ maxNumberOfLetters: this.secretWord.length })
      );
    }

    // Start the game
    this.gameState = GameState.Playing;
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

  public updateGuessedLetters() {
    for (const letter of this.guess.letters) {
      // Find the index of the letter in the guessed letters array
      const index = this.guessedLetters.findIndex(
        (existingLetter) => existingLetter.char === letter.char
      );
      if (index !== -1) {
        // Do not update the letter if it is already correct
        if (this.guessedLetters[index].state !== LetterState.Correct) {
          // Do not update the letter if it is wrong
          if (letter.state !== LetterState.Wrong) {
            this.guessedLetters[index] = letter;
          }
        }
      } else {
        // If letter does not already exist, add it to the array
        this.guessedLetters.push(letter);
      }
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
      //this.postScore();
    } else {
      if (this.guessIndex === this.maxAttempts - 1) {
        this.gameState = GameState.Lost;
        //this.postScore();
      } else {
        this.guessIndex++;
      }
    }
  }

  public async getWordOfTheDayFromApi() {
    try {
      let wordUrl = "https://wordleapiewusergeitim.azurewebsites.net/Word/WordOfTheDay";
      const response = await Axios.get(wordUrl);
      console.log("Response from API:" + response.data);

      this.secretWord = response.data;

    } catch (error) {
      console.error("Error fetching word of the day:", error);
      this.secretWord = "ERROR";
    }
  }

  // public postScore() {
  //   let attempts = 0;
  //   if (this.gameState == GameState.Won) {
  //     attempts = this.guessIndex + 1;
  //   } else {
  //     attempts = this.maxAttempts;
  //   }
  //   axios.post("https://wordleapiewusergeitim.azurewebsites.net/Player/AddPlayer", {
  //     Name: nameUserNameDialog,
  //     GameCount: 1,
  //     AverageAttempts: attempts,
  //     AverageSecondsPerGame: stopwatch.seconds.value
  //   });
  // }
}

export enum GameState {
  Playing,
  Won,
  Lost,
  Initializing,
}
