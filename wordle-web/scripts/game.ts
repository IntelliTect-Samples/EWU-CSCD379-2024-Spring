import axios from 'axios';
import { LetterState, type Letter } from './letter';
import { Word } from './word';
import { WordList } from './wordList';
import Axios from 'axios';

export class Game {
  public maxAttempts: number;
  public guesses: Word[] = [];
  public guessIndex: number = 0;
  public gameState: GameState = GameState.Playing;
  public guessedLetters: Letter[] = [];

  private _secretWord: string = '';
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

  public async startNewGame(word?: string | undefined) {
    // Load the game
    this.gameState = GameState.Initializing;

    // Reset default values
    this.guessIndex = 0;
    this.guessedLetters = [];

    // Get a word
    if (!word) {
      this.secretWord = await this.getWordOfTheDayFromApi();
    } else {
      this.secretWord = word;
    }

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

  public setGuessLetters(word: string) {
    // Loop through the word and add new letters
    this.guess.clear();
    for (let i = 0; i < word.length; i++) {
      this.addLetter(word[i].toUpperCase());
    }
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
        existingLetter => existingLetter.char === letter.char
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
    } else {
      if (this.guessIndex === this.maxAttempts - 1) {
        this.gameState = GameState.Lost;
      } else {
        this.guessIndex++;
      }
    }
  }
  public validateWord(word: string): Array<string> {
    const myList = new Array<string>();

    if (word == '') {
      return myList;
    }
    for (let i = 0; i < WordList.length; i++) {
      if (WordList[i].startsWith(word.toUpperCase())) {
        myList.push(WordList[i]);
      }
    }
    return myList;
  }

  public async getWordOfTheDayFromApi(): Promise<string> {
    try {
      debugger;
      const response = await axios.get('/word/wordOfTheDay');
      this.secretWord = response.data;

      console.log('Response from API: ' + response.data);
      console.log('Secret Word: ' + this.secretWord);
      return response.data;
    } catch (error) {
      console.error('Error fetching word of the day:', error);
      return 'ERROR'; // Probably best to print the error on screen, but this is kind of funny. :)
    }
  }
}

export enum GameState {
  Playing,
  Won,
  Lost,
  Initializing,
}
