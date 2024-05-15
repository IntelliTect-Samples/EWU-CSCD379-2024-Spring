<template>
  <v-table class="table mt-7 mx-auto w-75">
    <thead>
      <tr>
        <th class="text-h6 text-center Name"><strong>Player Name</strong></th>
        <th class="text-h6 text-center GameCount">
          <strong>Game Count</strong>
        </th>
        <th class="text-center text-h6 AverageAttempts">
          <strong>Average Guesses</strong>
        </th>
      </tr>
    </thead>
    <tbody>
      <tr v-for="index in 10" :key="index" @click="$router.push('/')">
        <td class="text-center">1</td>
        <td class="text-center">hi</td>
        <td class="text-center">hi</td>
      </tr>
    </tbody>
  </v-table>
</template>
