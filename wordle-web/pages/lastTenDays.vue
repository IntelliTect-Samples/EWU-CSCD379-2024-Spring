<template>
  <v-container class="game-container" fluid>
  <div>
    <div class="center-div">
      <div class="text-h3 ma-5 font-weight-bold text-primary">Last Ten Days</div>
    </div>
    <div class="data-list">
      <div v-for="item in data" :key="item.date" class="data-item">
        <div class="data-date">{{ formatDate(item.date) }}</div>
        <div class="data-details">
          <div class="data-detail">
            <span class="detail-label">Average Guesses:</span>
            <span>{{ item.averageGuesses }}</span>
          </div>
          <div class="data-detail">
            <span class="detail-label">Average Seconds:</span>
            <span>{{ item.averageSeconds }}</span>
          </div>
          <div class="data-detail">
            <span class="detail-label">Total Wins:</span>
            <span>{{ item.totalWins }}</span>
          </div>
          <div class="data-detail">
            <span class="detail-label">Total Losses:</span>
            <span>{{ item.totalLosses }}</span>
          </div>
        </div>
      </div>
    </div>
  </div>
  </v-container>
</template>

<script setup lang="ts">
import Axios from 'axios';
import { ref, onMounted } from 'vue';
import { format } from "date-fns";

const data = ref([]);

onMounted(async () => {
  try {
    const formatDate = format(new Date(), "MM-dd-yyyy");
    const response = await Axios.get(`Game/LastTenWordStats/${formatDate}`);
    data.value = response.data;
  } catch (error) {
    console.error('Error fetching data:', error);
  }
});

const formatDate = (date) => {
  return format(new Date(date), "MMMM d, yyyy");
};
</script>

<style scoped>
.data-list {
  list-style-type: none;
  padding: 0;
}

.center-div {
  display: flex;
  justify-content: center;
}

.data-item {
  border: 1px solid #ccc;
  border-radius: 5px;
  margin-bottom: 20px;
  display: inline-block;
  padding: 15px 20px;
}

.data-date {
  font-weight: bold;
  margin-bottom: 10px;
}

.data-details {
  display: flex;
  flex-direction: column;
}

.data-detail {
  display: flex;
  align-items: center;
  justify-content: space-between;
  margin-bottom: 10px;
}

.detail-label {
  font-weight: bold;
  margin-right: 10px;
}

.game-container {
  background-image: url("../public/landingPageImage.jpg");
  background-size: cover;
  background-position: center;
  min-height: 100vh;
}

@media screen and (max-width: 600px){
  .game-container {
    background-size: contain;
  }
}

@media screen and (max-width: 1440px){
  .game-container {
    background-size: cover;
  }
}
</style>

