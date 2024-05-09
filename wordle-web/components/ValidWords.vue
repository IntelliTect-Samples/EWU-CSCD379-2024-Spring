<template>
  <v-dialog v-model="show">
    <v-card class="ma-auto" min-width="300">
      <v-sheet :color="validWords.length === 0 ? 'unknown' : 'secondary'">
        <v-card-title class="text-center"
          >Valid Words
          <v-btn
            :color="validWords.length === 0 ? 'unknown' : 'secondary'"
            elevation="0"
            @click="show = !show"
            icon="mdi-close"
            class="cursor-pointer"
        /></v-card-title>
      </v-sheet>
      <v-infinite-scroll
        v-if="validWords.length !== 0"
        :height="300"
        :items="output"
        mode="manual"
        @load="load">
        <template v-for="(item, index) in output" :key="index">
          <v-btn class="pa-2" height="50" @click="$emit('chooseWord', item)">
            {{ item }}
          </v-btn>
        </template>
        <template v-slot:empty>
          <v-alert type="warning">No more words!</v-alert>
        </template>
      </v-infinite-scroll>
      <template v-if="validWords.length === 0">
        <v-alert tile color="secondary" class="text-center"
          >No matches found!</v-alert
        >
      </template>
    </v-card>
  </v-dialog>
</template>

<script setup lang="ts">
import { Game } from '~/scripts/game';
import { ValidWordsUtils } from '~/scripts/validWordsUtils';
let game: Game | undefined = inject('GAME');
if (game === null || game === undefined) {
  throw new Error('injected game is null or undefined');
}
const show = defineModel<boolean>('show', { required: true });
const validWordsCount = defineModel<number>('validWordsCount', {
  required: true,
});
defineEmits(['chooseWord']);
const utils = ref(new ValidWordsUtils(game));
let validWords = utils.value.validWords();
let index = 0;
let localGuessIndex = 0;
let output = getNextTenWords();
const isEmpty = ref(false);

watch(
  () => {
    game.guessedLetters;
  },
  () => {
    utils.value.game = game;
    validWords = utils.value.validWords();
    index = 0;
    localGuessIndex = game.guessIndex;
    validWordsCount.value = validWords.length;
    output = getNextTenWords();
  }
);

watch(
  () => {
    game.secretWord;
  },
  () => {
    utils.value = new ValidWordsUtils(game);
  }
);

async function api(): Promise<string[]> {
  return new Promise(resolve => {
    setTimeout(() => {
      resolve(getNextTenWords());
    }, 1000);
  });
}

function getNextTenWords() {
  let numberToGet = 10;
  // if (index + 10 > validWords.length) {
  //   numberToGet = validWords.length - index;
  //   console.log('ITS HAPPENING ' + numberToGet);
  // }
  let result = validWords.slice(index, index + numberToGet);
  index += numberToGet;
  return result;
}

async function load({ done }: { done: any }) {
  // Perform API call
  const res = await api();
  if (res.length === 0) {
    done('empty');
    return;
  }
  res.forEach(item => {
    output.push(item);
  });

  done('ok');
}
</script>
