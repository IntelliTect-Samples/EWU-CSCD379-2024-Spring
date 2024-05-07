<template>
  <v-container class="text-center">
    <v-card class="mx-auto" max-width="800" outlined>
      <v-card-title class="text-h5">LEADERBOARD</v-card-title>
      <v-card-text>
        <v-row>
          <v-col cols="4">
            NAME 
          </v-col>
          <v-col cols="4">
            AVG GUESSES
          </v-col>
          <v-col cols="4">
            PLAYS
          </v-col>
        </v-row>
        <v-divider></v-divider>
        <v-table>
          <tbody>
            <tr v-for="(player, index) in leaderboard" :key="index">
              <td class="text-left">{{ player.name }}</td>
              <td>{{ player.averageGuesses }}</td>
              <td>{{ player.plays }}</td>
            </tr>
          </tbody>
        </v-table>
      </v-card-text>
    </v-card>
  </v-container>
</template>

<script setup>
//SAMPLE DATA FOR NOW :(
const leaderboard = ref([
  { name: 'Player 1', averageGuesses: 5, plays: 10 },
  { name: 'Player 2', averageGuesses: 4, plays: 15 },
  { name: 'Player 3', averageGuesses: 6, plays: 8 },

]);
</script>
