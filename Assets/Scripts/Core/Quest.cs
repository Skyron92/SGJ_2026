using UnityEngine;

[CreateAssetMenu(menuName = "Gameplay/Quest", fileName = "New quest", order = 0)]
public class Quest : ScriptableObject
{
    public string customer;
    [TextArea(3, 20)]
    public string description;
    public Mutation requestedMutation;
}