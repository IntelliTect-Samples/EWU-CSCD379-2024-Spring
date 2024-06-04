<template>
  <v-dialog v-model="modelValue" max-width="500" persistent>
    <v-card>
      <v-sheet color="primary">
        <v-card-text> Confirm Delete Word </v-card-text>
      </v-sheet>
      <v-card-text>
        Are you sure you want to delete the word "{{ wordToDelete }}"?
      </v-card-text>
      <v-divider />
      <v-card-actions>
        <v-spacer></v-spacer>
        <v-btn
          color="primary"
          variant="flat"
          text="Cancel"
          @click="cancel()"
        />
        <v-btn
          color="primary"
          variant="flat"
          text="Delete"
          @click="close()"
        />
      </v-card-actions>
    </v-card>
  </v-dialog>
</template>
<script setup lang="ts">
const wordToDelete: Ref<string> = inject("wordToDelete")! as Ref<string>;
const modelValue = defineModel<boolean>({ default: false });

const emits = defineEmits(["updated", "cancel"]);

function close() {
    emits("updated");
    modelValue.value = false;
}

function cancel() {
    emits("cancel");
    modelValue.value = false;
}
</script>
