<template>
  <v-dialog v-model="show">
    <v-card class="ma-auto" min-width="500">
      <v-sheet :color="validWords.length === 0 ? 'unknown' : 'secondary'">
        <v-card-title class="text-center"
          >Valid Words
          <v-btn
            v-slot:append
            color="secondary"
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
        :onLoad="load">
        <template v-for="(item, index) in output" :key="item">
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
const props = defineProps<{
  game: Game;
}>();
const show = defineModel<boolean>('show', { required: true });
const validWordsCount = defineModel<number>('validWordsCount', {
  required: true,
});
defineEmits(['chooseWord']);
const utils = new ValidWordsUtils(props.game);
let validWords = utils.validWords();
watch([props.game], () => {
  output = new Array<string>();
  index = 0;
  localGuessIndex = props.game.guessIndex;
  validWords = utils.validWords();
  validWordsCount.value = validWords.length;
});
let index = 0;
let localGuessIndex = 0;
let output = getNextTenWords();

async function api(): Promise<string[]> {
  return new Promise(resolve => {
    setTimeout(() => {
      resolve(getNextTenWords());
    }, 1000);
  });
}

function getNextTenWords() {
  let result = validWords.slice(index, index + 10);
  index += 10;
  return result;
}
async function load({ done }: { done: any }) {
  // Perform API call
  const res = await api();
  res.forEach(item => {
    output.push(item);
  });

  done('ok');
}
</script>
