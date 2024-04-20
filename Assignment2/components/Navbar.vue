<template>
	<v-app-bar color="primary" :elevation="2">
        <!-- <template v-slot:prepend >
          <v-icon color="secondary" @click="router.push('/')"> mdi-bookshelf</v-icon>
        </template> -->

        <v-btn icon="mdi-bookshelf" @click="router.push('/')"></v-btn>

        <v-app-bar-title>
          <v-btn @click="router.push('/')">Wordle</v-btn>
        </v-app-bar-title>

        <v-btn @click="toggleDrawer"  icon="mdi-menu"></v-btn>

      </v-app-bar>
      <v-navigation-drawer v-model="drawer"  location="right">
        <v-list>
          <v-list-item @click="router.push('/About')" class="text-center">About</v-list-item>
        </v-list>
      </v-navigation-drawer>
</template>

<script setup lang="ts">
const router = useRouter();

var drawer = ref(false);

function toggleDrawer() {
  drawer.value = !drawer.value;
}

</script>
