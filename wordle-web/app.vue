<template>
  <NuxtLayout>
  
    <v-app>
      <v-app-bar color="primary" :elevation="2">
        
        <template v-slot:prepend>
          <v-icon color="secondary"> mdi-book </v-icon>
        </template>
        <v-app-bar-title @click="router.push('/')">
          Wordle Web
          <v-icon @click="router.push('/')">
            mdi-lightbulb-on-outline
          </v-icon>
        </v-app-bar-title>
        <v-btn icon="mdi-weather-night" @click="toggleTheme()" />
      </v-app-bar>
      
      <v-navigation-drawer expand-on-hover rail>
        <v-list>
          <v-list-item
            prepend-avatar="https://randomuser.me/api/portraits/women/86.jpg"
            subtitle="Webdev"
            title="Cynthia"
          ></v-list-item>
          <v-list-item
            prepend-avatar="https://randomuser.me/api/portraits/men/88.jpg"
            subtitle="Webdev"
            title="Hadi"
          ></v-list-item>
        </v-list>

        <v-divider></v-divider>

        <v-list density="compact" nav>
          <v-list-item prepend-icon="mdi-home" title="Home" @click="router.push('/')"></v-list-item>
          <v-list-item prepend-icon="mdi-cog-outline" title="Settings" @click="router.push('/openSettings')"></v-list-item>
          <v-list-item prepend-icon="mdi-help-circle" title="About" @click="showHelpDialog = router.push('/aboutPage')"></v-list-item>
        </v-list>
      </v-navigation-drawer>

      <v-dialog v-model="openSettingsDialog">
        <v-card>
        </v-card>
        <v-card-text>
        <v-switch v-model="darkMode" label="Dark Mode"/>
        <v-switch v-model="hillBilly" label="Hill Billy Mode"/>
        <v-switch v-model="bCasual" label="Business Casual"/>
        </v-card-text>

        <v-card-actions>
          <v-btn color="primary" @click="saveSettings">Save</v-btn>
          <v-btn @click="closeSettingsDial()">close</v-btn>
        </v-card-actions>
      </v-dialog>
      
      <v-main>
        <NuxtPage />
      </v-main>
    </v-app>
  </NuxtLayout>
</template>




<script setup lang="ts">
import { useTheme } from "vuetify";
import nuxtStorage from 'nuxt-storage';
import { ref } from "vue";

const router = useRouter();
const theme = useTheme();
const showHelpDialog = ref(false);
var menuOpen= ref(false);
const settings = ref(false);
const darkMode=ref(false);
const selected=ref(null);


const themes= [
  {name: "default", value: "default"},
  {name: "hill Billy", value: "hillBilly"},
  {name: "business Casual", value: "bCasual"}
  {name: "dark", value:"dark"}
]

onMounted(() => {
  var defaultTheme = nuxtStorage.localStorage.getData("theme");
  theme.global.name.value = defaultTheme ?? "dark";
});


  const openSettingsDialog = () => {
  settings.value = true;
}; 

const closeSettingsDialog = () => {
  settings.value = false;
};

const saveSettings = () => {
  nuxtStorage.localStorage.setData("selectedTheme", selected.value);
   closeSettingsDialog();
};

</script>
