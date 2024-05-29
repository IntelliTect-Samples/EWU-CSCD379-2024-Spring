<template>
  <span v-for="(msg, i) in messageArray" :key="msg + i">
    <span v-if="isWordToTry(msg)">
        <v-btn @click="tryWord(msg)" variant="text" class="pa-1">
            {{ msg }}
        </v-btn>
        {{ " " }}
    </span>
    <span v-else>
        {{ msg + " " }}
    </span>
  </span>
</template>

<script setup lang="ts">
import { defineProps } from 'vue';
import type { Game } from '~/scripts/game';

const props = defineProps<{
  message: string;
}>();

const game: Game = inject("GAME")!;

const messageArray = props.message.split(" ");

function isWordToTry(messageFragment: string): boolean {
  const pattern = /^'\w{5}'.*$/;
  return pattern.test(messageFragment);
}

function tryWord(word: string) {
  console.log(word);
  const match = word.match(/^'(\w{5})'/);
  if (match) {
    const extractedWord = match[1];
    for (const letter of extractedWord) {
      game.addLetter(letter.toUpperCase());
    }
  }
}

</script>

