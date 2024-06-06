<template>
  <v-dialog v-model="dialogBox" max-width="500" persistent>
    <v-card>
      <v-sheet color="primary">
        <v-card-text>Enter your UserName: </v-card-text>
      </v-sheet>
      <v-form class="mx-3 mt-5">
        <v-text-field
          v-model="usersNameInput"
          label="user"
          variant="outlined"
          clearable
          required
		  @keydown.enter
		  @keydown.enter.prevent>
        >
        </v-text-field>
      </v-form>
      <v-card-actions class="mx-4 mb-3">
        <v-spacer></v-spacer>
        <v-btn color="success" @click="userSaving">SAVE</v-btn>
      </v-card-actions>
    </v-card>
  </v-dialog>
</template>

<script setup lang="ts">
import { ref } from "vue";
import nuxtStorage from "nuxt-storage";
const dialogBox = ref<boolean>(true);
const usersNameInput = ref<string>("");
const userSaving = () => {
  const userName = usersNameInput.value.trim();
  if (userName !== "") {
    nuxtStorage.localStorage.setData("userName", userName);
    dialogBox.value = false;
  } else {
    console.error("Cannot be empty");
  }
};
</script>
