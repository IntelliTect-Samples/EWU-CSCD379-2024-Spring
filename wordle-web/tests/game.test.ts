/*import { expect, test } from "vitest";
import checkInput from "..\\pages\\game.vue";

test('input',() =>{
  expect(new checkInput('hill billy')).contain('CORRECT');
});  */

import { expect, test } from "vitest";
import {checkInput} from "../scripts/gamescript"
test("not valid", ()=>{
  expect(checkInput("hill")).toBe("WRONG")
  expect(checkInput("hill billy")).toBe("CORRECT")
}

  )
