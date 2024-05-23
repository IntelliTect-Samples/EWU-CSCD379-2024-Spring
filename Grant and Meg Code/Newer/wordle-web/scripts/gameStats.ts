export class GameStats {
  word: string = "";
  averageGuesses: number = 0;
  totalTimesPlayed: number = 0;
  totalWins: number = 0;
  totalLosses: number = 0;

  get winPercentage() {
    return ((this.totalWins / this.totalTimesPlayed) * 100).toFixed(0);
  }

  public averageGuessesPercent(maxAttempts: number) {
    return this.averageGuesses / maxAttempts * 100
  }
}
