<template>
  <v-container>
    <v-card
      max-width="750px"
      man-height="500px"
      class="border-thin bg-primary pa-3 text-center mx-auto my-auto"
    >
      <v-row class="align-center justify-center">
        <v-card-text class="welcome-text">Welcome to</v-card-text>
      </v-row>
      <v-row class="align-center justify-center mb-4">
        <v-img
          class="mx-auto"
          max-width="300"
          max-height="300"
          :src="logoPath"
        />
      </v-row>
      <v-card-text class="welcome-text">Today is {{ specialDate }}</v-card-text>
      <v-card-text class="welcome-text pa-6"
        >Choose your game mode:</v-card-text
      >
      <v-btn
        class="button-text glow-btn pa-2 mx-3 mb-4"
        color="white"
        to="/Wordle/Random"
      >
        Random Wordle
      </v-btn>
      <v-btn
        class="button-text glow-btn pa-2 mx-3 mb-4"
        color="white"
        :to="`/Wordle/Daily?date=${formattedDate}`"
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
import dateUtils from "../scripts/dateUtils";

const logoPaths = {
  Standard: "/logo_Standard.svg",
  SapphireDeepSeaDive: "/logo_SapphireDeepSeaDive.svg",
  EmeraldIsle: "/logo_EmeraldIsle.svg",
  AmethystTwilightMist: "/logo_AmethystTwilightMist.svg",
  RubyRoyale: "/logo_RubyRoyale.svg",
  OpalOpulence: "/logo_OpalOpulence.svg",
};

const theme = useTheme();

const logoPath = computed(() => {
  const themeName = theme.global.name.value.replace("Dark", "");
  return logoPaths[themeName] || logoPaths["Standard"];
});

onMounted(() => {
  var defaultTheme = nuxtStorage.localStorage.getData("theme");
  theme.global.name.value = defaultTheme ?? "light";
});

const formattedDate = computed(() => {
  return dateUtils.getFormattedDate(new Date());
});

const specialDate = computed(() => {
  return dateUtils.getFormattedDateWithOrdianl(new Date());
});
</script>

<style scoped>
@import url("https://fonts.googleapis.com/css2?family=Press+Start+2P&display=swap");

.glow-btn {
  position: relative;
  background-color: #444;
  color: white;
  border: none;
  cursor: pointer;
  box-shadow: 0 0 5px rgb(233, 238, 81);
  transition: all 0.3s ease-in-out;
}

.glow-btn:hover {
  box-shadow: 0 0 20px rgb(233, 238, 81);
}

.welcome-text {
  font-size: 1.4rem;
  font-family: "Press Start 2P", sans-serif;
}
.button-text {
  font-size: 0.9rem; /* Smaller font size for buttons */
  font-family: "Press Start 2P", sans-serif;
}
</style>
