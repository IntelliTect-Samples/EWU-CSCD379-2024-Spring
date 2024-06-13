<template>
  <v-dialog v-model="show" max-width="500px">
    <v-card>
      <v-alert v-if="isLoaded" class="text-center" :color="fetchResult?.code === 200 ? 'success' : 'error'">
        <v-icon>mdi-alert-circle</v-icon>
        <span class="ml-2">{{ fetchResult?.message }}</span>
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
          @keydown.enter.prevent="saveClicked"
        ></v-text-field>
      </v-form>
      <v-card-actions class="mx-4 mb-3">
        <v-spacer></v-spacer>
        <v-btn color="secondary" variant="flat" @click="cancelClicked">Cancel</v-btn>
        <v-btn color="primary" variant="flat" @click="saveClicked">Save</v-btn>
      </v-card-actions>
    </v-card>
  </v-dialog>
</template>

<script setup lang="ts">
import { ref, defineEmits, defineProps, watch } from 'vue';
import Axios from "axios";
import TokenService from "~/scripts/tokenService";

// Props
const props = defineProps<{ show: boolean }>();
const show = ref(props.show);

// Watch for changes in props.show and update local show ref
watch(() => props.show, (newVal) => {
  show.value = newVal;
});

// Emit events
const emits = defineEmits<{
  (e: "cancel"): void;
  (e: "update:show", value: boolean): void;
  (e: "submit", word: { word: string; isCommon: boolean }): void;
  (e: "updated"): void;
}>();

const isLoaded = ref(false);
const fetchResult = ref<any>(null);
const tokenService = new TokenService();
const word = ref('');
const isCommon = ref(false);

// Handle save click
async function saveClicked() {
  await saveWord(word.value);
}

// Handle cancel click
function cancelClicked() {
  emits("cancel");
  emits("update:show", false);
  word.value = '';
}

// Save word function
async function saveWord(word: string) {
  try {
    const headers = tokenService.generateTokenHeader();
    const response = await Axios.post(
      `/WordEditor/AddWord?word=${word}`,
      { isCommon: isCommon.value },
      { headers }
    );

    fetchResult.value = response.data;
    isLoaded.value = true;

    emits("submit", { word, isCommon: isCommon.value });
    emits("updated");
    emits("update:show", false);
  } catch (error) {
    console.error(error);
  }
}
</script>
