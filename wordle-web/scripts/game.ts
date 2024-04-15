import { Word } from "./word";
import { WordList } from "./wordList";

export class Game {
  public maxAttempts: number;
  public guesses: Word[] = [];
  public secretWord: string = "";
  public guessIndex: number = 0;
  public gameState: GameState = GameState.Playing;

  constructor(maxAttempts: number = 6) {
    this.maxAttempts = maxAttempts;
    this.startNewGame();
  }

  public startNewGame() {
    this.guessIndex = 0;
    this.gameState = GameState.Playing;

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

  public submitGuess() {
    if (this.gameState !== GameState.Playing) return;
    if (!this.guess.isFilled()) return;
    if(!this.guess.isValidWord()){
      this.guess.clear();
      return;
    }

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
  public validateWord(word: string): Array<string> {
    const myList = new Array<string>();

    if(word == ''){
      return myList;
    }
    for (let i = 0; i < WordList.length; i++) {
      if (WordList[i].startsWith(word.toUpperCase())) {
        myList.push(WordList[i]);
      }
    }
    return myList;
  }

}

export enum GameState {
  Playing,
  Won,
  Lost,
}
