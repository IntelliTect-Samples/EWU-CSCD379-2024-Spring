<template>
  <div>
<!-- Support deleting a word ❌✅
Support adding a new word ❌✅
Editing words is not supported ❌✅
Duplicate words should not be allowed ❌✅
Add & support changing the common word boolean flag ❌✅
Filter the list of returned words by common words ❌✅
Words should be sorted alphabetically ❌✅ -->
  <v-container>
    <v-card class="pa-3">
      <v-card-title class="font-weight-bold text-center" >Word Editor</v-card-title>
    </v-card>
    <v-card-item>
        <v-row>
          <v-col cols="auto">
            <v-btn color="primary">
              Add Word
            </v-btn>
          </v-col>
          <v-col cols="auto">
          </v-col>
          <v-col cols="auto">
            <v-btn color="primary">
              EXTRA BUTTON FOR NOW
            </v-btn>
          </v-col>
          <v-col cols="auto">
          </v-col>
        </v-row>
    </v-card-item>
  </v-container>


  </div>
</template>

<script lang="ts" setup>

</script>

<style>

</style>