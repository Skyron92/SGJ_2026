using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace Core
{
    [CreateAssetMenu(menuName = "Gameplay/Mutation", fileName = "New mutation", order = 0)]
    public class Mutation : ScriptableObject
    {
        private const int AbsoluteMaxHeat = 1000;
        private const int AbsoluteMinHeat = -273;
        public List<Effect> effects;

        private int MaxHeat => Mathf.Clamp(effects.Sum(effect => effect.MaxHeat), AbsoluteMinHeat, AbsoluteMaxHeat);
        private int MaxPh => Mathf.Clamp(effects.Sum(effect => effect.MaxPh),0,14);
        private int MinPh => Mathf.Clamp(effects.Sum(effect => -effect.MinPh),0,14);
        private bool SupportUV => effects.FindAll(effect=> effect.SupportUv).Count() > effects.FindAll(effect=> !effect.SupportUv).Count();
        private bool SupportPulsed => effects.FindAll(effect=> effect.SupportPulsed).Count() > effects.FindAll(effect=> !effect.SupportPulsed).Count();
        
        public override string ToString()
        {
            string result = $"{(MaxHeat != 0 ? $"Température maximale : {MaxHeat}, " : "")}{(MaxPh != null && MinPh != null ? $"PH entre {MinPh} et {MaxPh}, ":"")}" +
                            $"{((SupportUV ? " supporte " : " ne supporte pas "))+"les rayons UV,"}"+
                            $"{(SupportPulsed ? " supporte " : " ne supporte pas ")+"la lumière pulsée."}";
            return result;
        }
    }
}