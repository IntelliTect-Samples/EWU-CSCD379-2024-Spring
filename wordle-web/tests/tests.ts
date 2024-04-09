import { expect, test } from "vitest";
import checkInput from "..\\pages\\game.vue";

test('input',() =>{
  expect(new checkInput('hill billy')).contain('CORRECT');
});    
