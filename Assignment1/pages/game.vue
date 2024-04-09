   <template>
    <v-card variant="tonal">
      <v-card-title>Hello Welcome to Mystery Number Madness!</v-card-title>
      <v-card-text><p>Welcome to my fun filled mystery number game! You will be tasked with figuring out my number and will get fun feedback along the way! Guess the mystery number between 1 and 100 and most importantly, HAVE FUN!</p></v-card-text>
      
      <v-row>
        <v-col cols="12" sm="6">
          <v-text-field v-model="guess" label="Enter your guess" type="number"></v-text-field>
          <v-btn @click="checkGuess">Submit Guess</v-btn>
        </v-col>
      </v-row>
      
      <v-alert v-if="message" :type="messageType as 'error' | 'success' | 'warning' | 'info'">{{ message }}</v-alert>
    </v-card>
  </template>
  
  <script setup lang="ts">
  import { guess, message, messageType, checkGuess } from '../scripts/game'
  </script>
  