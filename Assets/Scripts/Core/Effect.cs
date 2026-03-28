using UnityEngine;


[CreateAssetMenu(menuName = "Gameplay/Effect", fileName = "Effect", order = 0)]
public class Effect : ScriptableObject
{
    [SerializeField, Range(0,1000)] public int MaxHeat;
    public bool SupportUv,SupportPulsed;
    [SerializeField, Range(0,14)] public int MaxPh, MinPh;
}
