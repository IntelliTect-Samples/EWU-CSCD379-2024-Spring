<template>
  <SignInDialog v-model="showSignInDialog" />

  <v-tooltip text="Sign in to access more features">
  <template v-slot:activator="{ props }">
    <v-btn v-bind="props" @click="showSignInDialog = true">sign in</v-btn>
  </template>
</v-tooltip>

  <v-tooltip text="mark the word as a common word">
    <template v-slot:activator="{ props }">
      <v-btn :disabled="!signedIn" v-bind="props">Common</v-btn>
    </template>
  </v-tooltip>
</template>
<script setup lang="ts">
import TokenService from "~/scripts/tokenService";

const showSignInDialog = ref(false);
const tokenService = new TokenService();
const signedIn = computed(() => tokenService.isLoggedIn());
onMounted(() => {
  if (tokenService.isLoggedIn()) {
    showSignInDialog.value = false;
  }
});
</script>
