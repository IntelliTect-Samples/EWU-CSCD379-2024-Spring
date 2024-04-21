import { Word } from '~/scripts/word';
import { myWordList } from '~/scripts/wordList';
import { Game } from '~/scripts/game';
import { Letter, LetterState } from '~/scripts/letter';

export class ValidWordsUtils {
  public game: Game;
  public letters: LetterHelper[];
  public partialWord: Array<string | undefined> = new Array(5);
  constructor(game: Game) {
    this.game = game;
    this.letters = Array.from({ length: 26 }, (v, k) => {
      let character = String.fromCharCode(97 + k);
      this.partialWord = Array.from({ length: 5 }, (v, k) => undefined);
      return new LetterHelper(character);
    });
  }

  validWords(): Array<string> {
    const guess = this.game.guess;
    const guessString = guess.word;
    this.setup();
    if (guessString == '') {
      return myWordList;
    } else {
      const validWordsList = new Array<string>();
      return myWordList.filter(wordListWord => this.method(wordListWord));
    }
  }

  method(wordListWord: string): boolean {
    let characters = wordListWord.split('');
    for (let index = 0; index < characters.length; index++) {
      let character = characters[index];
      let lettersIndex = character.charCodeAt(0) - 97;
      let letterHelper = this.letters[lettersIndex];
      if (!letterHelper.isValidForIndex[index]) {
        return false;
      }
    }
    return true;
  }

  setup() {
    this.game.guesses.forEach(guess => {
      let lettersArray = guess.letters;
      for (let index = 0; index < lettersArray.length; index++) {
        if (lettersArray[index].state === LetterState.Correct) {
          this.partialWord[index] = lettersArray[index].char;
        } else if (lettersArray[index].state === LetterState.Misplaced) {
          let lettersIndex = lettersArray[index].char.charCodeAt(0) - 97;
          this.letters[lettersIndex].isValidForIndex[index] = false;
        } else if (lettersArray[index].state === LetterState.Wrong) {
          let lettersIndex = lettersArray[index].char.charCodeAt(0) - 97;
          this.letters[lettersIndex].isValidForIndex = [
            false,
            false,
            false,
            false,
            false,
          ];
        }
      }
    });
  }
}

class LetterHelper {
  public isValidForIndex: boolean[];
  public character: string;

  constructor(character: string) {
    this.isValidForIndex = [true, true, true, true, true];
    this.character = character;
  }
}
