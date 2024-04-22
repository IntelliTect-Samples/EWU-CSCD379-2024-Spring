<template>
  <v-card v-model="modelValue">
    <v-card-title>
      Valid Words
      <v-btn @click="reload">Reload</v-btn></v-card-title
    >
    <v-infinite-scroll
      v-if="!isReloading"
      :height="300"
      :items="output"
      :onLoad="load">
      <template v-for="(item, index) in output" :key="index">
        <v-btn class="pa-2" height="50" @click="$emit('chooseWord', item)">
          {{ item }}
        </v-btn>
      </template>
    </v-infinite-scroll>
  </v-card>
</template>

<script setup lang="ts">
import { Game } from '~/scripts/game';
import { ValidWordsUtils } from '~/scripts/validWordsUtils';
const modelValue = defineModel<Game>({ required: true });
defineEmits(['chooseWord']);
const utils = new ValidWordsUtils();
const output = ref(new Array<string>());
let index = 0;
let localGuessIndex = 0;
let isReloading = ref(false);

async function api(): Promise<string[]> {
  return new Promise(resolve => {
    setTimeout(() => {
      resolve(getNextTenWords());
    }, 1000);
  });
}

async function reload() {
  isReloading.value = true;
  const res = await api();
  res.forEach(item => {
    output.value.push(item);
  });
  setTimeout(() => {
    isReloading.value = false;
  }, 750);
}

function getNextTenWords() {
  if (modelValue.value.guessIndex !== localGuessIndex) {
    console.log('THE THING WENT OFF');
    output.value = new Array<string>();
    index = 0;
    localGuessIndex = modelValue.value.guessIndex;
  }
  let array = new Array<string>();
  let validWords = ref(utils.validWords(modelValue.value));
  const maxIndex = index + 10;
  while (index < maxIndex) {
    const item = validWords.value[index];
    if (item !== undefined) {
      array.push(item);
      index++;
    } else {
      break;
    }
  }
  return array;
}
async function load({ done }: { done: any }) {
  // Perform API call
  const res = await api();
  res.forEach(item => {
    output.value.push(item);
  });

  done('ok');
}
</script>
