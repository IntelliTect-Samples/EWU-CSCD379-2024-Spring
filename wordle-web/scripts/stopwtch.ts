export class Stopwatch {
  private startTime: number;
  private intervalId: NodeJS.Timeout | null;

  constructor() {
    this.startTime = 0;
  }

  start() {
    this.startTime = 0;
    this.intervalId = setInterval(() => {
      this.startTime = this.startTime + 1;
    }, 1000);
  }
  stop() {
    if (this.intervalId) {
      clearInterval(this.intervalId);
      this.intervalId = null;
    }
  }
  getCurrentTime() {
    return this.startTime;
  }
}
