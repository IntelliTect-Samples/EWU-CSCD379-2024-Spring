<template>
  <NuxtLayout>
    <v-app class="myFontDefault">
      <v-app-bar color="primary">
        
        <v-app-bar-title>Pentagram</v-app-bar-title>
        <template v-slot:prepend>
          <v-icon size="x-large">mdi-pentagram</v-icon>
        </template>
        <v-btn @click="router.push('/')">Home</v-btn>
        <v-btn @click="router.push('/game')">About</v-btn>
        <!-- create dropdown menu to dispay all themes-->
        <v-btn icon="mdi-theme-light-dark" @click="toggleTheme" />
        <v-menu>
          <template v-slot:activator="{ props }">
            <v-btn v-bind="props" icon>
              <v-icon>mdi-compare</v-icon>
            </v-btn>
          </template>
          <v-list>
            <v-list-item v-for="theme in themes"  @click="changeTheme(theme.theme)">
              <v-list-item-title>{{ theme.name }}</v-list-item-title>
            </v-list-item>
          </v-list>
        </v-menu>
        <v-btn icon="mdi-help-box" @click="showHelpDialog = true" />
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
let font = changeFont();
const themes = [
  { name: "default", theme: "dark"},
  { name: "sans", theme: "sansDark"},
  { name: "watermelon", theme: "jaringDark"},
];
onMounted(() => {
  var defaultTheme = nuxtStorage.localStorage.getData('theme');
  var defaultFont = nuxtStorage.localStorage.getData('font');
});

function changeTheme(themeName: string) {
  theme.global.name.value = themeName;
  changeFont();
  nuxtStorage.localStorage.setData('theme', themeName)
  nuxtStorage.localStorage.setData('font', font)
}

function toggleTheme() {
  if (theme.global.name.value === "dark") {
    changeTheme("light");   
  } else if(theme.global.name.value === "sansLight") {
    changeTheme("sansDark");
  } else if(theme.global.name.value === "sansDark") {
    changeTheme("sansLight");
  } else if(theme.global.name.value === "jaringLight") {
    changeTheme("jaringDark");
  } else if(theme.global.name.value === "jaringDark") {
    changeTheme("jaringLight");
  } else {
    changeTheme("dark");
  }
}
function changeFont():string {
  if (theme.global.name.value === "dark" || theme.global.name.value === "light") {
    return "myFontDefault";  
  } else if(theme.global.name.value === "sansLight" || theme.global.name.value === "sansDark") {
    return  "myFontSans";
  } else if(theme.global.name.value === "jaringLight" || theme.global.name.value === "jaringDark") {
    return "myFontJaring";
  } else {
    return "myFontDefault";
  }
}
</script>
<style>
.myFontSans {
  font-family: 'comic sans ms';
}
.myFontDefault {
  font-family: 'pentagram';
}
.myFontJaring{
  font-family: 'default';
}
</style>