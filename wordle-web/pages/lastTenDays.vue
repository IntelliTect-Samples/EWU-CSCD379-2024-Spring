<template>
  <div>
    <h1>Game Statistics</h1>
    <div v-for="(stats, index) in gameStats" :key="index" class="stats-card">
      <h2>Word: {{ stats.word }}</h2>
      <p>Average Guesses: {{ stats.averageGuesses }}</p>
      <p>Total Times Played: {{ stats.totalTimesPlayed }}</p>
      <p>Total Wins: {{ stats.totalWins }}</p>
      <p>Total Losses: {{ stats.totalLosses }}</p>
    </div>
  </div>
</template>

<script>
export default {
  data() {
    return {
      gameStats: [
        {
          word: "ExampleWord1",
          averageGuesses: 4.5,
          totalTimesPlayed: 20,
          totalWins: 15,
          totalLosses: 5
        },
        {
          word: "ExampleWord2",
          averageGuesses: 3.2,
          totalTimesPlayed: 25,
          totalWins: 18,
          totalLosses: 7
        },
        // Add more instances of GameStatsDto here...
      ]
    };
  }
};
</script>

<style scoped>
.stats-card {
  border: 1px solid #ccc;
  padding: 10px;
  margin-bottom: 10px;
}
</style>

