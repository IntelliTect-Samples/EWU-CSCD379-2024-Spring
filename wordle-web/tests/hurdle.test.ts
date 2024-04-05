import { expect, test } from "vitest";
import { hurdleInput } from "~/scripts/hurdle";

test("hurdle", () => {
    expect(hurdleInput("n")).toBe("hii");
});