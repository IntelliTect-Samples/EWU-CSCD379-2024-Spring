<template>
  <v-card>
    <v-card-title>Hillbilly Guess Game</v-card-title>
  </v-card>

  <v-card class="mx-auto my-8" elevation="16" max-width="344">
    <v-card-item>
      <v-card-title> Hillbilly Guess of the Day </v-card-title>
      <v-card-subtitle> This is our super basic game </v-card-subtitle>
    </v-card-item>

    <v-card-text>
      <br />
      WORD TO GUESS IS ....
      <br />
      <br />
      _ill bill_
      <br />
      <br />
    </v-card-text>

    <v-text-field v-model="myGuess" label="Enter your guess: " outlined clearable />

    <v-card-actions>
      <v-spacer />
      <v-btn color="blue" variant="elevated" elevation="8" @click="checkInput()">
        Check my answer!
      </v-btn>
      <v-btn color="blue" variant="elevated" elevation="8" @click="router.push('/')">take me home!</v-btn>
    </v-card-actions>
    <v-card-text>
      YOUR GUESS: {{ myGuess }} <br />
      WAS IT RIGHT? {{ output }}
    </v-card-text>
    
  </v-card>
</template>

<script setup lang="ts">

 var myGuess = ref("");

const output = ref("");

function checkInput() {
  if(myGuess.value == "hill billy"){
    output.value = "CORRECT"
  }
  else{
    output.value = "WRONG"
  }
}
const router = useRouter()
</script>
