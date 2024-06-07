<template>
  <v-dialog v-model="showModel" max-width="500px">
    <v-card>
      <v-alert v-if="isLoaded" class="text-center" :color="fetchResult?.code == 200 ? 'success' : 'error'">
        <v-icon>mdi-alert-circle</v-icon>
        <span class="ml-2"> {{ fetchResult?.message }}</span>
      </v-alert>
      <v-sheet color="primary">
        <v-card-text>Enter a word you want to add</v-card-text>
      </v-sheet>
      <v-form class="mx-3 mt-5">
        <v-text-field
          v-model="word"
          label="Word"
          variant="outlined"
          clearable
          @keydown.enter
          @keydown.enter.prevent="saveClicked()"
        ></v-text-field>
      </v-form>
      <v-card-actions class="mx-4 mb-3">
        <v-spacer></v-spacer>
        <v-btn
          color="secondary"
          variant="flat"
          text="Cancel"
          @click="cancelClicked()"
        />
        <v-btn
          color="primary"
          variant="flat"
          text="Save"
          @click="saveClicked()"
        />
      </v-card-actions>
    </v-card>
  </v-dialog>
</template>

<script lang="ts" setup>
import type { fetchResult } from '~/scripts/fetchResult';
import Axios from "axios";

import TokenService from "~/scripts/tokenService";

// Log in stuff here
const isLoaded = ref(false);
const fetchResult = ref<fetchResult>();

const tokenService = inject("TOKEN_SERVICE") as TokenService;
const isLogged = ref(tokenService.isLoggedInValue);

const showModel = defineModel<boolean>("show");
const word = ref('');

const emits = defineEmits<{
  (e: "cancel"): void;
}>();

async function saveClicked() {
  await saveWord(word.value);
}

function cancelClicked() {
  emits("cancel");
  showModel.value = false;
  word.value = '';
}

async function saveWord(word: string) {
  try {
    const headers = tokenService.generateTokenHeader();

    await Axios.post(
      "/WordEditor/AddWord?word=" + word,
      {},
      { headers }
    )
    .then((response) => {
      fetchResult.value = response.data;
    });

    isLoaded.value = true;
    

    
  } catch (error) {
    console.error(error);
  }
}
</script>
