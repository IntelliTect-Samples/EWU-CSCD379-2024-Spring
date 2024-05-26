<template>
  <v-app v-if="themeLoaded" class="full-page-gradient">
    <v-app-bar class="bg-primary" :elevation="2">
      <v-app-bar-title @click="$router.push('/')" style="cursor: pointer">
        <v-img :src="logoPath" alt="Logo" max-width="180" max-height="95" />
      </v-app-bar-title>

      <v-app-bar-nav-icon
        icon="mdi-help-circle"
        @click="$router.push('/Instructions')"
      />
      <v-app-bar-nav-icon icon="mdi-cog" @click="showSettingsDialog = true" />
      <v-app-bar-nav-icon
        icon="mdi-trophy-variant"
        @click="$router.push('/Leaderboard')"
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
          'Daily Wordle',
          'Random Wordle',
          'About',
          'Leaderboard',
          'Instructions',
          'Latest Wordles',
          'Word Editor',
        ]"
        :key="item"
      >
        <v-list-item
          @click="
            if (item === 'Daily Wordle') {
              $router.push(
                '/Wordle/Daily?date=' +
                  dateUtils.getFormattedDate(new Date(), 'MMMM dd, yyyy')
              );
            } else if (item === 'Random Wordle') {
              $router.push('/Wordle/Random');
            } else $router.push('/' + item.replaceAll(' ', ''));
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
import dateUtils from "./scripts/dateUtils";

useHead({
  title: "Aesthetic Wordle",
  meta: [{ name: "description", content: "Cool site!" }],
});

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
  const logoPaths: { [key: string]: string } = {
    Standard: "/logo_Standard.svg",
    SapphireDeepSeaDive: "/logo_SapphireDeepSeaDive.svg",
    EmeraldIsle: "/logo_EmeraldIsle.svg",
    AmethystTwilightMist: "/logo_AmethystTwilightMist.svg",
    RubyRoyale: "/logo_RubyRoyale.svg",
    OpalOpulence: "/logo_OpalOpulence.svg",
  };

  return logoPaths[themeName] || logoPaths["Standard"];
});
const themeLoaded = ref(false);

onMounted(async () => {
  var defaultTheme =
    (await nuxtStorage.localStorage.getData("theme")) ?? "light";
  theme.global.name.value = defaultTheme;
  themeLoaded.value = true;
});
</script>

<style scoped>
@import url("https://fonts.googleapis.com/css2?family=Press+Start+2P&display=swap");

.font-text {
  font-size: 1.2;
  font-family: "Press Start 2P", sans-serif;
}
.full-page-gradient {
  width: 100%;
  height: 100%;
  background: linear-gradient(-45deg, #ee7752, #e73c7e, #23a6d5, #23d5ab);
  background-size: 400% 400%;
  animation: gradient 15s ease infinite;
}

@keyframes gradient {
  0% {
    background-position: 0% 50%;
  }
  50% {
    background-position: 100% 50%;
  }
  100% {
    background-position: 0% 50%;
  }
}
</style>
