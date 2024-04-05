import { expect, test } from "vitest";
import { hurdleInput } from "~/scripts/hurdle";

test("hurdle: input 'n'", () => {
    expect(hurdleInput("n")).toBe("Good choice, young hurdler...");
});

test("hurdle: input 'y'", () => {
    expect(hurdleInput("y")).toBe("Haha you fell over!");
});

test("hurdle: input other", () => {
    expect(hurdleInput("other")).toBe("Invalid input. Please try again.");
});