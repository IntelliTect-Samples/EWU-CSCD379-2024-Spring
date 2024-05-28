<template>
  <v-container>
    <v-card color="secondary" class="mx-auto pa-8 rounded text-center">
      <v-card-title class="text-wrap text-h5">
        How to play Aesthetic Wordle
      </v-card-title>
      <v-tabs v-model="currentPage" align-tabs="center">
        <v-tab>Page 1</v-tab>
        <v-tab>Page 2</v-tab>
      </v-tabs>
      <v-tabs-window v-model="currentPage">
        <v-tabs-window-item>
          <v-card-text class="text-body-1">
            Wordle is a poetic journey through language, where each guess paints
            a delicate picture of meaning on the canvas of possibility,
            revealing the hidden hues of words until the final stroke unveils
            the masterpiece of understanding. Just start guessing and the magic
            begins!
          </v-card-text>
          <v-card-text class="text-h6 text-weight-bold">
            The color codes mean:
          </v-card-text>
          <v-card-text class="ml-3 text-body-1">
            <v-row>
              <v-col>
                <v-icon color="correct">mdi-checkbox-blank-circle</v-icon>
                Is in the correct position and is the right letter.
              </v-col>
            </v-row>
            <v-row>
              <v-col>
                <v-icon color="misplaced">mdi-checkbox-blank-circle</v-icon>
                Is in the word but is in a misplaced position.
              </v-col>
            </v-row>

            <v-row>
              <v-col>
                <v-icon color="wrong">mdi-checkbox-blank-circle</v-icon>
                Is not in the word at all and is wrong.
              </v-col>
            </v-row>
          </v-card-text>
          <v-card-text class="text-body-1">
            For example, if the word is "DAISY" and you guess "BASED", the
            feedback might look like this:
          </v-card-text>
          <v-card-item>
            <GameBoardGuess :guess="exampleWord" />
          </v-card-item>

          <v-card-item>
            <v-label class="text-body-1"></v-label>
            <v-container class="justify-center align-center pa-3">
              <v-row>
                <v-col
                  class="pa-2 d-flex ga-4 align-center justify-center flex-wrap"
                >
                  <LetterResult
                    v-for="letter in key.letters"
                    :key="letter.char"
                    :letter="letter"
                    :clickable="false"
                    class="d-flex align-center justify-center pa-4"
                    style="width: 150px"
                  />
                </v-col>
              </v-row>
            </v-container>
          </v-card-item>
        </v-tabs-window-item>
        <v-tabs-window-item>
          <v-card-text class="text-body-1">
            There are two variations of the game you can play -
            <b>Daily Wordle</b> and <b>Random Wordle.</b> Simply choose your
            desired game mode. We have many features on the right during the
            game to help.
          </v-card-text>
          <v-card-text class="text-body-1">
            <v-card-item>
              <v-col>
                <v-icon>mdi-timer</v-icon>
                This will start the clock and time you as you play the game.
                This is used in our leaderboard!
              </v-col>
            </v-card-item>

            <v-card-item>
              <v-col>
                <v-btn
                  class="bg-primary pa-2 px-5"
                  to="/leaderboard"
                  text="View Leaderboard"
                />
              </v-col>
            </v-card-item>

            <v-card-item>
              <v-col>
                <v-icon>mdi-book</v-icon>
                This feature is a word bank that filters words to help you guess
                if you get stuck. Use it wisely!
              </v-col>
            </v-card-item>
            <v-card-item>
              <v-col>
                <v-icon> mdi-flag-variant</v-icon>
                This will restart your game if you wish to reset and start over.
              </v-col>
            </v-card-item>
            <v-card-item>
              <v-col>
                We also have a <v-icon> mdi-account</v-icon> username box to
                edit and save your name for our leaderboard. Have fun!
              </v-col>
            </v-card-item>
          </v-card-text>
          <v-card-text class="ml-3 text-body-1"> </v-card-text>
          <v-card-text class="text-body-1"> </v-card-text>
        </v-tabs-window-item>
      </v-tabs-window>
      <v-divider />
      <v-card-actions class="d-flex justify-center my-1">
        <v-btn
          color="white"
          class="bg-primary pa-2 px-5"
          to="/"
          text="Go Home"
        />
      </v-card-actions>
    </v-card>
  </v-container>
</template>

<script setup lang="ts">
import { Letter, LetterState } from "~/scripts/letter";
import { Word } from "~/scripts/word";

useHead({
  title: "How to Play",
  meta: [{ name: "description", content: "Cool site!" }],
});

const exampleWord = new Word({ word: "BASED" });
exampleWord.letters = [
  new Letter("B", LetterState.Wrong),
  new Letter("A", LetterState.Correct),
  new Letter("S", LetterState.Misplaced),
  new Letter("E", LetterState.Wrong),
  new Letter("D", LetterState.Misplaced),
];

const key = {
  letters: [
    new Letter("Correct", LetterState.Correct),
    new Letter("Misplaced", LetterState.Misplaced),
    new Letter("Wrong", LetterState.Wrong),
  ],
};

const currentPage = ref(0);
</script>
