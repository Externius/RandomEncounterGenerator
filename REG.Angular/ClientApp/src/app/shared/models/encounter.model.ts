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
