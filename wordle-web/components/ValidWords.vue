<template>
  <v-dialog v-model="show">
    <v-card>
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
const utils = new ValidWordsUtils();
// const gameGuessIndex = computed(() => {
//   return props.game.guessIndex;
// });
let validWords = new Array<string>();
watch([props.game], () => {
  output = new Array<string>();
  index = 0;
  localGuessIndex = props.game.guessIndex;
  validWords = utils.validWords(props.game);
  validWordsCount.value = validWords.length;
  console.log('ITS HAPPENING');
});
let output = new Array<string>();
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
    output.push(item);
  });
  setTimeout(() => {
    isReloading.value = false;
  }, 750);
}

function getNextTenWords() {
  if (props.game.guessIndex !== localGuessIndex) {
    output = new Array<string>();
    index = 0;
    localGuessIndex = props.game.guessIndex;
  }
  let array = new Array<string>();
  let validWords = ref(utils.validWords(props.game));
  validWordsCount.value = validWords.value.length;
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
    output.push(item);
  });

  done('ok');
}
</script>
