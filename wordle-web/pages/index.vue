<template>
  <v-app>
    <v-card
      color="secondary accent-4"
      class="mx-auto mt-12 w-75 pa-8 rounded text-center"
      elevation="12"
    >
      <v-card-title class="text-wrap" style="color: #E0E0E0;">
         Welcome to LexiQuest! Dive into a world where words wield power and magic unfolds with each guess. Prepare for a spellbinding adventure!
      </v-card-title>
      <v-card-actions class="justify-center mx-2 my-4">
        <v-btn
          color="amber darken-3"
          class="white--text"
          :to="'/game'"
          large
          depressed
          style="font-weight: bold;"
        >
          Begin LexiQuest!
        </v-btn>
      </v-card-actions>
    </v-card>
  </v-app>
</template>
