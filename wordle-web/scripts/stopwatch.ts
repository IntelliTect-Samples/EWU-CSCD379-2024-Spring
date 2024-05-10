export class Stopwatch {
  private startTime: number;
  private intervalId: NodeJS.Timeout | null | undefined;

  constructor() {
    this.startTime = 0;
  }

  public start(): void {
    this.intervalId = setInterval(() => {
      this.startTime = this.startTime + 1;
    }, 1000);
  }
  public stop(): void {
    if (this.intervalId) {
      clearInterval(this.intervalId);
      this.intervalId = null;
    }
  }
  public reset(): void {
    this.stop();
    this.startTime = 0;
  }
  public getCurrentTime(): number {
    return this.startTime;
  }
}
