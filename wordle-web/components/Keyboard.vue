<template>
  <v-row
    class="justify-center"
    v-for="(keyboardRow, rowIndex) in keyboardLetterRows"
    :key="rowIndex"
    dense
  >
    <v-col
      cols="auto"
      v-for="letter in keyboardRow"
      :key="letter.char"
      :class="'ml-1 px-0'"
    >
      <LetterResult
        :letter="letter"
        :clickable="true"
        :is-keyboard="true"
        @click="handleLetterClick(letter)"
      />
    </v-col>
  </v-row>
</template>

<script setup lang="ts">
import { Game } from "~/scripts/game";
import { Letter } from "~/scripts/letter";
import { playClickSound, playEnterSound } from "~/scripts/soundUtils";

const game: Game | undefined = inject("GAME");

const keyboardLetterRows = computed(() => {
  let keyboardLetterRows: Letter[][] = [];

  const keyboardRows = [
    ["Q", "W", "E", "R", "T", "Y", "U", "I", "O", "P"],
    ["A", "S", "D", "F", "G", "H", "J", "K", "L"],
    ["ENTER", "Z", "X", "C", "V", "B", "N", "M", "👈"],
  ];

  for (let keyboardRow of keyboardRows) {
    let keyboardLetterRow: Letter[] = [];
    for (let key of keyboardRow) {
      keyboardLetterRow.push(
        game.guessedLetters.find((letter) => letter.char === key) ??
          new Letter(key)
      );
    }
    keyboardLetterRows.push(keyboardLetterRow);
  }

  return keyboardLetterRows;
});

const handleLetterClick = (letter: Letter) => {
  playClickSound();
  if (letter.char === "ENTER") {
    playEnterSound();
  }
};
</script>
