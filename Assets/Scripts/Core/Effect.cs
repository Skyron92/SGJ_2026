using UnityEngine;


[CreateAssetMenu(menuName = "Gameplay/Effect", fileName = "Effect", order = 0)]
public class Effect : ScriptableObject
{
    [Range(-100,200)] public int MaxHeat;
    [Range(-3,3)] public int SupportUv,SupportPulsed;
    [Range(-5,5)] public int MaxPh, MinPh;
}
