<template>
  <div>
    <v-container>
      <v-card class="pa-3" color="secondary">
        <v-card-title class="font-weight-bold text-center wordEdit"
          >Word Editor</v-card-title
        >
      </v-card>
      <br /><br />
      <div>
        <v-text-field
          class="pa-3"
          v-model="searchTerm"
          label="Search words"
          style="color: saddlebrown; background-color: lavenderblush"
        ></v-text-field>
        <br /><br />
        <div class="text-center">
          <v-btn
            @click="showDialog = true"
            color="primary"
            >Add Word</v-btn
          >
        </div>
        <v-dialog v-model="showDialog" max-width="500">
          <v-card>
            <br />
            <v-card-title class="text-center">Add New Word</v-card-title>
            <v-card-text>
              <v-text-field
                v-model="newWord"
                label="Enter new word"
              ></v-text-field>
            </v-card-text>
            <v-card-actions>
              <v-btn color="primary" @click="addWord">Add</v-btn>
              <v-btn color="primary" @click="showDialog = false">Cancel</v-btn>
            </v-card-actions>
          </v-card>
        </v-dialog>
      </div>
      <v-data-table :items="filteredWords" class="custom-table wordListStyle">
        <template v-slot:header>
          <thead>
            <tr class="header-cell">
              <th class="header-cell">Word</th>
              <th class="header-cell">Common</th>
              <th class="header-cell">Actions</th>
            </tr>
          </thead>
        </template>
        <template v-slot:item="{ item }">
          <tr class="wordListStyle">
            <td>{{ item.word }}</td>
            <td>{{ item.isCommon }}</td>
            <td>
              <v-icon class="mr-2">mdi-flag</v-icon>
              <v-btn
                v-model="item.isCommon"
                @click="updateCommonStatus(item)"
                color="secondary"
                >common</v-btn
              >
            </td>
            <td>
              <v-icon class="mr-2">mdi-emoticon-dead-outline</v-icon>
              <v-btn
                @click="deleteWord(item)"
                color="secondary"
                >Delete</v-btn
              >
            </td>
          </tr>
        </template>
      </v-data-table>
      <v-snackbar v-model="snackbar.show" color="error" top>
        {{ snackbar.message }}
        <v-btn text @click="snackbar.show = false">Close</v-btn>
      </v-snackbar>
    </v-container>
  </div>
</template>

<script setup lang="ts">
import { ref, computed } from "vue";
import { WordList } from "~/scripts/wordList";
import nuxtStorage from "nuxt-storage";


// Initial word list setup
const formattedWordList = WordList.map((word) => ({
  word,
  isCommon: false,
  actions: false,
}));

const searchTerm = ref("");
const words = ref(formattedWordList);
const newWord = ref<string>("");
const snackbar = ref({ show: false, message: "" });
const showDialog = ref<boolean>(false);
var auth = nuxtStorage.localStorage.getData("isAuth");

console.log("WORDEDITOR QUTH:"+auth.value);
// Headers for the data table
const headers = [
  { text: "Word", value: "word" },
  { text: "Common", value: "isCommon" },
  { text: "Actions", value: "actions" },
];

// Filtered words based on search term
const filteredWords = computed(() => {
  const searchTermValue = searchTerm.value;
  if (typeof searchTermValue !== "string") {
    return [];
  }
  return words.value.filter((item: any) => {
    if (typeof item.word === "string") {
      return item.word.startsWith(searchTermValue);
    }
    return false;
  });
});

// Update common status of a word
const updateCommonStatus = (word) => {
  word.isCommon = !word.isCommon;
  console.log(
    `Common status updated for ${word.word}. New value: ${word.isCommon}`
  );
};



// Add a new word to the list
const addWord = () => {
    const wordToAdd = newWord.value.trim();
    var auth = nuxtStorage.localStorage.getData("isAuth");

    if(auth){
    if (wordToAdd !== "") {
      if (!words.value.some((word) => word.word === wordToAdd)) {
        words.value.push({ word: wordToAdd, isCommon: false });
        console.log("Word added:", wordToAdd);
        newWord.value = "";
        showDialog.value = false;
      } else {
        snackbar.value.message = "Word already exists!";
        snackbar.value.show = true;
        console.error("Word already exists!");
      }
    } else {
      snackbar.value.message = "Please enter a word!";
      snackbar.value.show = true;
    }
  }
  else {
    // Handle unauthorized access
    snackbar.value.message = "You are not authorized to add words!";
    snackbar.value.show = true;
  }
};

// Delete a word from the list
const deleteWord = (wordToDelete) => {
  var auth = nuxtStorage.localStorage.getData("isAuth");

  if (auth) {
    const index = words.value.findIndex(
      (word) => word.word === wordToDelete.word
    );
    if (index !== -1) {
      words.value.splice(index, 1);
      snackbar.value.message = "Word deleted successfully!";
      snackbar.value.show = true;
    } else {
      snackbar.value.message = "Word not found!";
      snackbar.value.show = true;
      console.error("Word not found!");
    }
  } else {
    // Handle unauthorized access
    snackbar.value.message = "You are not authorized to delete words!";
    snackbar.value.show = true;
  }
};

</script>

<style>
.custom-table {
  color: #cceeff !important;
  background-color: forestgreen !important;
  margin-top: 20px; /* Adjust as needed */
  margin-bottom: 20px; /* Adjust as needed */
}

.header-cell {
  font-weight: bold;
  border-bottom: 2px solid lavenderblush; /* Add a border between header cells */
}

/* for alternating row colors */
.custom-table tbody tr:nth-child(even) {
  background-color: lightgreen;
  color: #0000cc;
}

/* Adjust table row height */
.custom-table tbody tr {
  height: 60px; /* Adjust as needed */
}

/* Add padding to table cells */
.custom-table tbody td {
  padding: 8px;
}

.v-snackbar {
  position: fixed;
  top: 50%; /* to move the snackbar vertically */
  left: 50%;
  transform: translate(-50%, -50%); /* Center the snackbar */
  z-index: 9999; /* to make it appear above other elements */
}

.close-btn {
  position: absolute;
  top: 0;
  right: 0;
  margin: 0.5rem;
}
</style>
