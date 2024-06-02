<template>
  <div>
<!-- Support deleting a word ❌✅
Support adding a new word ❌✅
Editing words is not supported ❌✅
Duplicate words should not be allowed ❌✅
Add & support changing the common word boolean flag ❌✅
Filter the list of returned words by common words ❌✅
Words should be sorted alphabetically ❌✅ -->
  <!-- <v-container>
    <v-card class="pa-3">
      <v-card-title class="font-weight-bold text-center" >Word Editor</v-card-title>
    </v-card>
    <v-card-item>
        <v-row>
          <v-col cols="auto">
            <v-btn color="primary">
              Add Word
            </v-btn>
          </v-col>
          <v-col cols="auto">
          </v-col>
          <v-col cols="auto">
            <v-btn color="primary">
              EXTRA BUTTON FOR NOW
            </v-btn>
          </v-col>
          <v-col cols="auto">
          </v-col>
        </v-row>
    </v-card-item>
  </v-container> -->

  <v-container>
    <v-card class="pa-3" color="secondary">
      <v-card-title class="font-weight-bold text-center" >Word Editor</v-card-title>
    </v-card>
    <v-text-field class="pa-3" v-model="searchTerm" label="Search words" style="color: saddlebrown; background-color: lavenderblush;"></v-text-field>
    <v-data-table :headers="headers" :items="filteredWords" style="color: rebeccapurple; background-color: pink;"></v-data-table>
    <v-btn @click="addWord" color="primary">Add Word</v-btn>
  </v-container>
  </div>

  
</template>

<script lang="ts">
import { defineComponent, ref, computed } from 'vue'

export default defineComponent({
  setup() {
    const searchTerm = ref('')
    const words = ref([])

    const headers = [
      { text: 'Word', value: 'word' },
      { text: 'Common', value: 'isCommon' },
      { text: 'Actions', value: 'actions' }
    ]

    const filteredWords = computed(() => {
      return words.value.filter(word => word.startsWith(searchTerm.value))
    })

    const addWord = () => {
      // Logic for adding a word
    }

    return { searchTerm, headers, filteredWords, addWord }
  }
})
</script>

<style>

</style>