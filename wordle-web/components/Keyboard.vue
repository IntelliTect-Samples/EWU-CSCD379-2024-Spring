<template>
  <v-row
    class="justify-center"
    v-for="(keyboardLetterRow, rowIndex) in keyboardLetterRows"
    :key="rowIndex"
    dense
  >
    <v-col
      cols="auto"
      v-for="key in keyboardLetterRow"
      :key="key.char"
      :class="'ml-1 px-0'"
    >
     <LetterResult :letter="key" :clickable="true" />
    </v-col>
  </v-row>
</template>

<script setup lang="ts">
import { useDisplay } from "vuetify";
import { Letter } from "~/scripts/letter";
import { Game } from "../scripts/game";

const display = useDisplay();
const game: Game = inject("GAME")!;

const keyboardLetterRows = computed(() => {
  const keyboardLetterRows: Letter[][] = []

  const keyboardRows = [
    ["Q", "W", "E", "R", "T", "Y", "U", "I", "O", "P"],
    ["A", "S", "D", "F", "G", "H", "J", "K", "L"],
    ["Z", "X", "C", "V", "B", "N", "M", "👈"],
  ];

  // Loop through all 3 keyboard rows
  for (let keyboardRow of keyboardRows) {
    let keyboardLetterRow: Letter[] = [];
    // For each key in each row, convert to a letter object
    for (let key of keyboardRow) {
      keyboardLetterRow.push(
        game.guessedLetters.find((letter) => letter.char === key) ??
          new Letter(key)
      );
    }
    keyboardLetterRows.push(keyboardLetterRow);
  }

  return keyboardLetterRows
});
</script>
