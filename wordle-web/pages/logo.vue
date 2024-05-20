<template>
  <div>
    
    
  </div>
  <v-container class="d-flex justify-center align-center">
    <v-img 
      src="../public/HillBiddle1.png"
      alt="Logo"
      :height="imageHeight"
      :width="imageWidth"
    />
  </v-container>
</template>

<script lang="ts" setup>

import { useDisplay } from "vuetify";
const display = useDisplay();
const imageHeight = ref(625);
const imageWidth = ref(1800);
const cardWidth = ref(1200);
</script>

<style></style>
