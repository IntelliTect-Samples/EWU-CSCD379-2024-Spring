<template>
	<v-container style="max-width: 900px;">
		<v-card class="mb-5">
			<v-sheet color="primary">
				<v-card-text> How to play Word of The Day </v-card-text>
			</v-sheet>
			<v-card-text>
				Wordle with "Word of the Day" is a fun and challenging word puzzle game. Each day, a new "Word of the Day" is
				chosen. Your task is to guess this five-letter word within a certain number of attempts. After each guess,
				Wordle will provide feedback to indicate if each letter in your guess is in the correct position (green), in the
				word but in the wrong position (yellow), or not in the word at all (gray). Use this feedback to refine your
				guesses and find the "Word of the Day"!
			</v-card-text>
		</v-card>
		<v-card>
			<v-sheet color="primary">
				<v-card-text> How to play Random Word </v-card-text>
			</v-sheet>
			<v-card-text>
				In this version of Wordle, you can choose a specific date and guess the "Word of the Day" for that date. The
				game mechanics remain the same: you're tasked with guessing a five-letter word within a certain number of
				attempts. After each guess, Wordle will provide feedback to indicate if each letter in your guess is in the
				correct position (green), in the word but in the wrong position (yellow), or not in the word at all (gray). Use
				this feedback to refine your guesses and find the "Word of the Day" for your chosen date!
			</v-card-text>
		</v-card>

		<v-row justify="center" class="text-center mt-5">
      <v-col cols="12" sm="4" md="3" class=" d-flex justify-center">
        <v-btn color="primary" @click="router.push('/RandomWordGame')">Play Random Word</v-btn>
      </v-col>
      <v-col cols="12" sm="4" md="3" class=" d-flex justify-center">
        <v-btn color="primary" @click="router.push('/WordOfTheDayGame')">Play Word of the Day</v-btn>
      </v-col>
      <v-col cols="12" sm="4" md="3" class=" d-flex justify-center">
        <v-btn color="secondary" @click="router.push('/')">Go Home</v-btn>
      </v-col>
    </v-row>






	</v-container>

</template>

<script setup lang="ts">
const router = useRouter();
</script>
