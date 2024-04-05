import { expect, test } from "vitest";
import { Hurdle } from "~/scripts/hurdle";

test("hurdle", () => {
    let hurdle: Hurdle = new Hurdle();
    expect(hurdle.hurdleInput("n")).toBe("hi");
});