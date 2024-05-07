<template>
  <v-container class="text-center">
    <v-card class="mx-auto" max-width="1000" outlined>
      <v-card-title class="text-h5">LEADERBOARD</v-card-title>
      <v-card-text>
        <v-row>
          <v-col cols="1" class="text-center">
            ID
          </v-col>
          <v-col cols="6 " class="text-center">
            NAME 
          </v-col>
          <v-col cols="2" class="">
            AVG ATTEMPTS
          </v-col>
          <v-col cols="2" class="text-center" >
            PLAYS 
          </v-col>
        </v-row>
        <v-divider></v-divider>
        <v-table>
          <tbody>
            <tr v-for="(player, index) in leaderboard" :key="index">
              <td class="text-left">{{ player.id }}</td>
              <td class="text-center">{{ player.name }}</td>
              <td class="text-center">{{ player.averageGuesses }}</td>
              <td class="text-center">{{ player.plays }}</td>
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
  {id: 1, name: 'Player 1', averageGuesses: 5, plays: 10 },
  {id : 2, name: 'Player 2', averageGuesses: 4, plays: 15 },
  {id : 3,name: 'Player 3', averageGuesses: 6, plays: 8 },

]);
</script>
