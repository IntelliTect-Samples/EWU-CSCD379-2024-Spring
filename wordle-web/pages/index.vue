<template>
  <v-card>
      <v-card-title class="text-blue">WELCOME TO OUR SIMPLE GAME!</v-card-title>
  </v-card>

  <v-card class="mx-auto my-8" elevation="16" max-width="344">
      <v-card-item>
        <v-card-title class="text-blue">  Hillbilly Wordle! </v-card-title>
      </v-card-item>

      <v-card-text class="text-black">
        Hi guys<br/>
        <br/>
        This is Hadi and Cynthia's simple game.
        <br/>
        <br/>
        Click the 'GO TO GAME' button to go to the game!
      </v-card-text>

      <v-card-actions>
      <v-btn color="blue" @click="router.push('/game')">Go To Game</v-btn>
      </v-card-actions>
    </v-card>
</template>

<script setup lang="ts">
const router = useRouter()

</script>