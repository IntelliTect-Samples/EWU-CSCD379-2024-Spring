import { describe, expect, it } from 'vitest';

function castSpell(guess: string) {
  if (guess.toLowerCase() === 'fireball') {
    return 'Success! The dragon is defeated!';
  } else {
    return 'The spell fails... Try again!';
  }
}

describe('Spell Casting Challenge', () => {
  it('should confirm the spell defeat of the dragon when "fireball" is guessed', () => {
    expect(castSpell('fireball')).toBe('Success! The dragon is defeated!');
  });

  it('should fail the spell when the wrong word is guessed', () => {
    expect(castSpell('water')).toBe('The spell fails... Try again!');
  });

  it('should handle case insensitivity correctly', () => {
    expect(castSpell('FireBall')).toBe('Success! The dragon is defeated!');
  });
});

