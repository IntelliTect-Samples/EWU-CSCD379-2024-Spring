<template>
  <v-card>
    <v-card-title> Valid Words </v-card-title>
    <v-infinite-scroll :height="300" :items="output" :onLoad="load">
      <template v-for="(item, index) in output" :key="index">
        <div class="pa-2" @click="$emit('chooseWord', item)">
          {{ item }}
        </div>
      </template>
    </v-infinite-scroll>
  </v-card>
</template>

<script setup lang="ts">
import { Game } from '~/scripts/game';
import { ValidWordsUtils } from '~/scripts/validWordsUtils';
const props = defineProps<{
  game: Game;
}>();
const utils = ref(new ValidWordsUtils(props.game));
const validWords = computed<Array<string>>(() => {
  return utils.value.validWords();
});
const output = ref(new Array<string>());
let index = 0;

async function api(): Promise<string[]> {
  return new Promise(resolve => {
    setTimeout(() => {
      resolve(getNextTenWords());
    }, 1000);
  });
}

function getNextTenWords() {
  let array = new Array<string>();
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
