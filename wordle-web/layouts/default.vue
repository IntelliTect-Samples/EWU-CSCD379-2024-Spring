<template>
  <v-app>
    <v-app-bar color="primary" :elevation="2">
      <v-app-bar-title @click="$router.push('/')" style="cursor: pointer">
        <v-icon> mdi-flower-poppy </v-icon>
        Pink Wordle</v-app-bar-title
      >

      <v-btn to="/about">About</v-btn>
      <v-btn icon="mdi-help-circle" @click="showHelpDialog = true" />
      <v-btn icon="mdi-cog" @click="showSettingsDialog = true" />
      <HelpDialog v-model="showHelpDialog" />
      <SettingsDialogue v-model="showSettingsDialog" />
    </v-app-bar>
    <v-main>
      <slot />
    </v-main>
  </v-app>
</template>

<script setup lang="ts">
import { useTheme } from "vuetify";
import nuxtStorage from "nuxt-storage";

const theme = useTheme();
const showHelpDialog = ref(false);
const showSettingsDialog = ref(false);

onMounted(() => {
  var defaultTheme = nuxtStorage.localStorage.getData("theme");
  theme.global.name.value = defaultTheme ?? "dark";
});
</script>
