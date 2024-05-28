<template>
  <v-card rounded class="pa-3 elevation-4" :color="color">
    <v-card-title class="font-weight-bold">Choose Your Theme!</v-card-title>
    <v-card-item>
      <v-switch
        v-model="isDarkMode"
        :label="isDarkMode ? 'Dark Mode' : 'Light Mode'"
        base-color="secondary"
        color="secondary"
        :true-icon="'mdi-weather-night'"
        :false-icon="'mdi-weather-sunny'"
        inset
        @update:model-value="toggleDarkMode()"
      />

      <v-slide-group
        show-arrows
        :mandatory="true"
        v-model="selectedTheme"
        :direction="$vuetify.display.mdAndUp ? 'horizontal' : 'vertical'"
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
            elevation="4"
            @click="toggle"
          >
            {{ theme.name }}
          </v-btn>
        </v-slide-group-item>
      </v-slide-group>
    </v-card-item>
  </v-card>
</template>

<script setup lang="ts">
import { useTheme } from "vuetify";
const theme = useTheme();
import nuxtStorage from "nuxt-storage";

defineProps({
  color: {
    type: String,
    default: "primary",
  },
});

const selectedTheme = ref(0);
const isDarkMode = ref(false);

const themes = [
  {
    name: "Standard",
    light: "light",
    dark: "dark",
  },
  {
    name: "Sapphire Sea",
    light: "SapphireDeepSeaDive",
    dark: "SapphireDeepSeaDiveDark",
  },
  {
    name: "Emerald Isle",
    light: "EmeraldIsle",
    dark: "EmeraldIsleDark",
  },
  {
    name: "Amethyst Mist",
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
  theme.global.name.value =
    theme.global.name.value.endsWith("Dark") ||
    theme.global.name.value === "dark"
      ? themes[selectedTheme.value].dark
      : themes[selectedTheme.value].light;
  nuxtStorage.localStorage.setData("theme", theme.global.name.value);
}

function toggleDarkMode() {
  if (
    selectedTheme.value == 0 ||
    new RegExp("^light$|^dark$").test(theme.global.name.value)
  ) {
    theme.global.name.value = isDarkMode.value ? "dark" : "light";
  } else {
    theme.global.name.value = isDarkMode.value
      ? theme.global.name.value + "Dark"
      : theme.global.name.value.replace("Dark", "");
  }
  nuxtStorage.localStorage.setData("theme", theme.global.name.value);
}

watch(
  () => theme.global.name.value,
  (newVal) => {
    const isDark = newVal === "dark" || newVal.endsWith("Dark");
    const themeNames = isDark
      ? themes.map((theme) => theme.dark)
      : themes.map((theme) => theme.light);
    isDarkMode.value = isDark;
    selectedTheme.value = themeNames.findIndex(
      (themeSel) => themeSel === newVal
    );
  }
);

onMounted(() => {
  var defaultTheme = nuxtStorage.localStorage.getData("theme");
  theme.global.name.value = defaultTheme ?? "light";

  const isDark =
    theme.global.name.value === "dark" ||
    theme.global.name.value.endsWith("Dark");

  const themeNames = isDark
    ? themes.map((theme) => theme.dark)
    : themes.map((theme) => theme.light);
  isDarkMode.value = isDark ? true : false;

  selectedTheme.value = themeNames.findIndex(
    (themeSel) => themeSel === theme.global.name.value
  );
});
</script>
