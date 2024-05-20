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

</script>

<style scoped>
.stats-card {
  border: 1px solid #ccc;
  padding: 10px;
  margin-bottom: 10px;
}
</style>

