export class Game {
	public maxAttempts: number = 6;
	public wordToGuess: string;

	constructor(wordToGuess: string) {
		this.wordToGuess = wordToGuess;
	}
}
