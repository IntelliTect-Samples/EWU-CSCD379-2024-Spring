import { Word } from '~/scripts/word';
import { myWordList } from '~/scripts/wordList';
import { Game } from '~/scripts/game';
import { Letter, LetterState } from '~/scripts/letter';

export class ValidWordsUtils {
  public letters: LetterHelper[];
  public partialWord: Array<string | undefined> = new Array(5);
  public wordList: Array<string>;
  public count: number;
  public game: Game;
  public lastIndexSetup: number;
  constructor(game: Game, wordList: Array<string> = myWordList) {
    this.lastIndexSetup = -1;
    this.game = game;
    this.count = 0;
    this.wordList = wordList;
    this.partialWord = Array.from({ length: 5 }, (v, k) => undefined);
    this.letters = Array.from({ length: 26 }, (v, k) => {
      let character = String.fromCharCode(65 + k);
      return new LetterHelper(character, game);
    });
  }

  validWords(): Array<string> {
    this.setup();
    let result = this.wordList.filter(wordListWord =>
      this.filterWordList(wordListWord)
    );
    return result.filter(wordListWord => {
      let lettersEntered = this.game.guesses[this.game.guessIndex].letters;
      let lettersLength = lettersEntered.length;
      let count = 0;
      while (count < lettersLength && lettersEntered[count].char !== '') {
        if (wordListWord[count].toUpperCase() !== lettersEntered[count].char) {
          return false;
        }
        count++;
      }
      return true;
    });
  }

  filterWordList(wordListWord: string): boolean {
    let characters = wordListWord.toUpperCase().split('');
    for (let index = 0; index < characters.length; index++) {
      let character = characters[index];
      let lettersIndex = character.charCodeAt(0) - 65;
      let letterHelper = this.letters[lettersIndex];
      if (
        (this.partialWord[index] !== undefined &&
          this.partialWord[index] !== character) ||
        !letterHelper.isValidForIndex[index]
      ) {
        return false;
      }
    }
    return true;
  }

  setup() {
    // let index = 0;
    // if (this.game.guessIndex - 1 === this.lastIndexSetup) {
    //   index = this.game.guessIndex;
    //   this.lastIndexSetup = this.game.guessIndex;
    // }
    for (let index = 0; index < this.game.guessIndex; index++) {
      let guess = this.game.guesses[index];
      if (!guess.isFilled) {
        return;
      }
      let lettersArray = guess.letters;
      for (let index = 0; index < lettersArray.length; index++) {
        let lettersIndex = lettersArray[index].char.charCodeAt(0) - 65;
        if (lettersArray[index].state === LetterState.Correct) {
          this.partialWord[index] = lettersArray[index].char;
          this.letters[lettersIndex].numberFound++;
        } else if (lettersArray[index].state === LetterState.Misplaced) {
          this.letters[lettersIndex].isValidForIndex[index] = false;
        } else if (lettersArray[index].state === LetterState.Wrong) {
          let letterHelper = this.letters[lettersIndex];
          if (letterHelper.numberFound === letterHelper.numberInSecretWord) {
            this.letters[lettersIndex].isValidForIndex = Array.from(
              { length: this.partialWord.length },
              (v, k) => {
                return (
                  this.partialWord[k] === this.letters[lettersIndex].character
                );
              }
            );
          } else {
            this.letters[lettersIndex].isValidForIndex[index] = false;
          }
        }
      }
    }
  }
}

class LetterHelper {
  public isValidForIndex: boolean[];
  public character: string;
  public numberInSecretWord: number;
  public numberFound: number;

  constructor(character: string, game: Game) {
    this.isValidForIndex = [true, true, true, true, true];
    this.character = character;
    let secretWord = game.secretWord;
    this.numberInSecretWord = 0;
    for (let index = 0; index < secretWord.length; index++) {
      if (secretWord[index] === character) {
        this.numberInSecretWord++;
      }
    }
    this.numberFound = 0;
  }
}
