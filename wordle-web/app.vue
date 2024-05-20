<template>
  <NuxtLayout>
    <v-app>
      <v-app-bar color="primary" :elevation="2">
        <v-app-bar-title @click="router.push('/')" style="cursor: pointer">
          HillBiddle
          <v-icon @click="router.push('/')"> mdi-greenhouse </v-icon>
        </v-app-bar-title>
        
      </v-app-bar>
        
      <HelpDialog v-model="showHelpDialog" />

      <v-navigation-drawer expand-on-hover rail location="right">
        <v-list class = "bannerSmall" >
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
          <v-list-item
            prepend-icon="mdi-home"
            title="Home"
            @click="router.push('/')"
          />
          <v-list-item
            prepend-icon="mdi-halloween"
            title="Instructions"
            @click="router.push('/Instructions')"
          />
          <v-list-item
            prepend-icon="mdi-bat"
            title="Random Word Wordle"
            @click="router.push('/randomWordGame')"
          />
          <v-list-item
            prepend-icon="mdi-sword-cross"
            title="Word Of The Day Wordle"
            @click="router.push('/wordOfTheDay')"
          />
          <v-list-item
            prepend-icon="mdi-cog-outline"
            title="Settings"
            @click="settingsDialog = true"
          />

          <v-list-item
            prepend-icon="mdi-trophy"
            title="Leaderboard"
            @click="router.push('/leaderboard')"
          />
          <v-list-item
            prepend-icon="mdi-periodic-table"
            title="Statistics"
            @click="router.push('/statistics')"
          />
          <v-list-item
            prepend-icon="mdi-help"
            title="Help"
            @click="showHelpDialog = true"
          />
          <v-list-item
            prepend-icon="mdi-ufo"
            title="LOGO"
            @click="router.push('/logo')"
          />
          <v-list-item
            prepend-icon="mdi-help-circle"
            title="About"
            @click="router.push('/aboutPage')"
          />
          
        </v-list>
      </v-navigation-drawer>
      
      <!-- Settings Dialog -->
      <v-dialog v-model="settingsDialog" max-width="500">
        <v-card style="outline-style: inset" color="primary">
          <v-sheet color="secondary">
            <v-card-text
              style="
                text-align: center;
                font-size: 1.75em;
                font-family: 'Courier New';
              "
            >
              Settings
            </v-card-text>
          </v-sheet>
          <v-card-text>
            <v-container>
              <v-btn
                class="buttonClass"
                @click="themeSettings('light')"
                style="outline-style: outset"
                color="primary"
                >Light Mode</v-btn
              >
              &nbsp;&nbsp;&nbsp;
              <v-btn
                class="buttonClass"
                @click="themeSettings('dark')"
                style="outline-style: outset"
                color="primary"
                >Dark Mode</v-btn
              >
              &nbsp;&nbsp;&nbsp;
              <v-btn
                class="buttonClass"
                @click="themeSettings('bCasual')"
                style="outline-style: outset"
                color="primary"
                >Business Casual</v-btn
              >
              &nbsp;&nbsp;&nbsp;
              <v-btn
                class="buttonClass"
                @click="themeSettings('bCasualDark')"
                style="outline-style: outset"
                color="primary"
                >Business Casual -- DARK</v-btn
              >
              &nbsp;&nbsp;&nbsp;
              <v-btn
                class="buttonClass"
                @click="themeSettings('hillBilly')"
                style="outline-style: outset"
                color="primary"
                >Luigi</v-btn
              >
              &nbsp;&nbsp;&nbsp;
              <v-btn
                class="buttonClass"
                @click="themeSettings('hillBillyDark')"
                style="outline-style: outset"
                color="primary"
                >Mario</v-btn
              >
              &nbsp;&nbsp;&nbsp;
              <v-btn
                class="buttonClass"
                @click="themeSettings('hadi')"
                style="outline-style: outset"
                color="primary"
                >Hadi's Choice</v-btn
              >
              &nbsp;&nbsp;&nbsp;
              <v-btn
                class="buttonClass"
                @click="themeSettings('hadiDark')"
                style="outline-style: outset"
                color="primary"
                >Hadi's Choice -- DARK</v-btn
              >
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
import nuxtStorage from "nuxt-storage";
import { ref } from "vue";
import { useRouter } from "vue-router";

const dialogBox = ref<boolean>(true);
const usersNameInput = ref<string>("");
const router = useRouter();
const theme = useTheme();
const showHelpDialog = ref(false);
const settingsDialog = ref(false);

onMounted(() => {
  var defaultTheme = nuxtStorage.localStorage.getData("theme");
  theme.global.name.value = defaultTheme ?? "dark";
});

function toggleTheme() {
  theme.global.name.value =
    theme.global.name.value === "light" ? "dark" : "light";
  nuxtStorage.localStorage.setData("theme", theme.global.name.value);
}

function themeSettings(item: string) {
  theme.global.name.value = item;
  nuxtStorage.localStorage.setData("themes", theme.global.name.value);
}
</script>

<style>
.buttonClass {
  display: flex;
  justify-content: center;
  border: 2px;
  margin-bottom: 10px;
}
/*<v-img class = "banner" 
src="../public/HillBiddle1.png"
alt="Logo"
max-width="180"
max-height="95"

/>*/ 
</style>

