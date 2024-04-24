<template>
  <v-dialog v-model="modelValue" max-width="500">
    <v-card>
      <v-sheet color="primary">
        <v-card-title> Settings </v-card-title>
      </v-sheet>
      <v-card-item>
        <v-switch
          v-model="isDarkMode"
          :label="isDarkMode ? 'Dark Mode' : 'Light Mode'"
          color="primary"
          base-color="primary"
          default-value="true"
          :append-icon="isDarkMode ? 'mdi-weather-night' : 'mdi-weather-sunny'"
          inset
        />

        <v-label>Theme</v-label>
        <v-select v-model="selctedTheme" :items="themes" />
      </v-card-item>
      <v-divider />

      <v-card-actions>
        <v-spacer></v-spacer>
        <v-btn
          color="secondary"
          variant="tonal"
          text="Apply"
          @click="updateTheme"
        />
        <v-btn
          color="secondary"
          variant="tonal"
          text="Close"
          @click="modelValue = false"
        />
      </v-card-actions>
    </v-card>
  </v-dialog>
</template>

<script setup lang="ts">
const modelValue = defineModel<boolean>({ default: false });
import { useTheme } from "vuetify";
import nuxtStorage from "nuxt-storage";
const theme = useTheme();
const themesListMaster = theme.themes.value;
const selctedTheme = ref();
const isDarkMode = ref(false);

const themes = computed(() => {
  if (isDarkMode.value) {
    return Object.entries(themesListMaster)
      .filter(([key, value]) => value.dark)
      .map(([key]) => key);
  } else {
    return Object.entries(themesListMaster)
      .filter(([key, value]) => !value.dark)
      .map(([key]) => key);
  }
});

function updateTheme() {
  switch (selctedTheme.value) {
    case "Standard":
      theme.global.name.value = "light";
      break;
    case "Sapphire Deep Sea Dive":
      theme.global.name.value = "DeepSeaDive";
      break;
    case "Emerald Isle":
      theme.global.name.value = "EmeraldIsle";
      break;
    case "Amethyst Twilight Mist":
      theme.global.name.value = "AmethystTwilightMist";
      break;
    case "Ruby Royale":
      theme.global.name.value = "RubyRoyale";
      break;
    case "Opal Opulence":
      theme.global.name.value = "OpalOpulence";
      break;
  }

  nuxtStorage.localStorage.setData("theme", theme.global.name.value);
}
</script>
