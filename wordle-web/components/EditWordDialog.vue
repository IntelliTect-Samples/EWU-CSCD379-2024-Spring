<template>
  <v-dialog v-model="internalModelValue" max-width="500px">
    <v-card>
      <v-card-title>
        <span>{{ isAdd ? 'Add Word' : 'Edit Word' }}</span>
        <v-spacer></v-spacer>
        <v-btn icon @click="closeDialog">
          <v-icon>mdi-close</v-icon>
        </v-btn>
      </v-card-title>

      <v-card-text>
        <v-form ref="wordForm" v-model="valid" lazy-validation>
          <v-text-field
            v-model="word.word"
            label="Word"
            :rules="wordRules"
            required
          ></v-text-field>
          <v-checkbox
            v-model="word.isCommon"
            label="Common word"
          ></v-checkbox>
        </v-form>
        <v-alert v-if="errorMessage" type="error" dismissible>{{ errorMessage }}</v-alert>
      </v-card-text>

      <v-card-actions>
        <v-spacer></v-spacer>
        <v-btn color="primary" @click="saveWord">
          {{ isAdd ? 'Add' : 'Save' }}
        </v-btn>
      </v-card-actions>
    </v-card>
  </v-dialog>
</template>

<script setup lang="ts">
import { ref, watch } from 'vue';
import Axios from 'axios';
import type { WordDto } from '~/Models/WordDto';

const props = defineProps<{
  modelValue: boolean;
  isAdd: boolean;
  word?: WordDto;
}>();

const emit = defineEmits(['update:modelValue', 'updated']);

const internalModelValue = ref(props.modelValue);
const word = ref<WordDto>(props.word ? { ...props.word } : { word: '', isCommon: false });
const valid = ref(false);
const errorMessage = ref('');

const wordRules = [
  (v: string) => !!v || 'Word is required',
];

watch(() => props.modelValue, (newVal) => {
  internalModelValue.value = newVal;
  if (!newVal) {
    word.value = props.word ? { ...props.word } : { word: '', isCommon: false };
    errorMessage.value = '';
  }
});

watch(internalModelValue, (newVal) => {
  emit('update:modelValue', newVal);
});

async function saveWord() {
  const isValid = await validateForm();
  if (!isValid) return;

  try {
    if (props.isAdd) {
      await Axios.post('/word/AddWord', word.value);
    } else {
      await Axios.put('/word/UpdateWord', word.value);
    }
    emit('update:modelValue', false);
    emit('updated');
  } catch (error) {
    errorMessage.value = (error as any).response?.data || 'An error occurred';
  }
}

async function validateForm() {
  const form = ref<any>(null);
  return form.value?.validate() ?? false;
}

function closeDialog() {
  internalModelValue.value = false;
}
</script>
