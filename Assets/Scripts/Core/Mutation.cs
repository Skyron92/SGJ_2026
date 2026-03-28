using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace Core
{
    [CreateAssetMenu(menuName = "Gameplay/Mutation", fileName = "New mutation", order = 0)]
    public class Mutation : ScriptableObject
    {
        private const int AbsoluteMaxHeat = 135;
        private const int AbsoluteMinHeat = 70;
        private const int AbsoluteMinPh = 2;
        private const int AbsoluteMaxPh = 12;
        public List<Effect> effects;

        private int MaxHeat => Mathf.Clamp(effects.Sum(effect => effect.MaxHeat), AbsoluteMinHeat, AbsoluteMaxHeat);
        private int MaxPh => Mathf.Clamp(effects.Sum(effect => effect.MaxPh),AbsoluteMinPh,AbsoluteMaxPh);
        private int MinPh => Mathf.Clamp(effects.Sum(effect => -effect.MinPh),AbsoluteMinPh,AbsoluteMaxPh);
        private int SupportUV => (int)Mathf.Sign(effects.Sum(effect => effect.SupportUv));
        private int SupportPulsed => (int)Mathf.Sign(effects.Sum(effect => effect.SupportPulsed));
        
        public override string ToString()
        {
            string result = $"{(MaxHeat != 0 ? $"Température maximale : {MaxHeat}, " : "")}{(MaxPh != null && MinPh != null ? $"PH entre {MinPh} et {MaxPh}, ":"")}" +
                            $"{(SupportUV != 0 ? ((SupportUV > 0 ? " supporte " : " ne supporte pas ")+"les rayons UV,"):"")}"+
                            $"{(SupportPulsed != 0 ? ((SupportPulsed > 0 ? " supporte " : " ne supporte pas ")+"la lumière pulsée."):"")}";
            return result;
        }
    }
}