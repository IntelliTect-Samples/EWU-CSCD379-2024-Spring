<template>
    <v-container>
      <v-card>
        <v-card-title class="font-weight-bold my-3">
          Word Editor
          <v-btn-toggle
            v-if="isEditUser || isLoggedIn"
            variant="outlined"
            v-model="userMode"
            density="compact"
            class="ml-3"
            mandatory
          >
            <v-btn>View</v-btn>
            <v-btn>Edit</v-btn>
          </v-btn-toggle>
        </v-card-title>
        <v-card-item>
          <v-data-table
            :headers="headers"
            :items="wordsList"
            :items-per-page="pageSize"
            :loading="isWordsListLoading"
            :sort-by="[{ key: 'word', order: 'asc' }]"
            :header-props="{ class: 'text-uppercase' }"
            :cell-props="{ class: 'text-uppercase text-button py-3' }"
            v-model:page="pageNumber"
          >
            <template v-slot:top>
              <v-row class="mb-1">
                <v-col cols="12" lg="5" md="6" sm="12">
                  <v-text-field
                    v-model="query"
                    label="Search for a word"
                    hide-details
                    clearable
                    single-line
                    variant="outlined"
                    density="compact"
                  />
                </v-col>
                <v-col cols="12" lg="3" md="6" sm="6">
                  <v-slider v-model="pageSize" min="10" max="100" step="1">
                    <template v-slot:append>
                      <v-select
                        v-model="pageSize"
                        :items="[10, 20, 25, 50, 100]"
                        hide-details
                        density="compact"
                        variant="outlined"
                      />
                    </template>
                  </v-slider>
                </v-col>
                <v-col cols="auto">
                  <v-btn variant="outlined" @click="resetFilters" text="Clear" />
                </v-col>
                <v-col cols="auto" v-if="isEditMode && isEditUser">
                  <v-btn
                    variant="outlined"
                    @click="showAddEditor = true"
                  >
                    <v-icon>mdi-plus</v-icon>
                    Add Word
                  </v-btn>
                </v-col>
              </v-row>
            </template>
            <template v-slot:item.isCommon="{ item }">
              <v-icon :icon="item.isCommon ? 'mdi-check' : 'mdi-close'" />
            </template>
            <template v-slot:item.actions="{ item }" v-if="isEditMode">
              <div class="d-flex ga-3">
                <v-btn
                  color="primary"
                  @click="editWord(item)"
                >
                  <v-icon icon="mdi-pencil" />
                  {{ $vuetify.display.smAndDown ? "" : "Edit" }}
                </v-btn>
                <v-btn
                  color="error"
                  @click="deleteWord(item.word)"
                >
                  <v-icon icon="mdi-delete" />
                  {{ $vuetify.display.smAndDown ? "" : "Delete" }}
                </v-btn>
              </div>
            </template>
            <template v-slot:bottom>
              <v-divider />
              <v-row class="pa-4">
                <v-col cols="12" lg="12">
                  <v-pagination
                    v-model="pageNumber"
                    :length="Math.ceil(totalCount / pageSize)"
                    @input="refreshWords"
                    variant="outlined"
                    density="comfortable"
                  />
                </v-col>
                <v-col cosl="auto">
                  <v-btn
                    variant="outlined"
                    @click="returnToTop"
                    text="BACK TO TOP"
                  />
                </v-col>
              </v-row>
            </template>
          </v-data-table>
        </v-card-item>
      </v-card>
      <EditWordDialog
        v-model="showEditor"
        :isAdd="false"
        :word="chosenWord"
        @updated="refreshWords"
      />
      <EditWordDialog
        v-model="showAddEditor"
        :isAdd="true"
        @updated="refreshWords"
      />
    </v-container>
  </template>
  
  <script setup lang="ts">
  import { ref, computed, onMounted, watch } from 'vue';
  import Axios from 'axios';
  import TokenService from '~/scripts/tokenService';
  import EditWordDialog from '~/components/EditWordDialog.vue';
  import type { WordDto } from '~/Models/WordDto';
  
  const wordsList = ref<WordDto[]>([]);
  const isWordsListLoading = ref(true);
  const showEditor = ref(false);
  const showAddEditor = ref(false);
  const chosenWord = ref<WordDto>();
  
  const pageNumber = ref(1);
  const pageSize = ref(10);
  const query = ref('');
  
  const userMode = ref(0);
  const tokenService = new TokenService();
  
  const isEditMode = computed(() => userMode.value === 1);
  const totalCount = ref(0);
  
  const isEditUser = computed(() => tokenService.isLoggedIn() && tokenService.canDeleteAndAdd());
  const isLoggedIn = computed(() => tokenService.isLoggedIn());
  
  const headers = computed(() => [
    { text: 'Word', value: 'word' },
    { text: 'Is Common', value: 'isCommon' },
    isEditMode.value ? { text: 'Actions', value: 'actions' } : {},
  ]);
  
  useHead({
    title: 'Word Editor',
    meta: [{ name: 'description', content: 'Manage your words' }],
  });
  
  watch([query, pageSize], async () => {
    pageNumber.value = 1;
    await refreshWords();
  });
  
  watch(pageNumber, async () => {
    await refreshWords();
  });
  
  async function refreshWords() {
    wordsList.value = await getWords(query.value, pageNumber.value, pageSize.value);
  }
  
  function resetFilters() {
    query.value = '';
    pageSize.value = 10;
    pageNumber.value = 1;
    refreshWords();
  }
  
  function returnToTop() {
    window.scrollTo(0, 0);
  }
  
  async function getWords(query: string = '', pageNumber: number = 1, pageSize: number = 10): Promise<WordDto[]> {
    let items: WordDto[] = [];
    isWordsListLoading.value = true;
    try {
      const response = await Axios.get(`word/WordsList?query=${query}&page=${pageNumber}&pageSize=${pageSize}`);
      const data = response.data;
      items = data.items.map((item: any) => ({
        word: item.word,
        isCommon: item.isCommonWord,
      }));
      totalCount.value = data.count;
    } catch (error) {
      console.error('Error fetching words:', error);
    } finally {
      isWordsListLoading.value = false;
    }
    return items;
  }
  
  function editWord(word: WordDto) {
    chosenWord.value = word;
    showEditor.value = true;
  }
  
  async function deleteWord(word: string) {
    try {
      await Axios.delete(`/word/DeleteWord?word=${word}`);
      await refreshWords();
    } catch (error) {
      console.error('Error deleting word:', error);
    }
  }
  
  onMounted(refreshWords);
  </script>
  