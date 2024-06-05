<template>
  <div>
    <v-container>
      <v-card class="pa-3" color="secondary">
        <v-card-title class="font-weight-bold text-center  wordEdit" 
          >Word Editor</v-card-title
        >
      </v-card>
      <v-text-field
        class="pa-3"
        v-model="searchTerm"
        label="Search words"
        style="color: saddlebrown; background-color: lavenderblush"
      ></v-text-field>
      <!-- <v-data-table
        :headers="headers"
        :items="filteredWords"
        style="color: rebeccapurple; background-color: pink"
      >
        <template v-slot:header="{ header }">
          {{ header.text }}
        </template>
      </v-data-table> -->
      <v-text-field
        v-model="newWord"
        label="Enter new word"
        outlined
        dense
        class="mb-4"
      ></v-text-field>
      <v-btn class="pa-3" @click="addWord" color="primary">Add Word</v-btn>
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
              <v-icon>mdi-emoticon-dead-outline</v-icon>
              <v-btn @click="deleteWord(item)" color="secondary">Delete</v-btn>
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

<script lang="ts">
import { defineComponent, ref, computed } from "vue";
import { WordList } from "~/scripts/wordList";
export default defineComponent({
  setup() {
    const formattedWordList = WordList.map((word) => ({
      word,
      isCommon: false,
      actions: false,
    }));
    const searchTerm = ref("");
    const words = ref(formattedWordList);
    const newWord = ref("");
    const snackbar = ref({ show: false, message: "" });

    const headers = [
      { text: "Word", value: "word" },
      { text: "Common", value: "isCommon" },
      { text: "Actions", value: "actions" },
    ];

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

    const addWord = () => {
      const wordToAdd = newWord.value.trim();
      if (wordToAdd !== "") {
        // Check if word already exists
        if (!words.value.some((word) => word.word === wordToAdd)) {
          // Add the new word to the list
          words.value.push({ word: wordToAdd, isCommon: false });
          // Clear the input field
          newWord.value = "";
        } else {
          // Word already exists
          snackbar.value.message = "Word already exists!";
          snackbar.value.show = true;
          console.error("Word already exists!");
        }
      } else {
        snackbar.value.message = "Please enter a word!";
        snackbar.value.show = true;
        // Input field is empty, show error message or handle accordingly
        console.error("Please enter a word!");
      }
    };
    // const sprinkleAnimation = () => {
    //   const sprinkleCount = 30; // Adjust as needed
    //   const container = document.querySelector(".sprinkle-container");
    //   if (!container) return;

    //   for (let i = 0; i < sprinkleCount; i++) {
    //     const sprinkle = document.createElement("div");
    //     sprinkle.classList.add("sprinkle");
    //     sprinkle.style.left = `${Math.random() * 100}%`;
    //     sprinkle.style.animationDuration = `${Math.random() * 1 + 0.5}s`; // Adjust animation duration
    //     sprinkle.style.animationDelay = `${Math.random() * 1}s`; // Adjust animation delay
    //     container.appendChild(sprinkle);
    //   }

    //   // Remove sprinkle elements after animation completes
    //   setTimeout(() => {
    //     container.innerHTML = "";
    //   }, 2000); // Adjust timing based on your animation duration
    // };
    const deleteWord = (wordToDelete) => {
    const index = words.value.findIndex(word => word.word === wordToDelete.word);
    if (index !== -1) {
      // Remove the word from the array
      words.value.splice(index, 1);
      snackbar.value.message = "Word deleted successfully!";
      // sprinkleAnimation();
      snackbar.value.show = true;
    } else {
      // Word not found in the list
      snackbar.value.message = "Word not found!";
      snackbar.value.show = true;
      console.error("Word not found!");
    }
    
  };

    return { searchTerm, headers, filteredWords, addWord, deleteWord, snackbar};
  },
  data() {
    return {
      headers: [
        { text: "Word", value: "word" },
        { text: "Common", value: "isCommon" },
        { text: "Actions", value: "actions" },
      ],
    };
  },
});
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
  z-index: 9999; /* to make it appears above other elements */
}

/* Close button style */
.close-btn {
  position: absolute;
  top: 0;
  right: 0;
  margin: 0.5rem; /* Adjust the margin as needed */
}


</style>
<!-- .sprinkle-container {
  position: absolute;
  top: 0;
  left: 0;
  width: 100%;
  height: 100%;
  pointer-events: none; /* Ensure sprinkle elements don't interfere with mouse events */
}

.sprinkle {
  position: absolute;
  width: 4px;
  height: 4px;
  background-color: #ffd700; /* Sprinkle color */
  border-radius: 50%;
  animation: sprinkle-fall linear; /* Use your preferred animation */
}
@keyframes sprinkle-fall {
  0% {
    transform: translateY(-100%);
    opacity: 0;
  }
  100% {
    transform: translateY(100%);
    opacity: 1;
  }
} -->

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
