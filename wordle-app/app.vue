<template>
  <NuxtLayout>
    <v-app :style="gradientBaseStyle" class="full-page">
      <v-app-bar color="primary" :elevation="2">
        <v-app-bar-title @click="$router.push('/')" style="cursor: pointer">
          <v-img src="./public/image-Background-Removed.png" alt="Logo" max-width="180" max-height="95"></v-img>
        </v-app-bar-title>

        <v-btn icon="mdi-cog" @click="showSettingsDialog = true" />
        <v-btn icon="mdi-help-circle" @click="showHelpDialog = true" />
        <HelpDialog v-model="showHelpDialog" />
        <v-btn @click="toggleDrawer" icon="mdi-menu"></v-btn>
      </v-app-bar>
      <v-navigation-drawer v-model="drawer" location="right" disable-resize-watcher>
        <v-list>
          <v-list-item @click="router.push('/About')" class="text-center">
            <v-icon class="mr-2">mdi-information</v-icon>
            About
          </v-list-item>
        </v-list>
        <v-list>
          <v-list-item @click="router.push('/Leaderboard')" class="text-center">
            <v-icon class="mr-2">mdi-trophy</v-icon>
            Leaderboard
          </v-list-item>
        </v-list>
        <v-list>
          <v-list-item @click="router.push('/Instructions')" class="text-center">
            <v-icon class="mr-2">mdi-book-open</v-icon>
            Instructions
          </v-list-item>
        </v-list>
        <v-list>
          <v-list-item @click="router.push('/Wordhistory')" class="text-center">
            <v-icon class="mr-2">mdi-history</v-icon>
            Word History
          </v-list-item>
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

import { computed, watchEffect } from "vue";

const gradientBaseStyle = computed(() => {
  const colors = theme.current.value.colors;
  return {
    backgroundImage: `linear-gradient(45deg, ${colors.primary}, ${colors.secondary})`,
  };
});

watchEffect(() => {
  nuxtStorage.localStorage.setData("theme", theme.global.name.value);
});



</script>

<style scoped>
.full-page
{
  height: 100%;
  width: 100%;
  background-size: 200% 200%;
  animation: gradientShift 15s ease infinite;
}

@keyframes gradientShift
{

  0%,
  100%
  {
    background-position: 0% 50%;
  }

  50%
  {
    background-position: 100% 50%;
  }
}
</style>
