<template>
  <!-- <v-app>
    <v-btn to="/">Home</v-btn>
    <v-btn to="/test">Test</v-btn>
    <div>
      <slot />
    </div>
  </v-app> -->
  <v-app>
    <v-app-bar>
      <v-app-bar-title>Wordle Hurdle</v-app-bar-title>
      <v-btn to="/">Home</v-btn>
      <v-btn to="/test">Test</v-btn>
    </v-app-bar>
    <v-main>
      <slot />
    </v-main>
  </v-app>
</template>
