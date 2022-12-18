export class SpecialAbility {
  name: string = "";
  desc: string = "";
  attack_bonus: number = 0;
  damage_dice: string = "";
}
export class Action {
  name: string = "";
  desc: string = "";
  attack_bonus: number = 0;
  damage_dice: string = "";
  damage_bonus: number = 0;
}
export class LegendaryAction {
  name: string = "";
  desc: string = "";
  attack_bonus: number = 0;
  damage_dice: string = "";
}
export class Reaction {
  name: string = "";
  desc: string = "";
  attack_bonus: number = 0;
}
export class EncounterDetailModel {
  xp: number = 0;
  count: number = 0;
  name: string = "";
  type: string = "";
  difficulty: string = "";
  challengeRating: string = "";
  size: string = "";
  alignment: string = "";
  hp: number = 0;
  ac: number = 0;
  hitDice: string = "";
  speed: string = "";
  senses: string = "";
  languages: string = "";
  strength: number = 0;
  dexterity: number = 0;
  constitution: number = 0;
  intelligence: number = 0;
  wisdom: number = 0;
  charisma: number = 0;
  strengthSave: number = 0;
  constitutionSave: number = 0;
  dexteritySave: number = 0;
  intelligenceSave: number = 0;
  wisdomSave: number = 0;
  charismaSave: number = 0;
  history: number = 0;
  perception: number = 0;
  damageVulnerabilities: string = "";
  damageResistances: string = "";
  damageImmunities: string = "";
  conditionImmunities: string = "";
  specialAbilities: SpecialAbility[] = [];
  actions: Action[] = [];
  reactions: Reaction[] = [];
  legendaryActions: LegendaryAction[] = [];
}
export class EncounterModel {
  sumXp: number = 0;
  encounters: EncounterDetailModel[] = [];
}
export class EncounterOptionModel {
  partyLevel: number = 0;
  partySize: number = 0;
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
