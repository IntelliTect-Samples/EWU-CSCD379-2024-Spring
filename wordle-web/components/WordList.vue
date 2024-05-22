<template>
  <v-bottom-sheet v-model="modelValue">
    <v-card>
      <v-autocomplete
        v-model="selectedWord"
        prepend-inner-icon="mdi-magnify"
        :items="validWords()"
        placeholder="Enter a Word!"
        @update:modelValue="updatePage"
        :disabled="game.gameState !== GameState.Playing"
      />
      <v-btn
        height="40px"
        v-for="word in pagedWords"
        :key="word"
        @click="addGuess(word)"
        flat
        :disabled="game.gameState !== GameState.Playing"
      >
        {{ word.toUpperCase() }}
      </v-btn>
      <v-card-item>
        <v-pagination
          v-if="totalPages > 1"
          density="compact"
          v-model="currentPage"
          :length="totalPages"
        />
      </v-card-item>
      <v-card-actions class="mx-auto">
        <v-btn @click="modelValue = false" color="secondary" variant="flat">
          <v-icon class="mr-2" icon="mdi-close" />
          Close
        </v-btn>
      </v-card-actions>
    </v-card>
  </v-bottom-sheet>
</template>
