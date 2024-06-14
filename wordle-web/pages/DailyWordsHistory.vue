<template>
  <v-container>
    <v-card class="mx-auto mt-12 w-75 pa-8 rounded text-center" elevation="12">
      <v-card-title class="text-wrap" style="color: #E0E0E0;">
        Last 10 Daily Words
      </v-card-title>
      <v-data-table
        :headers="headers"
        :items="dailyWordsStats"
        class="elevation-1"
      >
        <template v-slot:item.userHasPlayed="{ item }">
          <v-icon :color="item.userHasPlayed ? 'green' : 'red'">
            {{ item.userHasPlayed ? 'mdi-check-circle' : 'mdi-close-circle' }}
          </v-icon>
        </template>
        <template v-slot:item.action="{ item }">
          <v-btn @click="handleRowClick(item)">Go to Word</v-btn>
        </template>
      </v-data-table>
    </v-card>
  </v-container>
</template>

<script setup lang="ts">
import { ref, onMounted } from 'vue';
import Axios from 'axios';
import { useRouter } from 'vue-router';

interface WordStats {
  date: string;
  numberOfPlays: number;
  averageScore: number;
  averageTime: number;
  userHasPlayed: boolean;
}

const dailyWordsStats = ref<WordStats[]>([]);
const router = useRouter();

const headers = ref([
  { text: 'Date', value: 'date' },
  { text: 'Number of Plays', value: 'numberOfPlays' },
  { text: 'Average Score', value: 'averageScore' },
  { text: 'Average Time (seconds)', value: 'averageTime' },
  { text: 'User Has Played', value: 'userHasPlayed' },
  { text: 'Action', value: 'action', sortable: false }
]);

async function fetchDailyWordsStats() {
  const currentDate = new Date();
  const promises: Promise<WordStats | null>[] = [];

  for (let i = 0; i < 10; i++) {
    const date = new Date(currentDate);
    date.setDate(date.getDate() - i);

    const dateString = date.toISOString().split('T')[0];
    promises.push(fetchWordStatsForDate(dateString));
  }

  const results = await Promise.all(promises);
  dailyWordsStats.value = results.filter((result): result is WordStats => result !== null);
}

async function fetchWordStatsForDate(date: string): Promise<WordStats | null> {
  try {
    const response = await Axios.get(`/leaderboard/GetDailyStats/${date}`);
    const stats = response.data;

    return {
      date: date,
      numberOfPlays: stats.numberOfPlays,
      averageScore: stats.averageScore,
      averageTime: stats.averageSecondsPerGame,
      userHasPlayed: stats.userHasPlayed
    };
  } catch (error) {
    console.error(`Failed to fetch stats for ${date}:`, error);
    return null;
  }
}

function handleRowClick(item: WordStats) {
  if (item && item.date) {
    console.log('Navigating to game for date:', item.date);
    router.push({ path: `/word/${item.date}` });
  } else {
    console.error('Item or date is undefined:', item);
  }
}

onMounted(() => {
  fetchDailyWordsStats();
});
</script>

<style scoped>
.text-wrap {
  white-space: pre-wrap;
}

/* Media queries for responsiveness */
@media (max-width: 1200px) {
  .v-card {
    padding: 10px;
  }
}

@media (max-width: 768px) {
  .v-card {
    padding: 5px;
  }

  .v-card-title {
    font-size: 1.2em;
  }

  .v-btn {
    margin: 5px 0;
  }
}

@media (max-width: 425px) {
  .v-card {
    padding: 2px;
  }

  .v-card-title {
    font-size: 1em;
  }

  .v-btn {
    margin: 3px 0;
  }

  .v-icon {
    font-size: 20px;
  }
}
</style>
