<template>
  <v-table class="table mt-7 mx-auto w-75">
    <thead>
      <tr>
        <th class="text-h6 text-center"><strong>Date</strong></th>
        <th class="text-h6 text-center">
          <strong># of plays</strong>
        </th>
        <th class="text-center text-h6">
          <strong>Average score</strong>
        </th>
      </tr>
    </thead>
    <tbody>
      <tr v-for="(wordStatsDto, index) in lastTenWords" :key="index">
        <td class="text-center">{{ wordStatsDto.date }}</td>
        <td class="text-center">{{ wordStatsDto.numberOfPlays }}</td>
        <td class="text-center">{{ wordStatsDto.averageScore }}</td>
      </tr>
    </tbody>
  </v-table>
</template>

<script setup lang="ts">
import Axios from 'axios';

interface WordStatsDto {
  date: Date;
  numberOfPlays: number;
  averageScore: number;
}
const lastTenWords = ref<WordStatsDto[]>();
try {
  const gameUrl = 'game/lastTenWords';
  const response = await Axios.get(gameUrl);
  lastTenWords.value = response.data;
} catch (error) {
  console.error('Error fetching word of the day:', error);
}
</script>
