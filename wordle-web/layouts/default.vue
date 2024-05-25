<template>
  <v-app class="landing">
    <v-app-bar color="primary landing">
      <template v-slot:prepend>
        <div class="text-h5 ml-5">
          <v-icon
            color="secondary"
            @click="router.push('/')"
            class="cursor-pointer"
            >mdi-alpha-w</v-icon
          >
        </div>
        <v-app-bar-title @click="router.push('/')" class="cursor-pointer">
          Whurdle
        </v-app-bar-title>
      </template>
      <v-btn icon="mdi-help-circle" @click="showHelpDialog = true" />
      <HelpDialog v-model="showHelpDialog" />
      <v-menu>
        <template v-slot:activator="{ props }">
          <v-btn v-bind="props"> <v-icon>mdi-account</v-icon> </v-btn>
        </template>
        <v-card>
          <v-card-text>
            <v-btn
              v-if="!tokenService.isLoggedIn()"
              @click="showLoginDialog = true"
              class="mb-5"
              flat
              color="primary">
              <v-icon> mdi-lock </v-icon>
              Login
            </v-btn>
            <div v-else>
              {{ tokenService.getUserName() }}
            </div>
          </v-card-text>
        </v-card>
        <HelpDialog v-model="showHelpDialog" />
      </v-menu>
      <v-app-bar-nav-icon @click.stop="showDrawer = !showDrawer" />
    </v-app-bar>
    <v-navigation-drawer v-model="showDrawer" location="right">
      <v-list>
        <v-list-item @click="router.push('/about')">
          <v-list-item-title> About </v-list-item-title>
        </v-list-item>
        <v-divider />
        <v-list-item @click="router.push('/')">
          <v-list-item-title> Landing </v-list-item-title>
        </v-list-item>
        <v-divider />
        <v-list-item @click="router.push('/leaderboard')"
          >Leaderboard</v-list-item
        >
        <v-divider />
        <v-list-item @click="router.push('/instructions')"
          >Instructions</v-list-item
        >
        <v-divider />
        <v-list-item @click="router.push('/randomWordGame')"
          >Random words!</v-list-item
        >
        <v-divider />
        <v-list-item @click="showSettingsDialog = true">
          <v-list-item-title>
            <v-icon>mdi-cog</v-icon>
          </v-list-item-title>
        </v-list-item>
        <v-divider />
        <v-list-item @click="router.push('/wordStatistics')">
          <v-list-item-title> Last Ten Words </v-list-item-title>
        </v-list-item>
        <v-divider />
        <v-list-item @click="router.push('/wordEditor')">
          <v-list-item-title> Word Editor </v-list-item-title>
        </v-list-item>
      </v-list>
    </v-navigation-drawer>
    <SigninDialog v-model="showLoginDialog" />
    <SettingsDialog v-model="showSettingsDialog" />
    <v-main>
      <slot />
    </v-main>
  </v-app>
</template>

<script setup lang="ts">
import TokenService from '~/scripts/tokenService';

const tokenService = new TokenService();
const router = useRouter();
const showHelpDialog = ref(false);
const showSettingsDialog = ref(false);
const showDrawer = ref(false);
const showLoginDialog = ref(false);
</script>

<style>
.v-main {
  background-image: url('../public/edited-vaporwave-landingPage.jpg');
  background-size: cover;
}
</style>
