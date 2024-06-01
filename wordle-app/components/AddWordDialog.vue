<template>
  <v-dialog v-model="showModel" max-width="500px">
    <v-card>
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

const showModel = defineModel<boolean>("show");
const word = ref('');

const emits = defineEmits<{
  (e: "save", word: string): void;
}>();

function saveClicked() {

  emits("save", word.value);
  showModel.value = false;
  word.value = '';
}

function cancelClicked() {
  showModel.value = false;
  word.value = '';
}
</script>
