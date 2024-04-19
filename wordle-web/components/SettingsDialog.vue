<template>
  <v-dialog v-model="modelValue">
    <v-card>
      <v-sheet color="secondary">
        <v-card-title>Settings</v-card-title>
      </v-sheet>
      <v-card-text>
        Welcome to settings! Let me know if you wanna set some stuff.
      </v-card-text>
      <v-btn @click="toggleTheme" icon="mdi-theme-light-dark" />
      <v-sheet class="mx-auto" width="300">
        <v-form @submit.prevent>
          <v-select
            v-model="selectedTheme"
            label="Select theme"
            :items="['Regular', 'Jungle', 'Flamingo']"></v-select>
          <v-btn @click="changeColorScheme" class="mt-2" type="submit" block
            >Submit</v-btn
          >
        </v-form>
      </v-sheet>
    </v-card>
  </v-dialog>
</template>

<script setup lang="ts">
import { useTheme } from 'vuetify';
import nuxtStorage from 'nuxt-storage';

const modelValue = defineModel<boolean>({ default: false });
const theme = useTheme();
const selectedTheme = ref('Regular');

onMounted(() => {
  var defaultTheme = nuxtStorage.localStorage.getData('theme');
  theme.global.name.value = defaultTheme ?? 'regularDark';
});

function toggleTheme() {
  if (getDarkLightMode(theme.global.name.value) === 'Light') {
    theme.global.name.value = 'Dark';
  } else {
    theme.global.name.value = 'Light';
  }

  nuxtStorage.localStorage.setData('theme', theme.global.name.value);
}

function changeColorScheme() {
  theme.global.name.value =
    selectedTheme.value.toLowerCase() +
    getDarkLightMode(theme.global.name.value);
  nuxtStorage.localStorage.setData('theme', theme.global.name.value);
}

function getDarkLightMode(currentTheme: string) {
  return currentTheme.substring(currentTheme.length - 4);
}

enum Theme {
  regularLight,
  regularDark,
  jungleLight,
  jungleDark,
  flamingoLight,
  flamingoDark,
}
</script>
