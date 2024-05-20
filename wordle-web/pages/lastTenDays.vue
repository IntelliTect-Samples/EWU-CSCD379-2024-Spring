<template>
  <container class="game-container" fluid>
    <div id="statsContainer"></div>
  </container>
</template>

<script setup lang="ts">
import Axios from "axios"
  // Function to generate HTML for each day
  function generateStatsHTML(data) {
    let html = '';
    data.forEach(day => {
      html += `
        <div class="stats-card">
          <h3>${day.date}</h3>
          <p>Total Times Played: ${day.totalTimesPlayed}</p>
          <p>Total Wins: ${day.totalWins}</p>
          <p>Total Losses: ${day.totalLosses}</p>
        </div>
      `;
    });
    return html;
  }

  // Get container element
  const statsContainer = document.getElementById('statsContainer');

  // Make API call using Axios
  const date = '5-20-2024'; // Or use any other date
  Axios.get(`Game/LastTenWordStats/${date}`)
    .then(response => {
      const data = response.data;
      // Generate and append HTML to container
      statsContainer.innerHTML = generateStatsHTML(data);
    })
    .catch(error => {
      console.error('Error fetching data:', error);
    });
</script>

<style>
  .stats-card {
    border: 1px solid #ccc;
    padding: 10px;
    margin-bottom: 10px;
  }

  .game-container {
  background-image: url("../public/landingPageImage.jpg");
  background-size: cover;
  background-position: center;
  min-height: 100vh;
}
</style>
