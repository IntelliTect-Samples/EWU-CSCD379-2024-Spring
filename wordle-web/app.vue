<template>
  <NuxtLayout>
    <v-app class="background">
      <v-app-bar color="primary" :elevation="2">
        <template v-slot:prepend>
          <v-btn icon @click="router.push('/')">
            <v-icon color="deep-purple">mdi-wizard-hat</v-icon> <!-- Wizard hat icon -->
          </v-btn>
          <v-btn @click="router.push('/')">
            Welcome to LexiQuest
          </v-btn>
        </template>

        <v-btn @click="showLoginDialog = true">
          <v-icon>mdi-lock</v-icon>
          Login
        </v-btn>
        
        <!-- Mute Button -->
        <v-btn icon @click="toggleMute">
          <v-icon>{{ isMuted ? 'mdi-volume-off' : 'mdi-volume-high' }}</v-icon>
        </v-btn>

        <!-- Play Music Button -->
        <v-btn icon @click="playMusic">
          <v-icon>mdi-play-circle</v-icon>
        </v-btn>

        <v-btn icon="mdi-cog" @click="toggleSettingsDrawer"></v-btn>
        <v-btn icon="mdi-help-circle" @click="showHelpDialog = true"></v-btn>
        <v-btn icon="mdi-menu" @click="toggleDrawer"></v-btn>

        <HelpDialog v-model="showHelpDialog" />
      </v-app-bar>

      <!-- Navigation Drawer for the About section -->
      <v-navigation-drawer v-model="drawer" location="right">
        <v-list>
          <v-list-item @click="router.push('/about')" class="text-center">About</v-list-item>
          <v-list-item @click="showHelpDialog = true" class="text-center">Help</v-list-item>
          <v-list-item @click="router.push('/WordEditor')" class="text-center">Word Editor</v-list-item>
          <v-list-item @click="router.push('/DailyWordsHistory')" class="text-center">Archive</v-list-item>
        </v-list>
      </v-navigation-drawer>

      <!-- Navigation Drawer for settings and theme changes -->
      <v-navigation-drawer v-model="settingsDrawer" location="right">
        <v-list>
          <v-list-item class="text-center">Choose Your Theme!</v-list-item>
          <v-list-item @click="setTheme('White')" class="text-center">White Wizard</v-list-item>
          <v-list-item @click="setTheme('Dark')" class="text-center">Dark Mage</v-list-item>
          <v-list-item @click="setTheme('Forest')" class="text-center">Enchanted Forest</v-list-item>
          <v-list-item @click="setTheme('Merlin')" class="text-center">Merlin's Study</v-list-item>
        </v-list>
      </v-navigation-drawer>

      <v-main>
        <v-container class="text-center">
          <NuxtPage />
        </v-container>
      </v-main>

      <!-- Login Dialog -->
      <SigninDialog v-model="showLoginDialog" />

      <!-- Background Music -->
      <audio ref="backgroundMusic" :src="backgroundMusicSrc" loop></audio>
    </v-app>
  </NuxtLayout>
</template>

<script setup lang="ts">
import { useRouter } from 'vue-router';
import { ref, onMounted } from 'vue';
import { useTheme } from 'vuetify/lib/framework.mjs';
import SigninDialog from '@/components/SigninDialog.vue';
import HelpDialog from '@/components/HelpDialog.vue';

const router = useRouter();
const theme = useTheme();
const showHelpDialog = ref(false);
const drawer = ref(false);
const settingsDrawer = ref(false);
const showLoginDialog = ref(false);
const isMuted = ref(false);
const backgroundMusic = ref<HTMLAudioElement | null>(null);

// Import the music file using ES module import syntax
import backgroundMusicSrc from '@/sounds/theme.mp3';

function toggleDrawer() {
  drawer.value = !drawer.value;
}

function toggleSettingsDrawer() {
  settingsDrawer.value = !settingsDrawer.value;
}

function setTheme(themeName: string) {
  theme.global.name.value = themeName;
}

function toggleMute() {
  isMuted.value = !isMuted.value;
  if (backgroundMusic.value) {
    backgroundMusic.value.muted = isMuted.value;
  }
}

function playMusic() {
  if (backgroundMusic.value) {
    backgroundMusic.value.play().catch(error => {
      console.error("Error playing background music:", error);
    });
  }
}

onMounted(() => {
  if (backgroundMusic.value) {
    backgroundMusic.value.muted = isMuted.value;
  }
});
</script>

<style scoped>
.background {
  background-image: url('~/images/background.jpg');
  background-size: cover;
  background-position: center;
  background-repeat: no-repeat;
  min-height: 100vh;
  width: 100%;
  position: fixed;
  top: 0;
  left: 0;
  z-index: -1;
}

.v-application {
  overflow: hidden;
}

.content {
  position: relative;
  z-index: 1; 
}
</style>
