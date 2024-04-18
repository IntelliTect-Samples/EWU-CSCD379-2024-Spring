<template>
  <NuxtLayout>
    <v-app>
      <v-app-bar color="primary" :elevation="2">
        <template v-slot:prepend>
          <v-icon color="secondary"> mdi-book </v-icon>
        </template>
        <v-app-bar-title @click="router.push('/')">
          Wordle Web
          <v-icon @click="router.push('/')">
            mdi-lightbulb-on-outline
          </v-icon>
        </v-app-bar-title>

        <v-btn @click="router.push('/')">Home</v-btn>
        <v-btn @click="router.push('/test')">Test</v-btn>
        <v-btn icon="mdi-cog-outline" @click="router.push('/openSettings')"></v-btn>
        <v-btn icon="mdi-weather-night" @click="toggleTheme" />
        <v-btn icon="mdi-help-circle" @click="showHelpDialog = router.push('/aboutPage')" />
      </v-app-bar>
      <v-main>
        <NuxtPage />
      </v-main>
    </v-app>
  </NuxtLayout>
</template>


<script setup lang="ts">
import { useTheme } from "vuetify";

const router = useRouter();
const theme = useTheme();
const showHelpDialog = ref(false);
var menuOpen= ref(false);
var settingsDialog = ref(false);

function openSettingsDialog(){
  settingsDialog = true;
}

function openMenu(){
  menuOpen = true;
}

function toggleTheme() {
  if (theme.global.name.value === "light") {
    theme.global.name.value = "dark";
  } else {
    theme.global.name.value = "light";
  }

  nuxtStorage.localStorage.setData('theme', theme.global.name.value);
}
  // function toggleMenu() {
  //   menuOpen.value=! menuOpen.value;
  // }

</script>
