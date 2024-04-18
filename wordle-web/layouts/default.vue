<template>
  <v-app>
    <v-app-bar color="primary">
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
      <v-app-bar-nav-icon id="menu-activator"> </v-app-bar-nav-icon>
      <v-menu activator="#menu-activator">
        <v-list>
          <v-list-item @click="router.push('/about')">
            <v-list-item-title> About </v-list-item-title>
          </v-list-item>
          <v-list-item>
            <v-list-item-title>
              <v-icon>mdi-cog</v-icon>
            </v-list-item-title>
          </v-list-item>
        </v-list>
      </v-menu>
    </v-app-bar>
    <v-main>
      <slot />
    </v-main>
  </v-app>
</template>

<script setup lang="ts">
const router = useRouter();
const showDrawer = ref(false);
const showHelpDialog = ref(false);
</script>
