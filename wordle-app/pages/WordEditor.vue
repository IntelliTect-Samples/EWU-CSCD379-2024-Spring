<template>
	<v-container>

	</v-container>

</template>

<script setup lang="ts">
import Axios from 'axios';

interface Word {
	text: string;
	isCommon: boolean;
}

const words = ref<Word[]>([]);
const isLoading = ref<boolean>(false);

onMounted();

async function onMounted() {
	isLoading.value = true;
	try {
		const response = await Axios.get('/WordEditor/GetWords');
		words.value = response.data;
		console.log(words.value[0].text);
	} catch (error) {
		console.error(error);
	} finally {
		isLoading.value = false;
	}
}

</script>
