export interface WordDate {
	wordDateId: number;
	date: string;
	gameCount: number;
	averageAttempts: number;
	averageSeconds: number;
    playerList: Array<string>;
}
