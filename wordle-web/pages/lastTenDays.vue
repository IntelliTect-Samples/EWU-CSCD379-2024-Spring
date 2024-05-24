<template>
    <v-container>
        <v-progress-linear v-if="isDailyWordlesLoading"
                           class="mx-auto"
                           color="primary"
                           height="10"
                           indeterminate
                           rounded
                           width="75%" />
        <div v-else>
            <div class="text-h3 ma-5 font-weight-bold text-primary">
                Last Ten Wordles
            </div>
            <v-spacer />
            <v-row cols="12">
                <v-col v-for="(gameStat, i) in gameStats"
                       :key="i"
                       cols="12"
                       sm="12"
                       md="6"
                       lg="4">
                    <WordleStatsCard :gameStat="gameStat"
                                     :isDaily="true"
                                     :inCurrentGame="false" />
                </v-col>
            </v-row>
        </div>
    </v-container>
</template>

<script setup lang="ts">
    import { ref, onMounted } from 'vue';
    import Axios from 'axios';
    import { format } from 'date-fns';
    import type { GameStatsDto } from '../Wordle.Api/Wordle.Api/Dtos/GameStatsDto';
  
    //const isDailyWordlesLoading = ref(true);
    const stats = ref<GameStatsDto[]>([]);

    onMounted(() => {
        const formatDate = format(new Date(), "MM-dd-yyyy");
        Axios.get(`Game/GetLastTenWordStats/${formatDate}`)
        .then((res: { item: any }) => res.item)
            .then((item: any) =>
                data.map((item: any) => ({
                    word: item.word,
                    date: item.date,
                    averageGuesses: item.averageGuesses,
                    totalTimesPlayed: item.totalTimesPlayed,
                    averageSeconds: item.averageSeconds,
                    totalWins: item.totalWins,
                    totalLosses: item.totalLosses,
                }))
            )
            .then((statData: GameStatsDto[]) => {
                //isDailyWordlesLoading.value = false;
                stats.value = statData;
            });
    });
</script>
