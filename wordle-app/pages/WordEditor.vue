<template>
  <v-container>
    <!-- <search-bar /> -->

    <v-data-table-server
			v-model:items-per-page="options.itemsPerPage"
      :headers="headers"
      :items="words"
			:items-length="totalWords"
      :options.sync="options"
      @update:options="fetchWords"
      :loading="isLoading"
			hover
			
    >
      <template #top>
        <v-text-field
          v-model="search"
          label="Search"
          @input="fetchWords"
          clearable
          clear-icon="mdi-close-circle"
        />
      </template>

      <template #item.actions="{ item }">
				<v-btn @click="deleteItem(item)" color="red">Delete</v-btn>
      </template>

			<!-- Template for switch to change isCommon -->
			<template #item.isCommon="{ item }">
				<v-switch class="d-inline-block" v-model="item.isCommon" color="green" label="Common" inset @change="updateItem(item)" />
			</template>
    </v-data-table-server>
  </v-container>
</template>

<script setup lang="ts">
import Axios from "axios";

const headers = [
	{ key: "text", text: "Word", title: "Word", sortable: false},
	{ key: "isCommon", text: "Common", title: "Common", sortable: false},
	{ key: "actions", text: "Actions", title: "Actions", sortable: false}
];

interface Word {
  isCommon: boolean;
  text: string;
}

const words = ref<Word[]>([]);
const isLoading = ref<boolean>(false);

const totalWords = ref<number>(0);
const search = ref("");
const options = ref({
  page: 1,
  itemsPerPage: 10
});

async function fetchWords() {
  const { page, itemsPerPage} = options.value;
  const params = {
		search: search.value,
    page,
    itemsPerPage,
  };




  try {
		isLoading.value = true;
    const response = (await Axios.get("/WordEditor/GetWords", { params }));

		words.value = response.data.words;
		totalWords.value = response.data.totalCount;
		console.log(response.data.totalCount);

  } catch (error) {
    console.error(error);
  } finally {
    isLoading.value = false;
  }

}

async function updateItem(item: Word) {
	try {
		isLoading.value = true;
		const response = await Axios.post("WordEditor/SetIsCommon?word=" + item.text + "&isCommon=" + item.isCommon);

		if(response.status === 200) {
			await fetchWords();
		}

	} catch (error) {
		console.error(error);
	} finally {
		isLoading.value = false;
	}

}

async function deleteItem(item: Word) {
	try {
		isLoading.value = true;
		const response = await Axios.post("/WordEditor/DeleteWord?word=" + item.text);

		if(response.status === 200) {
			await fetchWords();
		}

	} catch (error) {
		console.error(error);
	} finally {
		isLoading.value = false;
	}

}

watch([options, search], fetchWords, { immediate: true });
</script>
