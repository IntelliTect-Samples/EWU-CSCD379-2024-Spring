<template>
  <v-dialog v-model="showModel" max-width="350">
    <v-card>
      <v-sheet color="secondary">
        <v-card-title>Enter your name to play:</v-card-title>
      </v-sheet>
      <v-responsive hide-details="auto" class="mx-auto" width="350">
        <v-text-field label="Name" v-model="nameModel"></v-text-field>
      </v-responsive>
      <v-btn @click="showModel = !showModel">Submit</v-btn>
    </v-card>
  </v-dialog>
</template>

<script setup lang="ts">
const showModel = defineModel<boolean>('show');
const nameModel = defineModel<string>('name');

// Vue throwing error when removing component before unmount
// onMounted(() => {
//   window.addEventListener('keyup', onKeyup);
// });

// onUnmounted(() => {
//   window.removeEventListener('keyup', onKeyup);
// });

// function onKeyup(event: KeyboardEvent) {
//   if (showModel.value && event.key === 'Enter') {
//     showModel.value = false;
//   }
// }
</script>
