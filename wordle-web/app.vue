<template>
  <v-app>
    <v-app-bar color="primary" :elevation="2">
      <v-app-bar-title @click="$router.push('/')" style="cursor: pointer">
        <v-img :src="logoPath" alt="Logo" max-width="180" max-height="95" />
      </v-app-bar-title>

      <v-app-bar-nav-icon
        icon="mdi-help-circle"
        @click="$router.push('/instructions')"
      />
      <v-app-bar-nav-icon icon="mdi-cog" @click="showSettingsDialog = true" />
      <v-app-bar-nav-icon
        icon="mdi-trophy-variant"
        @click="$router.push('/leaderboard')"
      />
      <v-app-bar-nav-icon variant="text" @click="drawer = !drawer" />
    </v-app-bar>
    <v-navigation-drawer
      v-model="drawer"
      location="right"
      color="secondary"
      temporary
    >
      <v-list
        v-for="item in [
          'Wordle/Daily',
          'Wordle/Random',
          'About',
          'Leaderboard',
          'Instructions',
          'Latest Wordles',
        ]"
        :key="item"
      >
        <v-list-item
          @click="
            if (item === 'Wordle/Daily') {
              $router.push(
                '/Wordle/Daily?date=' + format(new Date(), 'MMMM dd, yyyy')
              );
            } else $router.push('/' + item.toLowerCase().replaceAll(' ', ''));
          "
        >
          <v-list-item-title> {{ item }} </v-list-item-title>
        </v-list-item>
      </v-list>
    </v-navigation-drawer>
    <v-main>
      <NuxtLayout>
        <NuxtPage />
      </NuxtLayout>
    </v-main>
    <SettingsDialogue v-model="showSettingsDialog" />
  </v-app>
</template>

<script setup lang="ts">
import { useTheme } from "vuetify";
import nuxtStorage from "nuxt-storage";
import { format } from "date-fns";

const logoPaths = {
  Standard: "/logo_Standard.svg",
  SapphireDeepSeaDive: "/logo_SapphireDeepSeaDive.svg",
  EmeraldIsle: "/logo_EmeraldIsle.svg",
  AmethystTwilightMist: "/logo_AmethystTwilightMist.svg",
  RubyRoyale: "/logo_RubyRoyale.svg",
  OpalOpulence: "/logo_OpalOpulence.svg",
};

const theme = useTheme();
const showSettingsDialog = ref(false);
const drawer = ref(false);

const logoPath = computed(() => {
  const themeName = theme.global.name.value.replace("Dark", "");
  return logoPaths[themeName] || logoPaths["Standard"];
});

watch(theme.global.name, (newVal) => {
  //watcher is just here to react to changes. logo update is handled by the computed property.
});

onMounted(() => {
  var defaultTheme = nuxtStorage.localStorage.getData("theme");
  theme.global.name.value = defaultTheme ?? "light";
});
</script>
