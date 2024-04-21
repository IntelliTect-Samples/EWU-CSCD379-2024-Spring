import { describe, it, test, expect } from 'vitest';
import { myWordList } from '~/scripts/wordList';
import { ValidWordsUtils } from '~/scripts/validWordsUtils';

test('validWords', () => {
  expect('a'.charCodeAt(0)).toBe(97);
});

// describe("wordList", () => {
//     it("should have a list of 1 letter", () => {
//         const testList = WordList.validateWord("a");
//         testList.forEach((word) => {
//             expect(word[0]).toBe("a");
//         })
//     })
//     it("should have a list of 2 letters", () => {
//         const testList = WordList.validateWord("at");
//         testList.forEach((word) => {
//             expect(word[0]).toBe("a");
//             expect(word[1]).toBe("t");
//         })
//     })
//     it("should have a list of 3 letters", () => {
//         const testList = WordList.validateWord("cat");
//         testList.forEach((word) => {
//             expect(word[0]).toBe("c");
//             expect(word[1]).toBe("a");
//             expect(word[2]).toBe("t");
//         })
//     })
//     it("should have a list of first 2 letters", () => {
//         const testList = WordList.validateWord("peach");
//         testList.forEach((word) => {
//             expect(word[0]).toBe("p");
//             expect(word[1]).toBe("e");
//         })
//     })
//     it("should have a list of last 3 three letters", () => {
//         const testList = WordList.validateWord("peach");
//         testList.forEach((word) => {
//             expect(word[2]).toBe("a");
//             expect(word[3]).toBe("c");
//             expect(word[4]).toBe("h");
//         })
//     })
//     it("should have a list of 4 letters", () => {
//         const testList = WordList.validateWord("peach");
//         testList.forEach((word) => {
//             expect(word[0]).toBe("p");
//             expect(word[1]).toBe("e");
//             expect(word[2]).toBe("a");
//             expect(word[3]).toBe("c");
//             expect(word[4]).toBe("h");
//         })
//     })
//     it("List should not contain p at index 1", () => {
//         const testList = WordList.validateWord("peach");
//         testList.forEach((word) => {
//             expect(word[0]).toBe("p");
//             expect(word[1]).not.toBe("p");
//             expect(word[2]).toBe("a");
//             expect(word[3]).toBe("c");
//             expect(word[4]).toBe("h");
//         })
//     })
//     it("List should not contain a at index 1 and p at index 2", () => {
//         const testList = WordList.validateWord("peach");
//         testList.forEach((word) => {
//             expect(word[0]).not.toBe("a");
//             expect(word[1]).not.toBe("p");
//             expect(word[2]).toBe("a");
//             expect(word[3]).toBe("c");
//             expect(word[4]).toBe("h");
//         })
//     })
//     it("List should not contain a at index 1 and p at index 2", () => {
//         const testList = WordList.validateWord("peach");
//         testList.forEach((word) => {
//             expect(word[0]).toBe("p");
//             expect(word[1]).toBe("e");
//             expect(word[2]).not.toBe("p");
//             expect(word[3]).not.toBe("l");
//             expect(word[4]).not.toBe("e");
//         })
//     })
// });
