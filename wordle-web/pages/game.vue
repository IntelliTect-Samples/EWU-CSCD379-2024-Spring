<template>
  <div class="green-background" max-height="900">
    <v-card color="black" elevation="5">
      <v-card-title class="green-text font-weight-bold">Hillbilly Guess Game</v-card-title>
    </v-card>
    
    <v-card color="yellow" class="mx-16 my-10" elevation="16">
      <v-card-item>
        <v-card-title class="text-green font-weight-bold"> Hillbilly Guess of the Day </v-card-title>
        <v-card-subtitle class="text-green"> This is our super basic game </v-card-subtitle>
      </v-card-item>

      <v-card-text class="text-green font-weight-bold">
      <br />
      WORD TO GUESS IS ....
      <br />
      <br />
      _ill bill_
      <br />
      <br />
    </v-card-text>

    <v-text-field class="text-green" v-model="myGuess" label="Enter your guess: " outlined clearable />
    
    <v-card-actions>
      <v-spacer />
      <v-btn color="green text-yellow font-weight-bold" variant="elevated" elevation="8" @click="checkIn()">
        Check my answer!
      </v-btn>
      <v-btn color="green text-yellow font-weight-bold" variant="elevated" elevation="8" @click="router.push('/')">take me home!</v-btn>
    </v-card-actions>
    <v-card-text class="text-green font-weight-bold text-center">
      YOUR GUESS: {{ myGuess }} <br />
      WAS IT RIGHT? {{ output }}
    </v-card-text>
    
  </v-card>
</div>
</template>

<script setup lang="ts">
import { ref } from "vue";
import { checkInput } from '~/scripts/gamescript';
const myGuess = ref("")

const output =  ref("")

function checkIn(){
  output.value = checkInput(myGuess.value);
}


const router = useRouter()
</script>


<style>

.red-background {
  background-color: red;
  height: 100vh
}

.green-background {
  background-color: yellowgreen;
  height: 100vh
}

.green-text{
  color: yellowgreen;
}
</style>
