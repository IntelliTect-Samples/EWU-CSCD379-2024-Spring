<template>
  <NuxtLayout>
    <v-app>
      <v-app-bar color="primary">
        <template v-slot:prepend>
            <v-icon size="x-large">mdi-pentagram</v-icon>
        </template>
        <v-app-bar-title>Pentagram</v-app-bar-title>
        <v-btn @click="router.push('/')">Home</v-btn>
        <v-btn @click="router.push('/game')">Pentagram</v-btn>
        <v-btn icon="mdi-theme-light-dark" @click="toggleTheme" />
        <v-btn icon="mdi-help-box" @click="showHelpDialog = true" />
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
  var defaultTheme = nuxtStorage.localStorage.getData('theme');
  theme.global.name.value = defaultTheme ?? "dark";
});


function toggleTheme() {
  if (theme.global.name.value === "light") {
    theme.global.name.value = "dark"
  } else {
    theme.global.name.value = "light"
  }
}

</script>
