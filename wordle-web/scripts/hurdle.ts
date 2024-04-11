export function hurdleInput(input: string): string {
  switch (input) {
    case 'n':
      return 'Good choice, young hurdler...';
    case 'y':
      return 'Haha you fell over!';
    default:
      return 'Invalid input. Please try again.';
  }
}
