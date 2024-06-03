<template>
  <SignInDialog v-model="showSignInDialog" />
  <v-card>
    <v-card-title class="text-center">Word List</v-card-title>
    <v-tooltip text="Sign in to access more features">
      <template v-slot:activator="{ props }">
        <v-btn v-bind="props" color ="primary" @click="showSignInDialog = true">Sign In</v-btn>
      </template>
    </v-tooltip>
    <v-text-field clearable label ="Search" v-model ="wordToSearch" ></v-text-field>
    <v-tooltip text="mark the word as a common word">
      <template v-slot:activator="{ props }">
        <v-btn :disabled="!signedIn" color ="primary"v-bind="props">Common</v-btn>
      </template>
    </v-tooltip>
    <div class="d-flex">
      <v-text-field clearable label ="Add A Word" v-model = wordToAdd ></v-text-field>
      <v-tooltip text="Add a word to the word list">
        <template v-slot:activator="{ props }">
          <v-btn :disabled="!canAddWords" color ="primary" v-bind="props" @click ="console.log('word to add ' + wordToAdd)">Add Word</v-btn>
        </template>
      </v-tooltip>
    </div>
  </v-card>
</template>
<script setup lang="ts">
import TokenService from "~/scripts/tokenService";

const showSignInDialog = ref(false);
const tokenService = new TokenService();
const wordToAdd = ref("");
const wordToSearch = ref("");
const signedIn = computed(() => tokenService.isLoggedIn());
const parseToken = computed(() => tokenService.parseToken());
const canAddWords = computed(() => {
  if (parseToken.value[5] == "true" && parseInt(parseToken.value[4]) >= 21) {
    return true;
  } else {
    return false;
  }
});
onMounted(() => {
  if (tokenService.isLoggedIn()) {
    showSignInDialog.value = false;
  }
});
</script>
