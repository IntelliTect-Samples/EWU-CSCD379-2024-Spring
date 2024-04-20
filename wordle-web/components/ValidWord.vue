<template>
  <v-card>
    <v-card-title>Valid Words</v-card-title>
    <v-list>
      <v-list-item v-for="(word, i) in WordList.validateWord(props.game.guess.text)"
      :key="i"
      :value="word"
      active-color="primary"
      variant="plain"
      :title="word"
      @click=""fill>
        <v-list-item-title>{{ word }}</v-list-item-title>
      </v-list-item>
    </v-list>
  </v-card>
</template>

<script setup lang="ts">
import { WordList } from '~/scripts/wordList';
const validator = new WordList();
const props = defineProps<{
  game: {
    guess: {
      text: string;
    };
  };
}>();
</script>
