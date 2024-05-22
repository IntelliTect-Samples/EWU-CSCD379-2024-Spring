<template>
  <v-dialog v-model="modelValue">
    <v-card class="ma-auto pa-4" color="black" min-width="300">
      <v-sheet color="secondary">
        <v-card-title>Settings</v-card-title>
      </v-sheet>
      <v-card-text>
        <v-divider class="my-4" />
        Light/Dark Mode:
        <v-btn
          color="secondary"
          @click="toggleTheme"
          icon="mdi-theme-light-dark" />
        <v-divider class="my-4" />
      </v-card-text>

      <v-sheet class="ml-6" width="200">
        <v-form @submit.prevent>
          <v-select
            color="secondary"
            v-model="selectedTheme"
            label="Select theme"
            :items="['Regular', 'Jungle', 'Flamingo', 'Whurdle']"></v-select>
          <v-btn
            color="secondary"
            @click="changeColorScheme"
            class="mb-6"
            type="submit"
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
import { Theme } from '~/scripts/theme';

const modelValue = defineModel<boolean>({ default: false });
const theme = useTheme();
const selectedTheme = ref('Regular');

onMounted(() => {
  var defaultTheme = nuxtStorage.localStorage.getData('theme');
  theme.global.name.value = defaultTheme ?? 'regularDark';
});

function toggleTheme() {
  if (getLightDarkMode(theme.global.name.value) === 'Light') {
    theme.global.name.value =
      theme.global.name.value.substring(0, theme.global.name.value.length - 5) +
      'Dark';
  } else {
    theme.global.name.value =
      theme.global.name.value.substring(0, theme.global.name.value.length - 4) +
      'Light';
  }

  nuxtStorage.localStorage.setData('theme', theme.global.name.value);
}

function changeColorScheme() {
  theme.global.name.value =
    selectedTheme.value.toLowerCase() +
    getLightDarkMode(theme.global.name.value);
  nuxtStorage.localStorage.setData('theme', theme.global.name.value);
}

function getLightDarkMode(currentTheme: string) {
  // Themes will end in either 'Dark' or 'Light'. This check makes it easy
  // to see if the currentTheme is 'Dark' by checking the last char for a 'k' or 't'.
  let isDark = currentTheme.charAt(currentTheme.length - 1) === 'k';
  return isDark ? 'Dark' : 'Light';
}
</script>
