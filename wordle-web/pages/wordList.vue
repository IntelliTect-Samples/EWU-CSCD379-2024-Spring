<template>
    <SignInDialog v-model="showSignInDialog" />
    <v-btn @click="showSignInDialog = true">Sign In</v-btn>
    <v-btn :disabled="!signedIn" >Common</v-btn>
</template>
<script setup lang="ts">
import TokenService from '~/scripts/tokenService';

const showSignInDialog = ref(false);
const tokenService = new TokenService();
const signedIn = computed(() => tokenService.isLoggedIn());
onMounted(() => {
    if (!tokenService.getToken || !tokenService.isLoggedIn()) {
        showSignInDialog.value = true;
    }
});
</script>