<template>
  <NuxtLayout>
  
    <v-app>
      <v-app-bar color="primary" :elevation="2">
        <v-app-bar-title @click="router.push('/')">
          Wordle Web
          <v-icon @click="router.push('/')">
            mdi-lightbulb-on-outline
          </v-icon>
        </v-app-bar-title>
      </v-app-bar>

      <HelpDialog v-model="showHelpDialog" />

      <v-navigation-drawer expand-on-hover rail location="right">
        <v-list>
          <v-list-item
            prepend-avatar="https://i.ibb.co/kx64H0R/Picture1.jpg"
            subtitle="Webdev"
            title="Cynthia"
          ></v-list-item>
          <v-list-item
            prepend-avatar="https://i.ibb.co/nfJtk1n/Picture2.jpg"
            subtitle="Webdev"
            title="Hadi"
          ></v-list-item>
        </v-list>

        <v-divider></v-divider>
        <v-list density="compact" nav>
          <v-list-item prepend-icon="mdi-home" title="Home" @click="router.push('/')"/>
          <v-list-item prepend-icon="mdi-cog-outline" title="Settings" @click="settingsDialog = true"/>
          <v-list-item prepend-icon="mdi-help-circle" title="About" @click="router.push('/aboutPage')"/>
          <v-list-item prepend-icon="mdi-weather-night" title="Light vs Dark"@click="toggleTheme()"/>
          <v-list-item  prepend-icon="mdi-help" title="Help" @click="showHelpDialog = true" />
        </v-list>
      </v-navigation-drawer>
      
      <!-- Settings Dialog -->
      <v-dialog v-model="settingsDialog" max-width="500">
        <v-card>
          <v-sheet color="primary">
            <v-card-text style="text-align: center; font-size:1.75em; font-family:'Courier New'"> Settings </v-card-text>
          </v-sheet>
          <v-card-text>
            <v-container>
              <v-btn class="buttonClass" @click="themeSettings('light')">Light Mode</v-btn>
              &nbsp;&nbsp;&nbsp;
              <v-btn class="buttonClass" @click="themeSettings('dark')">Dark Mode</v-btn>
              &nbsp;&nbsp;&nbsp;
              <v-btn class="buttonClass" @click="themeSettings('bCasual')">Business Casual</v-btn>
              &nbsp;&nbsp;&nbsp;
              <v-btn class="buttonClass" @click="themeSettings('hillBilly')">Hill Billy</v-btn>
              &nbsp;&nbsp;&nbsp;
              <v-btn class="buttonClass" @click="themeSettings('hadi')">Hadi's Choice</v-btn>
            </v-container>
          </v-card-text>
        </v-card>
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
const settingsDialog = ref(false);
const wordEngineDialog = ref(false);

onMounted(() => {
  var defaultTheme = nuxtStorage.localStorage.getData("theme");
  theme.global.name.value = defaultTheme ?? "dark";
});

function toggleTheme() {
  theme.global.name.value = theme.global.name.value === "light" ? "dark" : "light";
  nuxtStorage.localStorage.setData("theme", theme.global.name.value);
}

function themeSettings(item: string) {
  theme.global.name.value = item;
  nuxtStorage.localStorage.setData("themes", theme.global.name.value);
}


</script>
<style>
.buttonClass{
  display: flex;
  justify-content: center;
  border: 2px;
  margin-bottom: 10px;
}
</style>
