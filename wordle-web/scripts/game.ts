import { computed, reactive, toRefs } from 'vue';
import { LetterState, Letter } from './letter';
import { WordList } from './wordList';
import { Word } from './word';

export enum GameState {
  Playing,
  Won,
  Lost,
}

export class Game {
  maxAttempts: number = 6;
  guesses: Word[] = [];
  secretWord: string = '';
  guessIndex: number = 0;
  gameState: GameState = GameState.Playing;
  guessedLetters: Letter[] = [];

  constructor(maxAttempts: number = 6) {
    this.maxAttempts = maxAttempts;
    this.startNewGame();
  }

  startNewGame() {
    this.guessIndex = 0;
    this.gameState = GameState.Playing;
    this.guessedLetters = [];
    this.secretWord = WordList[Math.floor(Math.random() * WordList.length)].toUpperCase();
    this.guesses = Array.from({ length: this.maxAttempts }, () => new Word({ maxNumberOfLetters: this.secretWord.length }));
    console.log("Secret word: ", this.secretWord);
  }

  get currentGuess(): Word {
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
      let existingLetterIndex = this.guessedLetters.findIndex(l => l.char.toUpperCase() === letter.toUpperCase());
      if (existingLetterIndex !== -1) {
        this.guessedLetters[existingLetterIndex].state = LetterState.Unknown;
      } else {
        this.guessedLetters.push(new Letter(letter, LetterState.Unknown));
      }
      this.guessedLetters = [...this.guessedLetters]; // Ensure reactive update
    }
  }

  public submitGuess(): void {
    if (this.gameState !== GameState.Playing || !this.currentGuess.isFilled || !this.currentGuess.isValidWord()) {
      return;
    }

    const isCorrect = this.currentGuess.compare(this.secretWord);
    this.updateGuessedLetters();

    if (isCorrect) {
      this.gameState = GameState.Won;
    } else if (this.guessIndex >= this.maxAttempts - 1) {
      this.gameState = GameState.Lost;
    } else {
      this.guessIndex++;
    }
  }

public validWords(): string[] {
  console.log("Recalculating valid words...");
  return WordList.filter((word) => {
    word = word.toLowerCase();

    // Words are invalidated if they have a 'Wrong' letter or if they lack a 'Correct' or 'Misplaced' letter
    const isInvalid = this.guessedLetters.some((guessedLetter) => {
      const letter = guessedLetter.char.toLowerCase();
      const index = this.guessedLetters.indexOf(guessedLetter);
      const isCorrect = guessedLetter.state === LetterState.Correct && word[index] !== letter;
      const isMisplaced = guessedLetter.state === LetterState.Misplaced && (!word.includes(letter) || word[index] === letter);
      const isWrong = guessedLetter.state === LetterState.Wrong && word.includes(letter);

      return isCorrect || isMisplaced || isWrong;
    });

    return !isInvalid;
  });
}


  public addGuess(word: string): void {
    if (this.gameState !== GameState.Playing) return;
    this.currentGuess.fill(word.toUpperCase());
    this.submitGuess();
    this.guesses = [...this.guesses]; // Ensure reactivity
  }

  public updateGuessedLetters(): void {
    this.currentGuess.letters.forEach((letter) => {
      const existingLetterIndex = this.guessedLetters.findIndex(l => l.char === letter.char);
      if (existingLetterIndex !== -1) {
        if (letter.state > this.guessedLetters[existingLetterIndex].state) {
          this.guessedLetters[existingLetterIndex] = new Letter(letter.char, letter.state);
        }
      } else {
        this.guessedLetters.push(new Letter(letter.char, letter.state));
      }
    });
    this.guessedLetters = [...this.guessedLetters]; // Force reactivity
  }
}

const gameInstance = reactive(new Game());

export function useGame() {
  const refs = toRefs(gameInstance);
  const validWords = computed(() => gameInstance.validWords());

  return {
    ...refs,
    validWords,
    addGuess: gameInstance.addGuess.bind(gameInstance),
    startNewGame: gameInstance.startNewGame.bind(gameInstance),
    submitGuess: gameInstance.submitGuess.bind(gameInstance),
    updateGuessedLetters: gameInstance.updateGuessedLetters.bind(gameInstance),
  };
}
