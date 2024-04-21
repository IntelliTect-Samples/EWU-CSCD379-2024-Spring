import { Word } from '~/scripts/word';
import { myWordList } from '~/scripts/wordList';
import { Game } from '~/scripts/game';

export class ValidWordsUtils {
  public game: Game;
  constructor(game: Game) {
    this.game = game;
  }

  validWords(): Array<string> {
    const guess = this.game.guess;
    const guessString = guess.word;
    if (guessString == '') {
      return myWordList;
    } else {
      const validWordsList = new Array<string>();
      return myWordList.filter(wordListWord =>
        this.method(wordListWord, guess)
      );
    }
  }

  method(wordListWord: string, guess: Word): boolean {
    return true;
  }
}
