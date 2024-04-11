import { describe, expect, it } from 'vitest';
import { castSpell } from '~/scripts/lexiquest';

describe('LexiQuest Game: The Spell of Truth', () => {
  it('should acknowledge the correct spell casting', () => {
    expect(castSpell('quest')).toContain('Perfect!');
  });

  it('should provide feedback for incorrect spells', () => {
    expect(castSpell('test')).toContain('Incorrect spell!');
  });

  it('should manage case sensitivity in spell casting', () => {
    expect(castSpell('QuEsT')).toContain('Perfect!');
  });
});
