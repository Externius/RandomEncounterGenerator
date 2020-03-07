using System.Collections.Generic;

namespace REG.Core.Abstractions.Services.Models
{
    public class EncounterModel
    {
        public int SumXp { get; set; }
        public List<EncounterDetail> Encounters { get; set; }
        public EncounterModel()
        {
            Encounters = new List<EncounterDetail>();
        }
    }
}
