<template>

  <v-row
    rows="auto"
    class="justify-center"
    v-for="(keyboardRow, rowIndex) in keyboardLetterRows"
    :key="rowIndex"
    dense
  >
    <v-col
      cols="auto"
      class="rounded-sm"
      v-for="letter in keyboardRow"
      :key="letter.char"
      :class="[`ml-1`, `px-0`]"
    >
      <LetterResult :letter="letter" :clickable="true" />
    </v-col>
  </v-row>
</template>

<script setup lang="ts">
import { Game } from "~/scripts/game";
import { Letter } from "~/scripts/letter";

const game: Game = inject("GAME")!;

const keyboardLetterRows = computed(() => {
  let keyboardLetterRows: Letter[][] = [];

  const keyboardRows = [
    ["Q", "W", "E", "R", "T", "Y", "U", "I", "O", "P"],
    ["A", "S", "D", "F", "G", "H", "J", "K", "L"],
    ["Z", "X", "C", "V", "B", "N", "M", "👈"],
  ];

  // Loop through all 3 keyboard rows
  for(let keyboardRow of keyboardRows){
    let keyboardLetterRow: Letter[] = []
    // For each key in each row, convert to a letter object
    for(let key of keyboardRow){
      keyboardLetterRow.push(game.guessedLetters.find((letter) => letter.char === key) ?? new Letter(key));
    }
    keyboardLetterRows.push(keyboardLetterRow);
  }

  return keyboardLetterRows;
});
</script>
