export function hurdleInput(input: string): string {
    if (input === 'n') {
        return "Good choice, young hurdler...";
    } else if (input === 'y') {
        return "Haha you fell over!";
    } else {
        return "Invalid input. Please try again.";
    }
}
