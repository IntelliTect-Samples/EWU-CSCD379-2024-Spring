export enum LetterState {
    Unknown = 0,
    Correct = 1,
    Misplaced = 2,
    Wrong = 3,
  }
  
  export class Letter {
    public char: string;
    public state: LetterState = LetterState.Unknown;
  
    constructor(char: string) {
      this.char = char;
    }
  }