export interface WordDate {
	wordDateId: number;
	date: string;
	gameCount: number;
	averageAttempts: number;
	averageSecondsPerGame: number;
    playerList: Array<string>;
}
