export class SpecialAbility {
  name = '';
  desc = '';
  attack_bonus?: number;
  damage_dice = '';
}
export class Action {
  name = '';
  desc = '';
  attack_bonus?: number;
  damage_dice = '';
  damage_bonus?: number;
}
export class LegendaryAction {
  name = '';
  desc = '';
  attack_bonus?: number;
  damage_dice = '';
}
export class Reaction {
  name = '';
  desc = '';
  attack_bonus?: number;
}
export class EncounterDetailModel {
  xp = 0;
  count = 0;
  name = '';
  type = '';
  difficulty = '';
  challengeRating = '';
  size = '';
  alignment = '';
  hp = 0;
  ac = 0;
  hitDice = '';
  speed = '';
  senses = '';
  languages = '';
  strength = 0;
  dexterity = 0;
  constitution = 0;
  intelligence = 0;
  wisdom = 0;
  charisma = 0;
  strengthSave = 0;
  constitutionSave = 0;
  dexteritySave = 0;
  intelligenceSave = 0;
  wisdomSave = 0;
  charismaSave = 0;
  history = 0;
  perception = 0;
  damageVulnerabilities = '';
  damageResistances = '';
  damageImmunities = '';
  conditionImmunities = '';
  specialAbilities: SpecialAbility[] = [];
  actions: Action[] = [];
  reactions: Reaction[] = [];
  legendaryActions: LegendaryAction[] = [];
}
export class EncounterModel {
  sumXp = 0;
  encounters: EncounterDetailModel[] = [];
}
export class EncounterOptionModel {
  partyLevel = 1;
  partySize = 4;
  difficulty: number | null = null;
  monsterTypes: number[] = [];
  sizes: number[] = [];
  count = 12;
}
