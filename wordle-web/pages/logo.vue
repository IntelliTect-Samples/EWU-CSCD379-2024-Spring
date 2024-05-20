<template>
 <div class="about-container">
    <div class="d-flex justify-center mt-3 mb-5" >
      <h1 style="font-size: 2em">Howdy, here's our logo.. <br /> we'll be implementing it soon 🌽👨‍🌾</h1>
    </div>
  </div>
  <v-container class="d-flex justify-center align-center">
    <v-img 
      src="../public/HillBiddle1.png"
      alt="Logo"
      :height="imageHeight"
      :width="imageWidth"
    />
  </v-container>
    <div class="d-flex justify-center mt-3 mb-5" >
    <v-btn
      prepend-icon="mdi-home-export-outline"
      @click="router.go(-1)" 
      color="primary"
      >Back</v-btn>
      </div>
      <div class="d-flex justify-center mt-3 mb-5" >
    <v-btn
      prepend-icon="mdi-home-export-outline"
      @click="router.push('/')"
      color="primary"
      >Home</v-btn>
      </div>
</template>

<script lang="ts" setup>
import { useRouter } from 'vue-router';
const router = useRouter();

import { useDisplay } from "vuetify";
const display = useDisplay();
const imageHeight = ref(625);
const imageWidth = ref(1800);
const cardWidth = ref(1200);
</script>

