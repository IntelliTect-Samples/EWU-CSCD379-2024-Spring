<template>
  <v-dialog v-model="modelValue" max-width="500">
    <v-card>
      <v-sheet color="primary">
        <v-card-title> Settings </v-card-title>
      </v-sheet>
      <v-container class="pa-5">
        <v-row>
          <v-col cols="4" class="text-h6"> Toggle Theme </v-col>
          <v-col>
            <v-select
              v-model="theme.global.name.value"
              :items="['light', 'dark']"
              @change="toggleTheme"
            />
          </v-col>
        </v-row>
      </v-container>
      <v-card-actions>
        <v-spacer></v-spacer>

        <v-btn text="Exit Settings" @click="modelValue = false"></v-btn>
      </v-card-actions>
    </v-card>
  </v-dialog>
</template>

<script setup lang="ts">
const modelValue = defineModel<boolean>({ default: false });
import { useTheme } from "vuetify";
import nuxtStorage from "nuxt-storage";
const theme = useTheme();

function toggleTheme() {
  if (theme.global.name.value === "light") {
    theme.global.name.value = "light";
  } else {
    theme.global.name.value = "dark";
  }

  nuxtStorage.localStorage.setData("theme", theme.global.name.value);
}
</script>
