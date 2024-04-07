<template>
    <v-toolbar color="pink-lighten-5">
      <v-toolbar-title class="bold">Wordle</v-toolbar-title>
      <v-btn to="/">Home</v-btn>
      <v-btn to="/game">Game</v-btn>
      <v-btn to="/test">Test</v-btn>
    </v-toolbar>
    <slot />
</template>