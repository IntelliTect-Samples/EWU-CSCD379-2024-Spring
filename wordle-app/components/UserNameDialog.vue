<template>
	<v-dialog v-model="showModel" max-width="500" persistent>
		<v-card>
			<v-sheet color="primary">
				<v-card-text>Enter your name</v-card-text>
			</v-sheet>
			<v-form class="mx-3 mt-5">
				<v-text-field v-model="nameModel" label="Name" variant="outlined" clearable>
				</v-text-field>
			</v-form>
			<v-card-actions class="mx-4 mb-3">
				<v-spacer></v-spacer>
				<v-btn color="success" variant="elevated" text="Ok" @click="saveName, $emit('startStopwatch')" />
			</v-card-actions>
		</v-card>
	</v-dialog>
</template>

<script setup lang="ts">
import nuxtStorage from "nuxt-storage";

const showModel = defineModel<boolean>('show');
const nameModel = defineModel<string>('userName');

function saveName() {
	nuxtStorage.localStorage.setData("userName", nameModel.value);
	showModel.value = false;
}
</script>
