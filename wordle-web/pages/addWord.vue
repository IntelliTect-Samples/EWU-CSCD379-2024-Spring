<template>
  <v-dialog v-model="modelValue" max-width="500">
    <v-card color="secondary">
      <v-sheet color="primary">
        <v-card-text style="text-align: center; font-size: larger">
          <v-text-field
        v-model="newWord"
        label="Enter new word"
        variant= outlined
        dense
        class="mb-4 text-center"
        @keydown.enter="addWord">
      </v-text-field>
      <div class="text-center"></div>
        </v-card-text>
      </v-sheet>
      </v-card>
      </v-dialog>
</template>

<script setup lang="ts">
import { ref } from 'vue';

const modelValue = ref<boolean>(false);
const seeWhileTyping = ref<boolean>(false);
const password = ref<string>('');
const valid = ref<boolean>(false);
const userName = ref<string>('');
const isRegisterMode = ref<boolean>(false);
const isAuthorized = ref<boolean>(false);

function toggleMode(){
  isRegisterMode.value = !isRegisterMode.value;
}


function isMaster(){
  if(userName.value = 'admin@masterOfUniverse.com')
    {
      isAuthorized.value = true;
  } else {
    isAuthorized.value = false;
  }
}
</script>

<style>
</style>
