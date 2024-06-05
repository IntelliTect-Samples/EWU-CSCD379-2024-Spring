<template>
  <v-dialog v-model="modelValue" max-width="500">
    <v-card style="background-color: myFunction()" color = "secondary">
      <v-sheet color="primary">
        <v-card-text
          style="text-align: center; font-size: larger"
        >
          <header>
            Sign In
          </header>
        </v-card-text>
      </v-sheet>
      <v-divider />
    </v-card>
  </v-dialog>
</template>

<script setup lang="ts">

const modelValue = defineModel<boolean>({ default: false });

</script>

