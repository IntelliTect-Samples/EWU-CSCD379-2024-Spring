<template>
  <NuxtLayout>
    <v-app>
      <v-app-bar color="primary" :elevation="2">
        <template v-slot:prepend>
          <v-icon color="secondary"> mdi-book </v-icon>
        </template>
        <v-btn @click="showUserNameDialog = true">{{ displayedUserName }}</v-btn>
        <NameDialog v-model="showUserNameDialog" />

        <v-app-bar-title>WordleApp</v-app-bar-title>

        <v-btn @click="router.push('/')">Home</v-btn>
        <v-btn @click="router.push('/test')">Test</v-btn>
        <v-btn icon="mdi-theme-light-dark" @click="toggleTheme" />
        <v-btn icon="mdi-help-circle" @click="showHelpDialog = true" />
        <HelpDialog v-model="showHelpDialog" />
      </v-app-bar>
      <v-main>
        <NuxtPage />
      </v-main>
    </v-app>
  </NuxtLayout>
</template>

<script setup lang="ts">
import { useTheme } from "vuetify";
import nuxtStorage from "nuxt-storage";

const router = useRouter();
const theme = useTheme();
const showHelpDialog = ref(false);

const showUserNameDialog = ref(false);
const userName = ref('guest');

provide("userName", userName);
provide("showUserNameDialog", showUserNameDialog.value);

onMounted(() => {
  var defaultTheme = nuxtStorage.localStorage.getData("theme");
  theme.global.name.value = defaultTheme ?? "dark";
  
  
  var storedUserName = nuxtStorage.localStorage.getData("userName");
  if(storedUserName || storedUserName == "guest"){
    userName.value = storedUserName;
  }
  if(userName.value == "guest" || userName.value == undefined){
    showUserNameDialog.value = true;
  } 
});

function toggleTheme() {
  if (theme.global.name.value === "light") {
    theme.global.name.value = "dark";
  } else {
    theme.global.name.value = "light";
  }

  nuxtStorage.localStorage.setData("theme", theme.global.name.value);
}

const displayedUserName = computed(() => userName.value);
</script>
