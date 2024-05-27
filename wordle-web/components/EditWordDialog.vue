<template>
  <v-dialog v-model="modelValue" max-width="500">
    <v-card>
      <v-sheet color="primary">
        <v-card-title v-if="!isAdd" class="text-wrap">Edit Word</v-card-title>
        <v-card-title v-else class="text-wrap">Add Word</v-card-title>
      </v-sheet>
      <v-card-item>
        <v-text-field
          label="Word"
          v-model="wordModel"
          :rules="[validLengthWod]"
          :disabled="!isAdd"
        >
        </v-text-field>
        <v-label>Word Type</v-label>
        <v-radio-group v-model="isCommon">
          <v-radio
            v-for="item in items"
            :key="item.value"
            :label="item.label"
            :value="item.value"
          />
        </v-radio-group>
      </v-card-item>
      <v-card-actions>
        <v-spacer />
        <v-btn
          color="primary"
          variant="tonal"
          @click="modelValue = false"
          text="Cancel"
        />
        <v-btn color="primary" variant="elevated" text="Delete" />
      </v-card-actions>
    </v-card>
  </v-dialog>
</template>

<script setup lang="ts">
import type { WordDto } from "~/Models/WordDto";

const modelValue = defineModel<boolean>({ default: false });

const props = withDefaults(
  defineProps<{ isAdd: boolean; word?: WordDto | undefined }>(),
  {
    isAdd: false,
  }
);

watch(
  () => props.word,
  () => {
    wordModel.value = props.isAdd === true ? "" : props.word?.word!;
    isCommon.value = props.word?.isCommon ? "common" : "uncommon";
  }
);

const wordModel = ref("");

wordModel.value = props.word?.word ?? "";

const validLengthWod = (value: string) => {
  if (value.length === 5) {
    return true;
  }
  return "Word must be 5 characters long";
};
const items = [
  { label: "Common", value: "common" },
  { label: "Uncommon", value: "uncommon" },
];

const isCommon = ref("common");
</script>
