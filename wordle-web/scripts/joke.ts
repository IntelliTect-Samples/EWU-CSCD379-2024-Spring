// Function that checks the punchline of a joke
export function tellJoke(punchline: string): string {
    const correctAnswer = 'because they make up everything';
    if (punchline.trim().toLowerCase() === correctAnswer) {
      return 'Correct! 😄';
    } else {
      return `Nope, the correct answer is: ${correctAnswer}.`;
    }
  }
  