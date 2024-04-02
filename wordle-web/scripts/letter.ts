export enum LetterState {
  Unknown = 0,
  Correct,
  Misplaced,
  Wrong,
}

export class Letter {
  public char: string;
  public state: LetterState = LetterState.Unknown;

  constructor(char: string) {
    this.char = char;
  }
}
