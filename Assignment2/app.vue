<template>
  <NuxtLayout>
    <v-app>
      <v-app-bar color="primary" :elevation="2">
        <template v-slot:prepend>
          <v-btn icon = mdi-book
             @click="router.push('/')"></v-btn>
             <v-btn @click="router.push('/')">WordleApp</v-btn>
        </template>
        <v-btn icon="mdi-cog" @click="showSettingsDialog = true" />
        <!-- <v-btn icon="mdi-cog" @click="toggleMenu" /> -->
        <v-btn icon="mdi-help-circle" @click="showHelpDialog = true" />
        <HelpDialog v-model="showHelpDialog" />
        <v-btn @click="toggleDrawer" icon = "mdi-menu"></v-btn>
      </v-app-bar>
      <v-navigation-drawer v-model="drawer"  location="right" disable-resize-watcher>
        <v-list>
          <v-list-item @click="router.push('/About')" class="text-center">About</v-list-item>
        </v-list>
      </v-navigation-drawer>
      <!-- <v-navigation-drawer v-model="menu"  location="right">
        <v-list>
          <v-list-item class="text-center">Choose your color mode!</v-list-item>
          <v-list-item @click="menuItemClicked(1)" class="text-center">Light Mode</v-list-item>
          <v-list-item @click="menuItemClicked(2)" class="text-center">Dark Mode</v-list-item>
          <v-list-item @click="menuItemClicked(3)" class="text-center">Light Rainbow Mode</v-list-item>
          <v-list-item @click="menuItemClicked(4)" class="text-center">Light Noir Mode</v-list-item>
          <v-list-item @click="menuItemClicked(5)" class="text-center">Dark Rainbow Mode</v-list-item>
          <v-list-item @click="menuItemClicked(6)" class="text-center">Dark Noir Mode</v-list-item>
        </v-list>
      </v-navigation-drawer> -->
      <v-main>
        <NuxtPage />
      </v-main>
    </v-app>
  </NuxtLayout>
  <SettingsDialog v-model="showSettingsDialog" />
</template>

<script setup lang="ts">
import { useTheme } from "vuetify";
import nuxtStorage from "nuxt-storage";

const router = useRouter();
const theme = useTheme();
const showHelpDialog = ref(false);
const showSettingsDialog = ref(false);
var drawer = ref(false);
// var menu = ref(false);
function toggleDrawer() {
  drawer.value = !drawer.value;
}


onMounted(() => {
  var defaultTheme = nuxtStorage.localStorage.getData("theme");
  theme.global.name.value = defaultTheme ?? "dark";
});

// Tim's code

// function toggleMenu(){
//   menu.value = !menu.value;
// }

// function menuItemClicked(item: number){
//   if(item == 1){
//     theme.global.name.value = "light";
//   }
//   else if(item == 2){
//     theme.global.name.value = "dark";
//   }
//   else if(item == 3){
//     theme.global.name.value = "lightrainbow";
//   }
//   else if(item == 4){
//     theme.global.name.value = "lightnoir";
//   }
//   else if(item == 5){
//     theme.global.name.value = "darkrainbow";
//   }
//   else if(item == 6){
//     theme.global.name.value = "darknoir";
//   }
//   nuxtStorage.localStorage.setData("theme", theme.global.name.value);
// }

</script>