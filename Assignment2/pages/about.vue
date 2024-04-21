<template>
	<!-- <v-card>
		<v-card-title>About</v-card-title>
		<v-card-text>
			<p> Wow this project is so amazing I definitely haven't stressed about it and lost sleep over it</p>
			<p> To be fair though meg is a nice teacher, it just seems like everything it very fast</p>
		</v-card-text>
	</v-card> -->

	<v-container class="ma-auto">
		<v-row justify="center">
			<v-col cols="12" md="8">
				<h1 class="ext-h4 my-4 text-center">
					About Our Game
				</h1>
				<div class="text-body-1 mb-3">
					Welcome to <strong>[Not a copy of] Wordle</strong>,
					a tribute to the wildly popular word puzzle game,
					Wordle, originally popularized by The New York Times.
					Our version offers you the fun and challenge of daily word puzzles where you can test your vocabulary and
					deduction skills.
				</div>

				<div class="text-body-1 mb-3">
					Our game is designed with simplicity and ease of use in mind. Each day, a new puzzle awaits you! The objective
					is simple: guess the hidden word in six tries or fewer. After each guess, you'll receive color-coded feedback
					to help you hone in on the correct word.
				</div>

				<div class="text-body-1">
					[Not a copy of] Wordle is a labor of love created by enthusiasts who admire the engaging and brain-teasing
					nature of
					word games. Whether you are a seasoned word-smith or just looking for a fun way to sharpen your linguistic
					skills, our game offers a fresh challenge every day.
				</div>

				<div class="text-body-1 my-4">
					We are committed to keeping [Not a copy of] Wordle free to play and accessible to everyone. As we continue to
					grow
					and improve, we welcome your feedback and suggestions. Enjoy the challenge, share it with friends, and thank
					you for playing!
				</div>
			</v-col>
		</v-row>
		<v-row justify="center">
			<v-col cols="12" md="8">
				<h1 class="ext-h4 my-4 text-center">
					About Our Teachers
				</h1>
				<div class="text-body-1 mb-3">
					<strong>Grant</strong> and <strong>Mag</strong> are the instructors for this course. They are both very
					knowledgeable and helpful. They are always willing to help and answer any questions you may have.
				</div>
			</v-col>
		</v-row>
		<!-- New row for the button -->
		<v-row justify="center">
			<v-col cols="12" class="text-center">
				<v-btn color="primary" variant="elevated" elevation="8" @click="router.push('/')">Home</v-btn>
			</v-col>
		</v-row>
	</v-container>
</template>

<script setup lang="ts">
const router = useRouter();
</script>
