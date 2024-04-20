export enum LetterState {
  Unknown = 0,
  Correct = 1,
  Misplaced = 2,
  Wrong = 3,
}

export class Letter {
  public char: string;
  public state: LetterState = LetterState.Unknown;

  constructor(char: string, state: LetterState = LetterState.Unknown) {
    this.char = char;
    this.state = state;
  }

  public get color(): string {
    switch (this.state) {
      case LetterState.Correct:
        return "correct";
      case LetterState.Misplaced:
        return "misplaced";
      case LetterState.Wrong:
        return "wrong";
      default:
        return "unknown";
    }
  }
}
