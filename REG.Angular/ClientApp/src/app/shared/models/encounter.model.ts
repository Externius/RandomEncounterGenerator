export class SpecialAbility {
  name: string;
  desc: string;
  attack_Bonus: number;
  damage_Dice: string;
}
export class Action {
  name: string;
  desc: string;
  attack_Bonus: number;
  damage_Dice: string;
  damage_Bonus: number;
}
export class LegendaryAction {
  name: string;
  desc: string;
  attack_Bonus: number;
  damage_Dice: string;
}
export class Reaction {
  name: string;
  desc: string;
  attack_Bonus: number;
}
export class EncounterDetailModel {
  xp: number;
  count: number;
  name: string;
  type: string;
  difficulty: string;
  challengeRating: string;
  size: string;
  alignment: string;
  hp: number;
  ac: number;
  hitDice: string;
  speed: string;
  senses: string;
  languages: string;
  strength: number;
  dexterity: number;
  constitution: number;
  intelligence: number;
  wisdom: number;
  charisma: number;
  strengthSave: number;
  constitutionSave: number;
  dexteritySave: number;
  intelligenceSave: number;
  wisdomSave: number;
  charismaSave: number;
  history: number;
  perception: number;
  damageVulnerabilities: string;
  damageResistances: string;
  damageImmunities: string;
  conditionImmunities: string;
  specialAbilities: SpecialAbility[];
  actions: Action[];
  reactions: Reaction[];
  legendaryActions: LegendaryAction[];
}
export class EncounterModel {
  sumXp: number;
  encounters: EncounterDetailModel[];
}
export class EncounterOptionModel {
  partyLevel: number;
  partySize: number;
  difficulty: number | null;
  monsterTypes: number[];
  count = 10;

  constructor() {
    this.partyLevel = 1;
    this.partySize = 4;
    this.difficulty = null;
    this.monsterTypes = [];
  }
}
