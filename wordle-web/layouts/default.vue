<template>
  <v-app>
    <v-app-bar color="primary" :elevation="2">
      <v-app-bar-title @click="$router.push('/')" style="cursor: pointer">
        <v-icon color="secondary"> mdi-heart </v-icon>
        Pink Wordle</v-app-bar-title
      >

      <v-btn to="/about">About</v-btn>
      <v-btn icon="mdi-theme-light-dark" @click="toggleTheme" />
      <v-btn icon="mdi-help-circle" @click="showHelpDialog = true" />
      <HelpDialog v-model="showHelpDialog" />
    </v-app-bar>
    <v-main>
      <slot />
    </v-main>
  </v-app>
</template>

<script setup lang="ts">
import { useTheme } from "vuetify";
import nuxtStorage from "nuxt-storage";

const router = useRouter();
const theme = useTheme();
const showHelpDialog = ref(false);

function toggleTheme() {
  if (theme.global.name.value === "light") {
    theme.global.name.value = "dark";
  } else {
    theme.global.name.value = "light";
  }

  nuxtStorage.localStorage.setData("theme", theme.global.name.value);
}

onMounted(() => {
  var defaultTheme = nuxtStorage.localStorage.getData("theme");
  theme.global.name.value = defaultTheme ?? "dark";
});
</script>
