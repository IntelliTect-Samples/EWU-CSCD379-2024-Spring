<template>
  <v-app class="full-page-gradient">
    <v-container class="ma-auto mr-auto d-flex align-center justify-center">
      <v-row>
        <v-col>
          <v-card
            class="mx-autopa-8 border-thin bg-primary pa-9 text-center align-center justify-center"
          >
            <v-row class="align-center justify-center mb-4">
              <v-col>
                <v-card-text class="welcome-text">Welcome to</v-card-text>
              </v-col>
            </v-row>
            <v-row class="align-center justify-center mb-4">
              <v-img
                class="mx-auto"
                max-width="300"
                max-height="300"
                :src="logoPath"
              />
            </v-row>
            <v-card-text class="welcome-text"
              >Today is {{ formattedDate }}</v-card-text
            >
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
        </v-col>
      </v-row>
    </v-container>
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

const formattedDate = computed(() => {
  return format(new Date(), "MMMM dd, yyyy");
});
</script>

<style scoped>
@import url("https://fonts.googleapis.com/css2?family=Press+Start+2P&display=swap");

.full-page-gradient {
  width: 100vw;
  height: 100vh;
  background: linear-gradient(-45deg, #ee7752, #e73c7e, #23a6d5, #23d5ab);
  background-size: 400% 400%;
  animation: gradient 15s ease infinite;
  display: flex;
  flex-direction: column;
  justify-content: center;
  align-items: center;
}

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
