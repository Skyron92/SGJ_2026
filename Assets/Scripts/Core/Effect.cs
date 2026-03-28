using UnityEngine;


[CreateAssetMenu(menuName = "Gameplay/Effect", fileName = "Effect", order = 0)]
public class Effect : ScriptableObject
{
    [Range(0,1000)] public int MaxHeat;
    [Range(-1,1)] public int SupportUv,SupportPulsed;
    [Range(0,14)] public int MaxPh, MinPh;
}
