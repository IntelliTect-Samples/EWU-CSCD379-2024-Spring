class SoundUtils {
    playClickSound(): void {
      const audio = new Audio('/click.mp3');
      audio.volume = 0.9;
      audio.play();
    }
    
    playWinSound(): void {
      const audio = new Audio('/won.mp3');
      audio.volume = 0.9;
      audio.play();
    }
  
    playLoseSound(): void {
      const audio = new Audio('/lose.mp3');
      audio.volume = 0.9;
      audio.play();
    }
  
    playEnterSound(): void {
      const audio = new Audio('/success.mp3');
      audio.volume = 0.9;
      audio.play();
    }
  }
  
  export default SoundUtils;