<template>
  <NuxtLayout>
    <v-app>
      <v-app-bar color="primary" :elevation="2">
        <template v-slot:prepend>
          <v-icon color="secondary"> mdi-book </v-icon>
        </template>

        <v-app-bar-title>WordleApp : {{ showHelpDialog }}</v-app-bar-title>

        <v-btn @click="router.push('/')">Home</v-btn>
        <v-btn @click="router.push('/test')">Test</v-btn>
        <v-btn icon="mdi-theme-light-dark" @click="toggleTheme" />
        <v-btn icon="mdi-help-circle" @click="showHelpDialog = true" />
      </v-app-bar>
      <v-main>
        <NuxtPage />
      </v-main>
    </v-app>
  </NuxtLayout>

  <HelpDialog v-model="showHelpDialog" />
</template>

<script setup lang="ts">
import { useTheme } from "vuetify/lib/framework.mjs";

const router = useRouter();
const theme = useTheme();
const showHelpDialog = ref(false);

function toggleTheme() {
  if (theme.global.name.value === "light") {
    theme.global.name.value = "dark";
  } else {
    theme.global.name.value = "light";
  }
}
</script>
