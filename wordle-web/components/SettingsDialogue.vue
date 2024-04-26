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
          :append-icon="isDarkMode ? 'mdi-weather-night' : 'mdi-weather-sunny'"
          inset
        />
        <v-label text="Theme" />
        <v-select
          v-model="selectedTheme"
          :items="themes"
          :item-value="
            isDarkMode ? (theme) => theme.dark : (theme) => theme.light
          "
          :item-title="(theme) => theme.name"
          placeholder="Select a theme"
        />
      </v-card-item>
      <v-divider />

      <v-card-actions>
        <v-spacer />
        <v-btn
          color="secondary"
          variant="flat"
          text="Apply"
          @click="updateTheme"
          :disabled="!selectedTheme"
        />
        <v-btn
          color="secondary"
          variant="flat"
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

const themes = [
  {
    name: "Standard",
    light: "light",
    dark: "dark",
  },
  {
    name: "Sapphire Deep Sea Dive",
    light: "SapphireDeepSeaDive",
    dark: "SapphireDeepSeaDiveDark",
  },
  {
    name: "Emerald Isle",
    light: "EmeraldIsle",
    dark: "EmeraldIsleDark",
  },
  {
    name: "Amethyst Twilight Mist",
    light: "AmethystTwilightMist",
    dark: "AmethystTwilightMistDark",
  },
  {
    name: "Ruby Royale",
    light: "RubyRoyale",
    dark: "RubyRoyaleDark",
  },
  {
    name: "Opal Opulence",
    light: "OpalOpulence",
    dark: "OpalOpulenceDark",
  },
];

const theme = useTheme();
const selectedTheme = ref();
const isDarkMode = ref();

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
      ? theme.global.name.value.includes("Dark")
        ? theme.global.name.value
        : theme.global.name.value + "Dark"
      : theme.global.name.value.replace(/Dark$/, "");
  }
  nuxtStorage.localStorage.setData("theme", theme.global.name.value);
});

function updateTheme() {
  theme.global.name.value = selectedTheme.value;
  nuxtStorage.localStorage.setData("theme", theme.global.name.value);
}
</script>
