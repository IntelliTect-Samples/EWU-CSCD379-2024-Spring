import { WordList } from "./wordList";
import { Game } from "./game";
import { LetterState } from "./letter";

export function updateValidWords(game: Game): string[] {
    return WordList.filter((word) => {
        for (let i = 0; i < game.guessedLetters.length; i++) {
            var guessedLetterObj = game.guessedLetters[i];
            var guessedLetterChar = guessedLetterObj.char.toLowerCase();
            var guessedLetterState = guessedLetterObj.state;
            var indexInWord = word.indexOf(guessedLetterChar);
            var indexInSecretWord = game.secretWord.toLowerCase().indexOf(guessedLetterChar);
            if (word.includes(guessedLetterChar)){
                //Word has letter, letter is wrong
                if(game.guessedLetters[i].state === LetterState.Wrong){
                    return false;
                }
                //Word has letter, letter is in wrong spot
                if(guessedLetterState === LetterState.Correct || guessedLetterObj.state === LetterState.Misplaced){
                    if(indexInWord !== indexInSecretWord){
                        return false;
                    }
                }
            }
            if (!word.includes(guessedLetterChar)){
                //Word doesnt have letter but letter is correct
                if(guessedLetterState === LetterState.Correct){
                    return false;
                }
                //word doesnt have letter but letter is misplaced
                if(guessedLetterState === LetterState.Misplaced){
                    return false;
                }
            }
        }
        return true;
    });
}