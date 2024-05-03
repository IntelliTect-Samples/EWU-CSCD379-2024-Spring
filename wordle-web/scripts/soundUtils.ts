export function playClickSound(): void {
    if (process.client) {
      const audio = new Audio("/click.mp3");
      audio.volume = 0.9;
      audio.play();
    }
  }
  
  export function playWinSound(): void {
    if (process.client) {
      const audio = new Audio("/won.mp3");
      audio.volume = 0.9;
      audio.play();
    }
  }
  
  export function playLoseSound(): void {
    if (process.client) {
      const audio = new Audio("/lose.mp3");
      audio.volume = 0.9;
      audio.play();
    }
  }
  
  export function playEnterSound(): void {
    if (process.client) {
      const audio = new Audio("/success.mp3");
      audio.volume = 0.9;
      audio.play();
    }
  }