<template>
  <v-dialog v-model="modelValue" max-width="500">
    <v-card>
      <v-sheet color="primary">
        <v-card-title> Settings </v-card-title>
      </v-sheet>
      <v-card-item>
        <v-label>Theme</v-label>
        <v-select
          v-model="selctedTheme"
          :items="[
            'Light',
            'Dark',
            'Sapphire Deep Sea Dive',
            'Emerald Isle',
            'Amethyst Twilight Mist',
            'Ruby Royale',
            'Opal Opulence',
          ]"
        />
      </v-card-item>
      <v-divider />

      <v-card-actions>
        <v-spacer></v-spacer>
        <v-btn
          color="secondary"
          variant="tonal"
          text="Apply"
          @click="updateTheme"
        />
        <v-btn
          color="secondary"
          variant="tonal"
          text="Close"
          @click="modelValue = false"
        />
      </v-card-actions>
    </v-card>
  </v-dialog>
</template>

<script setup lang="ts">
const modelValue = defineModel<boolean>({ default: false });
import { useTheme } from "vuetify";
import nuxtStorage from "nuxt-storage";
const theme = useTheme();
const selctedTheme = ref();

function updateTheme() {
  switch (selctedTheme.value) {
    case "Light":
      theme.global.name.value = "light";
      break;
    case "Dark":
      theme.global.name.value = "dark";
      break;
    case "Sapphire Deep Sea Dive":
      theme.global.name.value = "DeepSeaDive";
      break;
    case "Emerald Isle":
      theme.global.name.value = "EmeraldIsle";
      break;
    case "Amethyst Twilight Mist":
      theme.global.name.value = "AmethystTwilightMist";
      break;
    case "Ruby Royale":
      theme.global.name.value = "RubyRoyale";
      break;
    case "Opal Opulence":
      theme.global.name.value = "OpalOpulence";
      break;
  }

  nuxtStorage.localStorage.setData("theme", theme.global.name.value);
}
</script>
