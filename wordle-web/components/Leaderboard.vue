<template>
    <v-container>
        <v-simple-table>
            <template v-slot:default>
                <thead>
                    <tr>
                        <th class="text-left">Name</th>
                        <th class="text-left">Games Played</th>
                        <th class="text-left">Average Attempts</th>
                    </tr>
                </thead>
                <tbody>
                    <tr v-for="item in scores" :key="item.id">
                        <td>{{ item.name }}</td>
                        <td>{{ item.gameCount }}</td>
                        <td>{{ item.averageAttempts }}</td>
                    </tr>
                </tbody>
            </template>
        </v-simple-table>
    </v-container>
</template>

<script>
import axios from 'axios';

export default {
  data() {
    return {
      scores: []
    };
  },
  mounted() {
    this.fetchScores();
  },
  methods: {
    async fetchScores() {
      try {
        const response = await axios.get('http://localhost:5000/leaderboard');
        this.scores = response.data;
      } catch (error) {
        console.error("There was an error fetching the scores:", error);
      }
    }
  }
}
</script>
