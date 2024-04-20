<template>
	<v-card>
		<v-card-title>About</v-card-title>
		<v-card-text>
			<p> Placeholder for about page text</p>
			<p> Placeholder for Meg text</p>
		</v-card-text>
	</v-card>
	<v-btn
		color="primary"
		variant="elevated"
		elevation="8"
		@click="router.push('/')"
	>Home</v-btn>
</template>

<script setup lang="ts">
const router = useRouter();
</script>
