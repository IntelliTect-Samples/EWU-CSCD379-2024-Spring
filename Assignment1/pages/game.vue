<template>
    <v-card>
      <v-card-title>Hello Welcome to Mystery Number Madness</v-card-title>
      
      <v-row>
        <v-col cols="12" sm="6">
          <v-text-field v-model="guess" label="Enter your guess" type="number"></v-text-field>
          <v-btn @click="checkGuess">Submit Guess</v-btn>
          <v-btn @click="goToHome">Go to Home</v-btn>
        </v-col>
      </v-row>
      
      <v-alert v-if="message" :type="messageType">{{ message }}</v-alert>
    </v-card>
  </template>
  
  <script setup lang="ts">
    import { ref } from 'vue'
    const secretNumber = Math.floor(Math.random() * 100) + 1
    const guess = ref('')
    const message = ref('')
    const messageType = ref<'error' | 'success' | 'warning' | 'info'>('error')
    const checkGuess = () => {
        const userGuess = parseInt(guess.value)

        if (isNaN(userGuess) || userGuess < 1 || userGuess > 100) {
            message.value = 'Please enter a valid number between 1 and 100.'
            messageType.value = 'error'
        } else if (userGuess < secretNumber) {
            message.value = 'Too low! Try again.'
            messageType.value = 'warning'
        } else if (userGuess > secretNumber) {
            message.value = 'Too high! Try again.'
            messageType.value = 'warning'
        } else {
            message.value = `Congratulations! You guessed the number ${secretNumber} correctly.`
            messageType.value = 'success'
        }

        // Clear the input field after each guess
        guess.value = ''
    }
    import { useRouter} from 'vue-router'
    const router = useRouter()
    const goToHome = () => {
        router.push('/')
    }
</script>
  