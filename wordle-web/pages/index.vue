<template>
  <div class="green-background" max-height="900">
  <v-card color="yellow" elevation="5" max-width="400">
      <v-card-title class=" font-weight-bold text-green" >Welcome To Our Hillbilly Simple Game!</v-card-title>
  </v-card>

  <v-card color="yellow" class="mx-15 my-10" elevation="16">
      <v-card-item>
        <v-card-title class="font-weight-bold text-green">  Hillbilly Guess Game! </v-card-title>
      </v-card-item>

      <v-card-text class="text-green">
        Hi guys<br/>
        <br/>
        This is Hadi and Cynthia's simple game.
        <br/>
        Click the 'GO TO GAME' button to go to the game!
      </v-card-text>

      <v-card-actions>
        <v-spacer />
      <v-btn color="green text-yellow font-weight-bold" variant="elevated" elevation="8" @click="router.push('/game')">
        Go To Game
      </v-btn>
      </v-card-actions>
    </v-card>
  </div>
</template>

<script setup lang="ts">
const router = useRouter()

</script>
<style>
.green-background {
  background-color: yellowgreen;
  height: 100vh
}
</style>