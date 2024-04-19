<template>
  <NuxtLayout>
    <v-app>
      <v-app-bar color="primary" :elevation="2">
        <template v-slot:prepend>
          <v-icon color="hamburger"> mdi-hamburger</v-icon>
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
        <v-btn icon="mdi-weather-night" @click="toggleTheme"></v-btn>
        <v-btn icon="mdi-help-circle" @click="showHelpDialog = router.push('./helpDialog')"></v-btn>
        <v-btn icon="mdi-book-open-page-variant" @click="showHelpDialog = router.push('./aboutPage')"></v-btn>
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
var menuOpen= ref(false);
var settingsDialog = ref(false);

onMounted(() => {
  var defaultTheme = nuxtStorage.localStorage.getData("theme");
  theme.global.name.value = defaultTheme ?? "dark";
});

function openMenu(){
  menuOpen = true;
}

function toggleTheme() {
  if (theme.global.name.value === "light") {
    theme.global.name.value = "dark";
  } else {
    theme.global.name.value = "light";
  }

  nuxtStorage.localStorage.setData("theme", theme.global.name.value);
}
  // function toggleMenu() {
  //   menuOpen.value=! menuOpen.value;
  // }

</script>
