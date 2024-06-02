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
        <v-btn
          color="primary"
          variant="elevated"
          :text="isAdd ? 'Add Word' : 'Edit Word'"
          @click="updateWord"
        />
      </v-card-actions>
    </v-card>
  </v-dialog>
</template>

<script setup lang="ts">
import type { WordDto } from "~/Models/WordDto";
import Axios from "axios";
import TokenService from "~/scripts/tokenService";

const props = withDefaults(
  defineProps<{ isAdd: boolean; word?: WordDto | undefined }>(),
  {
    isAdd: false,
  }
);

const emits = defineEmits(["updated"]);
const tokenService = new TokenService();
const modelValue = defineModel<boolean>({ default: false });
const wordModel = ref("");
const isCommon = ref("common");

watch(
  () => props.word,
  () => {
    wordModel.value = props.isAdd ? "" : props.word?.word!;
    isCommon.value = props.word?.isCommon ? "common" : "uncommon";
  }
);

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

function updateWord() {
  if (props.isAdd) {
    addWord();
    console.log("addWord");
  } else {
    editWord();
  }
}

function addWord() {
  const config = {
    headers: { Authorization: `Bearer ${tokenService.getToken()}` },
  };

  const bodyParameters = {
    word: wordModel.value,
    isCommonWord: isCommon.value === "common" ? true : false,
  };

  Axios.post("word/AddWord", bodyParameters, config)
    .then((response) => {
      if (response.status === 200) {
        modelValue.value = false;
        emits("updated");
      }
    })
    .catch((error) => {
      console.log(error);
    });
}

function editWord() {
  const config = {
    headers: { Authorization: `Bearer ${tokenService.getToken()}` },
  };

  const bodyParameters = {
    word: wordModel.value,
    isCommonWord: isCommon.value === "common" ? true : false,
  };

  Axios.post("word/EditWord", bodyParameters, config)
    .then((response) => {
      if (response.status === 200) {
        modelValue.value = false;
        emits("updated");
      }
    })
    .catch((error) => {
      console.log(error);
    });
}
</script>
