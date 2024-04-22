<template>
  <div class="word-list-dialog">
    <v-dialog v-model="dialog" max-width="500px">
      <v-card>
        <v-card-title>Known Incantations</v-card-title>
        <v-card-text>
          <v-virtual-scroll
            :height="300"
            :items="validWords"
            item-height="48"
          >
            <template v-slot="{ item }">
              <v-list-item
                class="word-item"
                @click="selectWord(item)"
              >
                {{ item }}
              </v-list-item>
            </template>
          </v-virtual-scroll>
        </v-card-text>
      </v-card>
    </v-dialog>
    <v-btn @click="dialog = true">Spellbook</v-btn>
  </div>
</template>

<script setup lang="ts">
import { ref } from 'vue';
import { useGame } from '../scripts/game';

const dialog = ref(false);
// Destructure the validWords and other methods directly
const { validWords, addGuess } = useGame();

function selectWord(word) {
  addGuess(word);
  dialog.value = false; // Close the dialog
}
</script>

<style scoped>
.word-list-dialog {
  display: flex;
  justify-content: flex-end; /* Align to the right */
  margin-bottom: 10px; /* Adjust spacing as needed */
}

.word-item {
  cursor: pointer;
  padding: 10px;
  margin: 5px 0;
}

.word-item:hover {
  background-color: #e0e0e0; /* Highlight item on hover */
}
</style>
