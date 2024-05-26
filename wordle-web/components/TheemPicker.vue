<template>
  <v-card rounded class="pa-3 elevation-4" color="primary">
    <v-card-title class="font-weight-bold">Choose Your Theme!</v-card-title>
    <v-slide-group
      show-arrows
      :mandatory="true"
      v-model="selectedTheme"
      direction="horizontal"
      @update:model-value="updateTheme()"
      :center-active="true"
      :mobile="true"
      def
    >
      <v-slide-group-item
        v-for="(theme, i) in themes"
        :key="i"
        v-slot="{ isSelected, toggle }"
      >
        <v-btn
          :color="isSelected ? 'secondary' : undefined"
          class="ma-2"
          rounded
          @click="toggle"
        >
          {{ theme.name }}
        </v-btn>
      </v-slide-group-item>
    </v-slide-group>
  </v-card>
</template>

<script setup lang="ts">
import { useTheme, useDisplay } from "vuetify";
const theme = useTheme();
const display = useDisplay();
import nuxtStorage from "nuxt-storage";

const selectedTheme = ref(0);
const isMobile = ref(false);

const themes = [
  {
    name: "Standard",
    light: "light",
    dark: "dark",
  },
  {
    name: "Sapphire Deep Sea Dive",
    light: "SapphireDeepSeaDive",
    dark: "SapphireDeepSeaDiveDark",
  },
  {
    name: "Emerald Isle",
    light: "EmeraldIsle",
    dark: "EmeraldIsleDark",
  },
  {
    name: "Amethyst Twilight Mist",
    light: "AmethystTwilightMist",
    dark: "AmethystTwilightMistDark",
  },
  {
    name: "Ruby Royale",
    light: "RubyRoyale",
    dark: "RubyRoyaleDark",
  },
  {
    name: "Opal Opulence",
    light: "OpalOpulence",
    dark: "OpalOpulenceDark",
  },
];

async function updateTheme() {
  theme.global.name.value = themes[selectedTheme.value].light;
  nuxtStorage.localStorage.setData("theme", theme.global.name.value);
}

onMounted(() => {
  var defaultTheme = nuxtStorage.localStorage.getData("theme");
  theme.global.name.value = defaultTheme ?? "light";
  selectedTheme.value = themes.findIndex(
    (themeSel) => themeSel.light === theme.global.name.value
  );
});
</script>
