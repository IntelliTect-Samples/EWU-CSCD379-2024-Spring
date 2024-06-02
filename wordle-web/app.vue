<template>
  <NuxtLayout>
    <v-app>
      <v-app-bar color="primary" :elevation="2">
        <template v-slot:prepend>
          <v-icon color="secondary"> mdi-book </v-icon>
        </template>

        <v-app-bar-title>WordleApp</v-app-bar-title>

        <v-btn @click="router.push('/')">Home</v-btn>
        <v-btn @click="router.push('/wordEditor')">Word Editor</v-btn>
        <v-btn icon="mdi-theme-light-dark" @click="toggleTheme" />
        <v-btn icon="mdi-help-circle" @click="showHelpDialog = true" />
        <HelpDialog v-model="showHelpDialog" />
      </v-app-bar>
      <v-main>
        <NuxtPage />
      </v-main>
    </v-app>
  </NuxtLayout>
</template>

<script setup lang="ts">
import { useTheme } from "vuetify";
import nuxtStorage from "nuxt-storage";

const router = useRouter();
const theme = useTheme();
const showHelpDialog = ref(false);

onMounted(() => {
  var defaultTheme = nuxtStorage.localStorage.getData("theme");
  theme.global.name.value = defaultTheme ?? "dark";
});

function toggleTheme() {
  if (theme.global.name.value === "light") {
    theme.global.name.value = "dark";
  } else {
    theme.global.name.value = "light";
  }

  nuxtStorage.localStorage.setData("theme", theme.global.name.value);
}
</script>
