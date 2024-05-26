<template>
  <v-container>
    <v-row cols="12">
      <v-col lg="6" md="12">
        <v-col>
          <v-card class="border-thin bg-primary pa-3 text-center h-100">
            <v-img
              class="mx-auto"
              min-width="200"
              min-height="200"
              max-width="300"
              max-height="300"
              :src="logoPath"
            />

            <v-card-text class="welcome-text">Today is</v-card-text>
            <v-card-text class="welcome-text"> {{ specialDate }}</v-card-text>
            <div class="ma-3">
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
            </div>
          </v-card>
        </v-col>
        <v-col>
          <TheemPicker />
        </v-col>
      </v-col>
      <v-col lg="6" md="12">
        <v-col>
          <NavCard title="Word Editor" icon="mdi-pencil" color="primary" />
        </v-col>
        <v-col>
          <NavCard title="Leaderboard" icon="mdi-trophy" color="secondary" />
        </v-col>
        <v-col>
          <NavCard
            title="Instructions"
            icon="mdi-help-circle"
            color="primary"
          />
        </v-col>
        <v-col>
          <NavCard
            title="Latest Wordles"
            icon="mdi-newspaper"
            color="secondary"
          />
        </v-col>
        <v-col>
          <NavCard title="About" icon="mdi-information" color="primary" />
        </v-col>
      </v-col>
    </v-row>
  </v-container>
</template>

<script setup lang="ts">
import { useTheme } from "vuetify";
import nuxtStorage from "nuxt-storage";
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

onMounted(async () => {
  var defaultTheme = await nuxtStorage.localStorage.getData("theme");
  theme.global.name.value = defaultTheme ?? "light";
  console.log(theme.global.name.value);
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
