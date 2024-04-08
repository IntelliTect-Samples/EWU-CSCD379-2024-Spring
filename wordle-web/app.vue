<template>
  <NuxtLayout>
    <v-app >
      <v-container>
        <v-btn variant ="text" @click="router.push('/')">Home</v-btn> 
        <v-btn variant ="text"@click="router.push('/game')">Pentagram</v-btn>
      </v-container>
        <NuxtPage />
    </v-app>
  </NuxtLayout>
</template>

<script setup lang="ts">
const router = useRouter()

</script>

