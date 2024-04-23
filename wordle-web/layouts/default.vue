<template>
  <v-app>
    <v-app-bar color="primary">
      <template v-slot:prepend>
        <div class="text-h5 ml-5">
          <v-icon
            color="secondary"
            @click="router.push('/index')"
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
      <v-app-bar-nav-icon @click.stop="showDrawer = !showDrawer" />
    </v-app-bar>
    <v-navigation-drawer v-model="showDrawer" location="right">
      <v-list>
        <v-list-item @click="router.push('/about')">
          <v-list-item-title> About </v-list-item-title>
        </v-list-item>
        <v-divider />
        <v-list-item @click="router.push('/')">
          <v-list-item-title>
            <v-icon>mdi-alpha-w</v-icon>Whurdle
          </v-list-item-title>
        </v-list-item>
        <v-divider />
        <v-list-item @click="showSettingsDialog = true">
          <v-list-item-title>
            <v-icon>mdi-cog</v-icon>
          </v-list-item-title>
        </v-list-item>
      </v-list>
    </v-navigation-drawer>
    <SettingsDialog v-model="showSettingsDialog" />
    <v-main>
      <slot />
    </v-main>
  </v-app>
</template>

<script setup lang="ts">
const router = useRouter();
const showHelpDialog = ref(false);
const showSettingsDialog = ref(false);
const showDrawer = ref(false);
</script>
