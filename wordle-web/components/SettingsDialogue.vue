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
const themesListMaster = theme.themes.value;
const selectedTheme = ref();
const isDarkMode = ref(true);

const themes = computed(() => {
  return Object.entries(themesListMaster)
    .filter(([key, value]) => !value.dark)
    .map(([key]) => key.replace(/([A-Z])/g, " $1").trim());
});

watch(isDarkMode, () => {
  if (isDarkMode.value) {
    theme.global.name.value = theme.global.name.value + "Dark";
  } else {
    theme.global.name.value = theme.global.name.value.substring(
      0,
      theme.global.name.value.length - 4
    );
  }
});

function updateTheme() {
  if (isDarkMode.value) {
    theme.global.name.value = selectedTheme.value.replace(/\s/g, "") + "Dark";
  } else {
    theme.global.name.value = selectedTheme.value.replace(/\s/g, "");
  }
  nuxtStorage.localStorage.setData("theme", theme.global.name.value);
}
</script>
