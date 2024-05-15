import { useDisplay } from 'vuetify/lib/framework.mjs';
<template>
  <v-container>
    <v-card
      color="secondary"
      class="mx-autopa-8 rounded text-center"
      elevation="4"
    >
      <v-img
        :src="logoPath"
        alt="Logo"
        max-width="240"
        max-height="130"
        class="mx-auto"
      ></v-img>

      <v-card-text
        :class="[
          $vuetify.display.smAndDown ? 'text-body-1' : '',
          'text-h6 text-cente ma-2',
        ]"
        >This class project is about exploring more of Vue's features and using
        Axios for routes. We added a SQL database and various controllers to the
        back end! We added a leaderboard to the game and played with animations
        and more styling. Meg is amazing and someone we look up to as women in
        CS <v-icon small class="text-red">mdi-heart</v-icon> She does a great
        job explaining things in class, and we really appreciate her immense
        knowledge!
      </v-card-text>
      <v-card-text>
        <span class="text-white text-h5 bg-primary pa-1">
          #MEGFORPRESIDENT
        </span>
      </v-card-text>
      <v-card-actions class="d-flex justify-center mb-1">
        <v-btn
          color="white"
          class="bg-primary pa-2 px-5"
          to="/"
          text="Go Home"
        />
      </v-card-actions>
    </v-card>
  </v-container>
</template>

<script setup lang="ts">
import { useTheme } from "vuetify";

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

watch(theme.global.name, (newVal) => {});
</script>
