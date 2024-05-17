<template>
  <Game :option="GameOption.WordleOfTheDay" :word="word" />
</template>

<script setup lang="ts">
import { GameOption } from '~/scripts/game';
import Axios from 'axios';
const route = useRoute();
const word = ref<string>();
try {
  let query = route.query.date as string;
  let date = query.split('-');
  let month = date[1];
  let day = date[2];
  let year = date[0];
  const gameUrl = `word/wordByDate/${month}/${day}/${year}`;
  const response = await Axios.get(gameUrl);
  word.value = response.data;
  console.log('selected word: ' + response.data);
} catch (error) {
  console.error('Error fetching selected word:', error);
}
</script>
