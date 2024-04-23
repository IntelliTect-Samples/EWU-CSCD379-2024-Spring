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
  public requiredLetters: Array<LetterHelper>;

  constructor(game: Game, wordList: Array<string> = myWordList) {
    this.lastIndexSetup = -1;
    this.requiredLetters = new Array<LetterHelper>();
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
    let result = this.wordList.filter(wordListWord => {
      let metCondition = this.filterWordList(wordListWord);
      for (
        let lettersIndex = 0;
        lettersIndex < this.letters.length;
        lettersIndex++
      ) {
        this.letters[lettersIndex].runningTotalDiscovered = 0;
      }
      return metCondition;
    });
    for (
      let lettersIndex = 0;
      lettersIndex < this.letters.length;
      lettersIndex++
    ) {
      this.letters[lettersIndex].runningTotalDiscovered = 0;
    }
    result = result.filter(wordListWord => {
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
    return result;
  }

  filterWordList(wordListWord: string): boolean {
    let characters = wordListWord.toUpperCase().split('');
    for (let index = 0; index < characters.length; index++) {
      let character = characters[index];
      let lettersIndex = character.charCodeAt(0) - 65;
      let letterHelper = this.letters[lettersIndex];
      letterHelper.runningTotalDiscovered++;
      if (
        (this.partialWord[index] !== undefined &&
          this.partialWord[index] !== character) ||
        !letterHelper.isValidForIndex[index]
      ) {
        return false;
      }
    }
    for (
      let lettersIndex = 0;
      lettersIndex < this.letters.length;
      lettersIndex++
    ) {
      let letter = this.letters[lettersIndex];
      if (letter.runningTotalDiscovered < letter.numberDiscoveredInWord) {
        return false;
      }
    }
    return true;
  }

  setup() {
    for (
      let guessesIndex = 0;
      guessesIndex < this.game.guessIndex;
      guessesIndex++
    ) {
      let guess = this.game.guesses[guessesIndex];
      for (
        let lettersIndex = 0;
        lettersIndex < this.letters.length;
        lettersIndex++
      ) {
        this.letters[lettersIndex].runningTotalDiscovered = 0;
      }
      if (!guess.isFilled) {
        return;
      }
      let lettersArray = guess.letters;
      for (let index = 0; index < lettersArray.length; index++) {
        let lettersIndex = lettersArray[index].char.charCodeAt(0) - 65;
        if (lettersArray[index].state === LetterState.Correct) {
          this.partialWord[index] = lettersArray[index].char;
          this.letters[lettersIndex].numberFound++;
          this.letters[lettersIndex].runningTotalDiscovered++;
        } else if (lettersArray[index].state === LetterState.Misplaced) {
          this.letters[lettersIndex].isValidForIndex[index] = false;
          this.letters[lettersIndex].runningTotalDiscovered++;
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
      for (
        let lettersIndex = 0;
        lettersIndex < this.letters.length;
        lettersIndex++
      ) {
        this.letters[lettersIndex].numberDiscoveredInWord =
          this.letters[lettersIndex].runningTotalDiscovered;
        this.letters[lettersIndex].runningTotalDiscovered = 0;
      }
    }
  }
}

class LetterHelper {
  public isValidForIndex: boolean[];
  public character: string;
  public numberInSecretWord: number;
  public numberFound: number;
  public numberDiscoveredInWord: number;
  public runningTotalDiscovered: number;

  constructor(character: string, game: Game) {
    this.isValidForIndex = [true, true, true, true, true];
    this.numberDiscoveredInWord = 0;
    this.runningTotalDiscovered = 0;
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
