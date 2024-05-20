<template>
  <v-container>
    <v-card class="text-center bg-primary pa-5" elevation="2">
      <v-card-text class="text-h3"> </v-card-text>
      <v-card-text class="d-flex justify-center">
        <v-img :src="logoPath" alt="Logo" max-width="280" max-height="190" />
      </v-card-text>
      <v-card-text class="text-h4 mb-4"> Choose your game mode: </v-card-text>
      <v-btn
        class="glow-btn pa-2 px-5 mx-3 mb-4"
        color="white"
        to="/Wordle/RandomWord"
      >
        Random Wordle
      </v-btn>
      <v-btn
        class="glow-btn pa-2 px-5 mx-3 mb-4"
        color="white"
        to="/Wordle/DailyWord"
      >
        Daily Wordle
      </v-btn>
    </v-card>
  </v-container>
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
const date = ref("");

const logoPath = computed(() => {
  const themeName = theme.global.name.value.replace("Dark", "");
  return logoPaths[themeName] || logoPaths["Standard"];
});

onMounted(() => {
  var defaultTheme = nuxtStorage.localStorage.getData("theme");
  theme.global.name.value = defaultTheme ?? "light";
  date.value = format(new Date(), "MM-dd-yyyy");
});
</script>

<style scoped>
.glow-btn {
  position: relative;
  background-color: #444; /* Dark background for contrast */
  color: white;
  border: none;
  cursor: pointer;
  box-shadow: 0 0 5px rgb(233, 238, 81);
  transition: all 0.3s ease-in-out;
}

.glow-btn:hover {
  box-shadow: 0 0 20px rgb(233, 238, 81);
}
</style>
