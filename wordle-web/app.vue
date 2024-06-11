<template>
  <NuxtLayout>
    <v-app>
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
        
        <v-btn icon="mdi-cog" @click="toggleSettingsDrawer"></v-btn>
        <v-btn icon="mdi-help-circle" @click="showHelpDialog = true"></v-btn>
        <v-btn icon="mdi-menu" @click="toggleDrawer"></v-btn>

        <HelpDialog v-model="showHelpDialog" />
      </v-app-bar>

      <!-- Navigation Drawer for the About section -->
      <v-navigation-drawer v-model="drawer" location="right">
        <v-list>
          <v-list-item @click="router.push('/about')" class="text-center">About</v-list-item>
          <v-list-item @click="router.push('/WordEditor')" class="text-center">Word Editor</v-list-item>
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
          <v-row>
            <v-col cols="12">
              <v-img
                src="/images/lexiquest_background.jpg"
                alt="Animated spell casting"
                max-height="200"
              />
            </v-col>
          </v-row>
          <NuxtPage />
        </v-container>
      </v-main>

      <!-- Login Dialog -->
      <SigninDialog v-model="showLoginDialog" />
    </v-app>
  </NuxtLayout>
</template>

<script setup lang="ts">
import { useRouter } from 'vue-router';
import { ref } from 'vue';
import { useTheme } from 'vuetify/lib/framework.mjs';
import SigninDialog from '@/components/SigninDialog.vue'; // Adjust the path as necessary

const router = useRouter();
const theme = useTheme();
const showHelpDialog = ref(false);
const drawer = ref(false);
const settingsDrawer = ref(false);
const showLoginDialog = ref(false);

function toggleDrawer() {
  drawer.value = !drawer.value;
}

function toggleSettingsDrawer() {
  settingsDrawer.value = !settingsDrawer.value;
}

function setTheme(themeName: string) {
  theme.global.name.value = themeName;
}
</script>
