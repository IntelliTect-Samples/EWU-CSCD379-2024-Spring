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
              <td class="text-center"></td>
              <td class="text-center">DateOfTheWord</td>
              <td class="text-center">Average Plays</td>
              <td class="text-center">Average Score</td>
              <td class="text-center">Average Seconds</td>
            </tr>

            <tr v-for="(row, index) in tableData" :key="index">
            <td class="text-center">{{ index+1 }}</td>
            <td class="text-center">{{ row.date }}</td>
            <td class="text-center">{{ row.averagePlays }}</td>
            <td class="text-center">{{ row.averageScore }}</td>
            <td class="text-center">{{ row.averageSeconds }}</td>
          </tr>
        </tbody>
      </v-table>
      <div class="d-flex justify-center mt-3 mb-5" >
    <v-btn
      prepend-icon="mdi-home-export-outline"
      @click="router.go(-1)" 
      color="secondary"
      >Back</v-btn>
      </div>

      <div class="d-flex justify-center mt-3 mb-5" >
    <v-btn
      prepend-icon="mdi-home-export-outline"
      @click="router.push('/')"
      color="secondary"
      >Home</v-btn>
      </div>
    </v-card>
  </div>
</template>

<script setup lang="ts">
const router = useRouter();
//fake data 
const tableData = ref([
  { date: '2024-05-01', averagePlays: 24, averageScore: 80, averageSeconds: 30 },
  { date: '2024-05-02', averagePlays: 35, averageScore: 75, averageSeconds: 35 },
  { date: '2024-05-03', averagePlays: 20, averageScore: 78, averageSeconds: 32 },
  { date: '2024-05-04', averagePlays: 2, averageScore: 85, averageSeconds: 28 },
  { date: '2024-05-05', averagePlays: 13, averageScore: 72, averageSeconds: 40 },
  { date: '2024-05-06', averagePlays: 33, averageScore: 70, averageSeconds: 38 },
  { date: '2024-05-06', averagePlays: 33, averageScore: 70, averageSeconds: 38 },
  { date: '2024-05-06', averagePlays: 33, averageScore: 70, averageSeconds: 38 },
  { date: '2024-05-06', averagePlays: 33, averageScore: 70, averageSeconds: 38 },
  { date: '2024-05-06', averagePlays: 33, averageScore: 70, averageSeconds: 38 },

])
</script>