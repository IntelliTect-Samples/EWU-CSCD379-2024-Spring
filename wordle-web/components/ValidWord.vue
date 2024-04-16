<template>
  <v-card>
    <v-card-title>Valid Words</v-card-title>
    <v-list>
      <v-list-item v-for="(word, i) in myWordList.validateWord()" :key="i">
        <v-list-item-title>{{ word }}</v-list-item-title>
      </v-list-item>
    </v-list>
  </v-card>
</template>

<script setup lang="ts">
import { WordList } from '~/scripts/wordList';
</script>
