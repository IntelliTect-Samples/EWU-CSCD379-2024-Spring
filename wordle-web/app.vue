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

      <v-dialog v-model="dialogBox" max-width="500" persistent>
        <v-card>
          <v-sheet color="primary">
            <v-card-text>UserName: </v-card-text>
          </v-sheet>
          <v-form class="mx-3 mt-5">
            <v-text-field @keyup.stop v-model="usersNameInput" label="user" variant="outlined" clearable required>
              </v-text-field>
          </v-form>
          <v-card-actions class="mx-4 mb-3">
            <v-spacer></v-spacer>
            <v-btn color="success" @click="saveUserName"> PRESS HERE TO SAVE</v-btn>
          </v-card-actions>
        </v-card>
      </v-dialog>

    >
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
          <v-list-item  prepend-icon="mdi-trophy" title="LEADERBOARD" @click="router.push('/leaderboard')" />
        </v-list>
      </v-navigation-drawer>
      
      <!-- Settings Dialog -->
      <v-dialog v-model="settingsDialog" max-width="500">
        <v-card style="outline-style: inset;" color="primary">
          <v-sheet color="secondary">
            <v-card-text style="text-align: center; font-size:1.75em; font-family:'Courier New'"> Settings </v-card-text>
          </v-sheet>
          <v-card-text>
            <v-container>
              <v-btn class="buttonClass" @click="themeSettings('light')" style="outline-style: outset;" color="primary">Light Mode</v-btn>
              &nbsp;&nbsp;&nbsp;
              <v-btn class="buttonClass" @click="themeSettings('dark')" style="outline-style: outset;" color="primary">Dark Mode</v-btn>
              &nbsp;&nbsp;&nbsp;
              <v-btn class="buttonClass" @click="themeSettings('bCasual')" style="outline-style: outset;" color="primary">Business Casual</v-btn>
              &nbsp;&nbsp;&nbsp;
              <v-btn class="buttonClass" @click="themeSettings('bCasualDark')" style="outline-style: outset;" color="primary">Business Casual -- DARK</v-btn>
              &nbsp;&nbsp;&nbsp;
              <v-btn class="buttonClass" @click="themeSettings('hillBilly')" style="outline-style: outset;" color="primary">Luigi</v-btn>
              &nbsp;&nbsp;&nbsp;
              <v-btn class="buttonClass" @click="themeSettings('hillBillyDark')" style="outline-style: outset;" color="primary">Mario</v-btn>
              &nbsp;&nbsp;&nbsp;
              <v-btn class="buttonClass" @click="themeSettings('hadi')" style="outline-style: outset;" color="primary">Hadi's Choice</v-btn>
              &nbsp;&nbsp;&nbsp;
              <v-btn class="buttonClass" @click="themeSettings('hadiDark')" style="outline-style: outset;" color="primary">Hadi's Choice -- DARK</v-btn>
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
import { useRouter } from "vue-router";

const dialogBox = ref<boolean>(true);
const usersNameInput = ref<string>('');
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

function showUser(){
  const userName = usersNameInput.value.trim();
}

function saveUserName() {
  if (dialogBox.value) { 
    const userName = usersNameInput.value.trim();
    if (userName !== '') {
      nuxtStorage.localStorage.setData("userName", userName);
      dialogBox.value = false;
    } 
  }
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
