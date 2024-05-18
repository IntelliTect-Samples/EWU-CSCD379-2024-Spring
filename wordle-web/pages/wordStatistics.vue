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
        <th class="text-center text-h6">
          <strong>Average seconds taken</strong>
        </th>
      </tr>
    </thead>
    <tbody>
      <tr
        class="stat cursor-pointer"
        v-for="(wordStatsDto, index) in lastTenWords"
        :key="index"
        @click="
          $router.push(`/selectedWordGame?date=${wordStatsDto.date.toString()}`)
        ">
        <td class="text-center">{{ wordStatsDto.date }}</td>
        <td class="text-center">{{ wordStatsDto.numberOfPlays }}</td>
        <td class="text-center">
          {{
            wordStatsDto.averageScore === -1 ? 'N/A' : wordStatsDto.averageScore
          }}
        </td>
        <td class="text-center">
          {{
            wordStatsDto.averageSeconds === -1
              ? 'N/A'
              : wordStatsDto.averageSeconds + 's'
          }}
        </td>
      </tr>
    </tbody>
  </v-table>
</template>

<script setup lang="ts">
import Axios from 'axios';
import { useTheme } from 'vuetify';

const theme = useTheme();
interface WordStatsDto {
  date: Date;
  numberOfPlays: number;
  averageScore: number;
  averageSeconds: number;
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

<style scoped>
tr.stat:hover {
  background-color: v-bind('theme.global.current.value.colors.primary');
}
</style>
