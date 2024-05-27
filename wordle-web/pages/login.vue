<template>
  <v-container>
    <v-card color="secondary" class="mx-auto pa-8 rounded text-center">
      <v-card-title class="text-wrap text-h5"> Login </v-card-title>
      <v-card-text class="text-h6 text-cente ma-2">
        Login or Register to access more of our features:
      </v-card-text>
      <v-tabs v-model="currentPage" align-tabs="center">
        <v-tab>Login</v-tab>
        <v-tab>Register</v-tab>
      </v-tabs>
      <v-tabs-window v-model="currentPage">
        <v-tabs-window-item>
          <v-card-text class="text-body-1">
            Enter a valid email and password to your account.
          </v-card-text>
        </v-tabs-window-item>
        <v-tabs-window-item> </v-tabs-window-item>
      </v-tabs-window>
      <v-divider />
      <v-card-actions class="d-flex justify-center my-1">
        <v-btn
          color="white"
          class="bg-primary pa-2 px-5"
          to="/"
          text="Go Home"
        />
      </v-card-actions>
    </v-card>
  </v-container>
</template>
<script setup lang="ts">
useHead({
  title: "How to Play",
  meta: [{ name: "description", content: "Cool site!" }],
});
const currentPage = ref(0);
</script>
