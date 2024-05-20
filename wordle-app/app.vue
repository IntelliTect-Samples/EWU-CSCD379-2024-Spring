<template>
  <NuxtLayout>

    <!-- Video background -->
    <video autoplay muted loop id="myVideo" style="position: absolute; right: 0; bottom: 0; min-width: 100%; min-height: 100%;">
      <source src="./public/istockphoto-532528714-640_adpp_is.mp4" type="video/mp4">
      Your browser does not support HTML5 video.
    </video>

    <v-app>
      <v-app-bar color="primary" :elevation="2">
        <v-app-bar-title @click="$router.push('/')" style="cursor: pointer">
          <v-img
            src="./public/image-Background-Removed.png"
            alt="Logo"
            max-width="180"
            max-height="95"
          ></v-img>
      </v-app-bar-title>
        
        <v-btn icon="mdi-cog" @click="showSettingsDialog = true" />
        <!-- <v-btn icon="mdi-cog" @click="toggleMenu" /> -->
        <v-btn icon="mdi-help-circle" @click="showHelpDialog = true" />
        <HelpDialog v-model="showHelpDialog" />
        <v-btn @click="toggleDrawer" icon = "mdi-menu"></v-btn>
      </v-app-bar>
      <v-navigation-drawer v-model="drawer"  location="right" disable-resize-watcher>
        <v-list>
          <v-list-item @click="router.push('/About')" class="text-center">About</v-list-item>
        </v-list>
        <v-list>
          <v-list-item @click="router.push('/Leaderboard')" class="text-center">Leaderboard</v-list-item>
        </v-list>
      </v-navigation-drawer>
      <v-main>
        <NuxtPage />
      </v-main>
    </v-app>
    
  </NuxtLayout>
  <SettingsDialog v-model="showSettingsDialog" />
</template>

<script setup lang="ts">
import { useTheme } from "vuetify";
import nuxtStorage from "nuxt-storage";

const router = useRouter();
const theme = useTheme();
const showHelpDialog = ref(false);
const showSettingsDialog = ref(false);
var drawer = ref(false);
function toggleDrawer() {
  drawer.value = !drawer.value;
}


onMounted(() => {
  var defaultTheme = nuxtStorage.localStorage.getData("theme");
  theme.global.name.value = defaultTheme ?? "dark";
});
</script>
