<template>
  <v-app class="background">
    <v-container fluid class="d-flex justify-center align-center fill-height">
      <v-card
        class="mx-auto pa-8 rounded text-center card-content"
        elevation="12"
      >
        <v-card-title class="text-wrap" style="color: #E0E0E0;">
          Welcome to LexiQuest! Dive into a world where words wield power and magic unfolds with each guess. Prepare for a spellbinding adventure!
        </v-card-title>
        <v-card-actions class="justify-center mx-2 my-4">
          <v-btn
            color="amber darken-3"
            class="white--text"
            :to="'/dailyQuest'"
            large
            depressed
            style="font-weight: bold;"
          >
            Daily Quest
          </v-btn>
          <v-btn
            color="amber darken-3"
            class="white--text mx-2"
            :to="'/game'"
            large
            depressed
            style="font-weight: bold;"
          >
            Random Adventure
          </v-btn>
        </v-card-actions>
      </v-card>
    </v-container>
  </v-app>
</template>

<script setup lang="ts">
import { useRouter } from 'vue-router';
</script>

<style scoped>
html, body, #app {
  margin: 0;
  padding: 0;
  height: 100%;
  width: 100%;
}

.background {
  background-image: url('/images/title.jpg'); /* Adjust path as necessary */
  background-size: cover; /* Ensure the image covers the entire area */
  background-position: center;
  background-repeat: no-repeat;
  min-height: 100vh;
  width: 100%;
  height: 100%;
  display: flex;
  justify-content: center;
  align-items: center;
}

.v-container {
  height: 100%;
}

.card-content {
  background: rgba(0, 0, 0, 0.8); /* Adjusted opacity for more opaqueness */
  max-width: 800px; /* Set a maximum width for the card */
  width: 100%; /* Ensure the card takes full width up to max-width */
  box-sizing: border-box; /* Include padding and border in the element's total width and height */
}

/* Media queries for responsiveness */
@media (max-width: 1200px) {
  .v-card {
    padding: 10px;
  }
}

@media (max-width: 768px) {
  .v-card {
    padding: 5px;
  }

  .v-card-title {
    font-size: 1.2em;
  }

  .v-btn {
    margin: 5px 0;
  }
}

@media (max-width: 425px) {
  .v-card {
    padding: 2px;
  }

  .v-card-title {
    font-size: 1em;
  }

  .v-btn {
    margin: 3px 0;
  }

  .v-icon {
    font-size: 20px;
  }
}
</style>
