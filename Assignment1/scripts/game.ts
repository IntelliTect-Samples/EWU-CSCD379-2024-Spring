import { ref } from 'vue'

const secretNumber = Math.floor(Math.random() * 100) + 1
const guess = ref('')
const message = ref('')
const messageType = ref('')

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

export { guess, message, messageType, checkGuess }
