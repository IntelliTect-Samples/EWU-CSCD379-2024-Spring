<template>
  <v-app>
    <v-app-bar color="tertiary text-primary">
      <v-app-bar-title class="font-weight-bold">Pink Wordle</v-app-bar-title>
      <v-btn to="/">Home</v-btn>
      <v-btn to="/game">Game</v-btn>
    </v-app-bar>

    <v-main>
      <slot />
    </v-main>
  </v-app>
</template>
