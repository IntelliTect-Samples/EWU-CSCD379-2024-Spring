<template>
  <v-container>
    <v-card
      color="secondary"
      class="mx-auto pa-8 rounded text-center"
      elevation="4"
    >
      <v-card-title class="text-wrap text-h5">
        How to play Aesthetic Wordle (Cont)
      </v-card-title>
      <v-card-text class="text-body-1">
        There are two variations of the game you can play -
        <b>Daily Wordle</b> and <b>Random Wordle.</b> Simply choose your desired
        game mode. We have many features on the right during the game to help.
      </v-card-text>
      <v-card-text class="text-body-1">
        <v-card-item>
          <v-col>
            <v-icon>mdi-timer</v-icon>
            This will start the clock and time you as you play the game. This is
            used in our leaderboard!
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
            This feature is a word bank that filters words to help you guess if
            you get stuck. Use it wisely!
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
            We also have a <v-icon> mdi-account</v-icon> username box to edit
            and save your name for our leaderboard. Have fun!
          </v-col>
        </v-card-item>
      </v-card-text>
      <v-card-text class="ml-3 text-body-1"> </v-card-text>
      <v-card-text class="text-body-1"> </v-card-text>
      <v-card-item> </v-card-item>

      <v-divider />
      <v-card-actions class="d-flex justify-center">
        <v-btn
          color="white"
          class="bg-primary pa-2 px-5"
          to="/instructions"
          text="Go Back"
          prepend-icon="mdi-arrow-left"
        />
        <v-btn
          color="white"
          class="bg-primary pa-2 px-5"
          to="/"
          text="Start Playing"
        />
      </v-card-actions>
    </v-card>
  </v-container>
</template>

<script setup lang="ts">
import { Letter, LetterState } from "~/scripts/letter";
import { Word } from "~/scripts/word";
</script>
<style lang="scss" scoped>
.link {
  color: primary;

  text-decoration: underline;
}
</style>
