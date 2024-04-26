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
        <v-select v-model="selectedTheme" :items="themes" />
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
const selectedTheme = ref();
const isDarkMode = ref(true);
const themes: string[] = [
  "Standard",
  "Sapphire Deep Sea Dive",
  "Emerald Isle",
  "Amethyst Twilight Mist",
  "Ruby Royale",
  "Opal Opulence",
];

watch(isDarkMode, () => {
  if (
    selectedTheme.value == "Standard" ||
    new RegExp("^light$|^dark$").test(theme.global.name.value)
  ) {
    theme.global.name.value = isDarkMode.value
      ? "dark"
      : (theme.global.name.value = "light");
  } else {
    theme.global.name.value = isDarkMode.value
      ? theme.global.name.value + "Dark"
      : theme.global.name.value.replace(/Dark$/, "");
  }
  nuxtStorage.localStorage.setData("theme", theme.global.name.value);
});

function updateTheme() {
  if (selectedTheme.value == "Standard") {
    theme.global.name.value = isDarkMode.value ? "light" : "dark";
  } else {
    theme.global.name.value = selectedTheme.value.replace(/\s/g, "");
    if (isDarkMode.value) {
      theme.global.name.value = theme.global.name.value + "Dark";
    }
  }
  nuxtStorage.localStorage.setData("theme", theme.global.name.value);
}
</script>
