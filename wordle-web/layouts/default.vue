<template>
  <!-- <v-app>
    <v-btn to="/">Home</v-btn>
    <v-btn to="/test">Test</v-btn>
    <div>
      <slot />
    </div>
  </v-app> -->
  <v-app>
    <v-app-bar>
      <div class="text-h5 ml-5">
        <v-icon
          :icon="mdiAlphaW"
          @click="router.push('/')"
          class="cursor-pointer"></v-icon>
      </div>
      <v-app-bar-title @click="router.push('/')" class="cursor-pointer">
        Wordle Hurdle
      </v-app-bar-title>

      <v-app-bar-nav-icon id="menu-activator"> </v-app-bar-nav-icon>

      <v-menu activator="#menu-activator">
        <v-list>
          <v-list-item>
            <v-list-item-title>
              <v-icon :icon="mdiCog"></v-icon>
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
import { mdiAlphaW, mdiCog } from '@mdi/js';

const router = useRouter();
</script>
