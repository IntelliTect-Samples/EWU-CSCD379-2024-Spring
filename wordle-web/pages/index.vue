<template>
  <v-app>
    <v-container
      class="full-page-gradient fill-height flex-column pa-0 ma-0 d-flex"
    >
      <v-sheet class="full-page-gradient d-flex flex-column">
        <v-card class="border-thin bg-primary pa-9 text-center">
          <v-row class="align-center justify-center mb-4">
            <v-col class="d-flex justify-center" cols="auto">
              <v-card-text class="welcome-text">Welcome to</v-card-text>
            </v-col>
            <v-img
              :src="logoPath"
              alt="Logo"
              max-width="200"
              max-height="190"
            />
          </v-row>
          <v-card-text>Today is {{ date }}</v-card-text>
          <v-card-text class="pa-6">Choose your game mode:</v-card-text>
          <v-btn
            class="glow-btn pa-2 px-5 mx-3 mb-4"
            color="white"
            to="/Wordle/Radndom"
          >
            Random Wordle
          </v-btn>
          <v-btn
            class="glow-btn pa-2 px-5 mx-3 mb-4"
            color="white"
            :to="`/Wordle/Daily?date=${date}`"
          >
            Daily Wordle
          </v-btn>
        </v-card>
      </v-sheet>
    </v-container>
  </v-app>
</template>

<script setup lang="ts">
import { useTheme } from "vuetify";
import nuxtStorage from "nuxt-storage";
import { format } from "date-fns";
import { ref, computed, onMounted } from "vue";

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
</script>
<style scoped>
@import url("https://fonts.googleapis.com/css2?family=Press+Start+2P&display=swap");

html,
body,
#app,
.v-application,
.v-application--wrap {
  height: 100%;
  margin: 0;
  font-family: "Press Start 2P", sans-serif;
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

.fill-height {
  height: 100vh;
}

.welcome-text {
  font-size: 1.6rem;
  font-family: "Press Start 2P", sans-serif;
}

.full-page-gradient {
  width: 100vw;
  height: 100vh;
  background: linear-gradient(-45deg, #ee7752, #e73c7e, #23a6d5, #23d5ab);
  background-size: 400% 400%;
  animation: gradient 15s ease infinite;
  border-radius: 0;
  display: flex;
  flex-direction: column;
  justify-content: center;
  align-items: center;
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
