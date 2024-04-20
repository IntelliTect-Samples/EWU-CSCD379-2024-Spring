<template>
	<v-card>
		<v-card-title>About</v-card-title>
		<v-card-text>
			<p> Wow this project is so amazing I definitely haven't stressed about it and lost sleep over it</p>
			<p> To be fair though meg is a nice teacher, it just seems like everything it very fast</p>
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
