<!--<template>
  <v-container>
    <v-card>
      <v-sheet color="primary">
        <v-card-text> How to play Wordle </v-card-text>
      </v-sheet>
      <v-card-text>
        Wordle is a word puzzle game where you have to guess a five-letter word
        within a certain number of attempts. After each guess, Wordle will
        provide feedback to indicate if each letter:
        <ul>
          <spacer></spacer>
          <li>Is in the correct position and is the right letter.</li>
          <li>Is in the word but in the wrong position.</li>
          <li>Is not in the word at all.</li>
        </ul>
      </v-card-text>
      <v-card-text>
        For example, if the word is "BLIMP" and you guess "BILBO", the feedback
        might look like this:
      </v-card-text>
      <div class="d-flex justify-center mt-3 mb-5">
        <GameBoardGuess :guess="exampleWord" />
      </div>

      <v-divider />
      <v-card-actions>
        <v-spacer></v-spacer>
      </v-card-actions>
    </v-card>
  </v-container>
</template>

<script setup lang="ts">
import { Letter, LetterState } from "~/scripts/letter";
import { Word } from "~/scripts/word";

const modelValue = defineModel<boolean>({ default: false });

const exampleWord = new Word({ word: "BILBO" });
exampleWord.letters = [
    new Letter("B", LetterState.Correct),
    new Letter("I", LetterState.Correct),
    new Letter("L", LetterState.Misplaced),
    new Letter("B", LetterState.Wrong),
    new Letter("O", LetterState.Wrong),
]
</script>-->


<template>
    <v-container>
        <v-card>
            <v-sheet color="primary">
                <v-card-text>How to Play Wordle</v-card-text>
            </v-sheet>
            <v-card-text>
                Wordle is a classic variation of the game Wordle. The objective is to guess the five-letter Word of the Day in six tries or fewer. Each guess must be a five-letter word. After each guess, you'll receive feedback on your accuracy:
                <ul>
                    <li style="padding-left: 20px;"> <strong>Green</strong> letters indicate correct letters in the correct position.</li>
                    <li style="padding-left: 20px;"> <strong>Yellow</strong> letters indicate correct letters in the wrong position.</li>
                    <li style="padding-left: 20px;"> <strong>Any Other Color</strong> indicates incorrect letters.</li>
                </ul>
            </v-card-text>
            <v-card-text>
                <strong>Example:</strong>
                <br>
                If the Word of the Day is "PLANT" and you guess "PLANT," all letters will be green:
            </v-card-text>

            <div class="d-flex justify-center mt-3 mb-5">
                <GameBoardGuess :guess="exampleWord" />
            </div>

            <v-card-text>
                If you guess "ALERT," you will see "A" and "L" in yellow and "T" in green:
            </v-card-text>
            <div class="d-flex justify-center mt-3 mb-5">
                <GameBoardGuess :guess="exampleWord2" />
            </div>
            <v-card-text> 
            <strong>Additional Features:</strong>
            <ul>
                <li style="padding-left: 20px;"><strong>Cheat button:</strong> Shows all possible words based on your previous guesses and current letters.</li>
                <li style="padding-left: 20px;"><strong>Settings button:</strong> Allows you to change the game's theme, with options including regular, jungle, flamingo, and Wordle themes in both light and dark versions.</li>
                <li style="padding-left: 20px;"><strong>Leaderboard:</strong> Displays the top 10 players.</li>
                <li style="padding-left: 20px;"><strong>Keyboard:</strong> Allows you to type in your guesses.</li>
                <li style="padding-left: 20px;"><strong>Game modes:</strong> Play games from specific days or play a random game.</li>
            </ul>
            </v-card-text>
            <v-divider />
            <v-card-actions>
                <v-spacer></v-spacer>
            </v-card-actions>
        </v-card>
    </v-container>
</template>

<script setup lang="ts">
    import { Letter, LetterState } from "~/scripts/letter";
    import { Word } from "~/scripts/word";

    const modelValue = defineModel<boolean>({ default: false });

    const exampleWord2 = new Word({ word: "ALERT" });
    exampleWord2.letters = [
        new Letter("A", LetterState.Misplaced),
        new Letter("L", LetterState.Correct),
        new Letter("E", LetterState.Wrong),
        new Letter("R", LetterState.Wrong),
        new Letter("T", LetterState.Correct),
    ]

    const exampleWord = new Word({ word: "PLANT" });
    exampleWord.letters = [
        new Letter("P", LetterState.Correct),
        new Letter("L", LetterState.Correct),
        new Letter("A", LetterState.Correct),
        new Letter("N", LetterState.Correct),
        new Letter("T", LetterState.Correct),
    ]
</script>
