<template>
  <v-app>
    <v-app-bar color="pink-lighten-5">
      <v-app-bar-title>Wordle</v-app-bar-title>
      <v-btn to="/">Home</v-btn>
      <v-btn to="/game">Game</v-btn>
    </v-app-bar>

    <v-main>
      <slot />
    </v-main>
  </v-app>
</template>
