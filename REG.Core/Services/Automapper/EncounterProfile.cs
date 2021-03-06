﻿using AutoMapper;
using REG.Core.Abstractions.Services.Models;
using REG.Core.Abstractions.Services.Models.Json;

namespace REG.Core.Services.Automapper
{
    public class EncounterProfile : Profile
    {
        public EncounterProfile()
        {
            CreateMap<Monster, EncounterDetail>(MemberList.None)
                .ForMember(d => d.ChallengeRating, opt => opt.MapFrom(s => s.Challenge_Rating))
                .ForMember(d => d.SterngthSave, opt => opt.MapFrom(s => s.Strength_Save))
                .ForMember(d => d.DexteritySave, opt => opt.MapFrom(s => s.Dexterity_Save))
                .ForMember(d => d.ConstitutionSave, opt => opt.MapFrom(s => s.Constitution_Save))
                .ForMember(d => d.IntelligenceSave, opt => opt.MapFrom(s => s.Intelligence_Save))
                .ForMember(d => d.WisdomSave, opt => opt.MapFrom(s => s.Wisdom_Save))
                .ForMember(d => d.CharismaSave, opt => opt.MapFrom(s => s.Charisma_Save))
                .ForMember(d => d.HP, opt => opt.MapFrom(s => s.Hit_Points))
                .ForMember(d => d.AC, opt => opt.MapFrom(s => s.Armor_Class))
                .ForMember(d => d.HitDice, opt => opt.MapFrom(s => s.Hit_Dice))
                .ForMember(d => d.ConditionImmunities, opt => opt.MapFrom(s => s.Condition_Immunities))
                .ForMember(d => d.DamageImmunities, opt => opt.MapFrom(s => s.Damage_Immunities))
                .ForMember(d => d.DamageResistances, opt => opt.MapFrom(s => s.Damage_Resistances))
                .ForMember(d => d.DamageVulnerabilities, opt => opt.MapFrom(s => s.Damage_Vulnerabilities))
                .ForMember(d => d.SpecialAbilities, opt => opt.MapFrom(s => s.Special_Abilities))
                .ForMember(d => d.LegendaryActions, opt => opt.MapFrom(s => s.Legendary_Actions))
                .ForMember(d => d.IntelligenceSave, opt => opt.MapFrom(s => s.Intelligence_Save));
        }
    }
}
