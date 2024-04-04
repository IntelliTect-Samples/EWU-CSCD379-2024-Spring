import { expect, test } from "vitest";
import { Game } from "~/scripts/game";

test("game", () => {
	const game = new Game("autos");
	expect(game.wordToGuess.length).toBe(5);
});
