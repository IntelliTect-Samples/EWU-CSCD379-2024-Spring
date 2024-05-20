<template>
  <div>
  <v-card class="mx-auto w-75" color="primary">
    <v-sheet >
      <h1 style="font-size: 2em"class="text-center">Statistics Board</h1>
  </v-sheet>
 
  <v-card-text style="font-size: 1em"class="text-center">
    These are the stats for the word of the day from the past 10 days:
  </v-card-text>
  <v-table>
          <tbody>
            <tr>
              <td class="text-center">Average Plays</td>
              <td class="text-center">Average Score</td>
              <td class="text-center">Average Seconds</td>
            </tr>
          </tbody>
  </v-table>
 
</v-card>
  </div>
</template>

<script lang="ts" setup>

</script>

<style>

</style>