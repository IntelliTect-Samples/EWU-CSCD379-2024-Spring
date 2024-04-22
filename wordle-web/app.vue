<template>
  <NuxtLayout>
    <v-app>
      <v-app-bar color="primary" :elevation="2">

        <template v-slot:append>
          <v-btn icon="mdi-theme-light-dark" @click="toggleTheme" />
          <v-btn icon="mdi-help-circle" @click="showHelpDialog = true" />
          <HelpDialog v-model="showHelpDialog" />
          <v-app-bar-nav-icon
            color="secondary"
            @click="toggleMenu"
            :class="{ 'rotate': menuOpen}"
          ></v-app-bar-nav-icon>
        </template>
        
        <template v-slot:prepend>
          <v-app-bar-nav-icon
            color = "secondary"
            icon="mdi-book"
            @click="router.push('/')"
          ></v-app-bar-nav-icon>
          <v-btn @click="router.push('/')">WORDLE</v-btn>
        </template>

      </v-app-bar>
      
      <v-navigation-drawer
        location="right" 
        v-model="menuOpen" app>
        <v-list>
          <v-list-item link @click="router.push('/')">
            <v-list-item-title>Home</v-list-item-title>
          </v-list-item>
          <v-list-item link @click="router.push('/about')">
            <v-list-item-title>About</v-list-item-title>
          </v-list-item>
          <v-list-item>
            <template>
              <v-btn icon="mdi-cog" @click="showSettingDialog = true" />
              <SettingsDialog v-model="showSettingDialog" />
            </template>
          </v-list-item>
        </v-list>
      </v-navigation-drawer>

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
const menuOpen = ref(false);
const showSettingDialog = ref(false);

onMounted(() => {
  var defaultTheme = nuxtStorage.localStorage.getData("theme");
  theme.global.name.value = defaultTheme ?? "dark";
});

const toggleMenu = () => {
  menuOpen.value = !menuOpen.value;
}

function isDark(): boolean {
  const last4Letters = theme.global.name.value.substring(theme.global.name.value.length - 4).toLowerCase();
  return last4Letters === "dark";
}



function toggleTheme(){
  let changed: boolean = false;
  if(theme.global.name.value === "light"){
    theme.global.name.value = "dark";
    changed = true;
  }
  else if(theme.global.name.value === "dark") {
    theme.global.name.value = "light";
    changed = true;
  }
  
  if(!changed){
    const darkMode: boolean = isDark();
    let themeName: string = theme.global.name.value;
    if(darkMode){
      themeName = themeName.substring(0, themeName.length - 4);
      theme.global.name.value = themeName + "Light";
    }
    else {
      themeName = themeName.substring(0, themeName.length - 5);
      theme.global.name.value = themeName + "Dark";
    }
  }

  nuxtStorage.localStorage.setData("theme", theme.global.name.value);  
}
</script>

<style scoped>
.rotate {
  transform: rotate(90deg);
}
</style>
