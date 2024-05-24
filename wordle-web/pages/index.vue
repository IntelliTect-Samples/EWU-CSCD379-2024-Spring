<template>
  <v-card class="text-center">
    <v-card-title>Pentagram</v-card-title>
    <v-card-subtitle>Word of five symbols</v-card-subtitle>
    <v-card-text
      >Welcome to Pentagram, This is a clone of wordle we built for an
      assignment. You can play Wordle of the day and view the leaderboard, or
      you can play the never ending wordle where you can play as many game as
      you want with no stat tracking.
    </v-card-text>
    <v-card>
      <v-card-subtitle>Navigation</v-card-subtitle>
      <v-card-text
        >You can enter your username by clicking on the name. The gear lets you
        change themes. The hamburger will let you select the pages. On the game
        pages there is a ? that shows the help page
      </v-card-text>
    </v-card>
    <v-btn variant="flat" color="primary" @click="router.push('/wordleOfTheDay')"
      >Play Wordle of the Day</v-btn>
    <v-btn variant="flat" color="primary" @click="router.push('/neverEndingWordle')">Play never ending wordle</v-btn>
  </v-card>
</template>
<script setup lang="ts">
const router = useRouter();
</script>
