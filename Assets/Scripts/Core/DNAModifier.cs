using System.Collections.Generic;
using UnityEngine;

public class DNAModifier : MonoBehaviour
{
    Mutation _currentMutation;
    [SerializeField] private List<Effect> effects;

    private void Awake() {
        _currentMutation = ScriptableObject.CreateInstance<Mutation>();
        _currentMutation.effects = effects;
    }
    
    public void RemoveEffect(Effect effect) {
        if(!effects.Contains(effect)) return;
        effects.Remove(effect);
    }

    public void AddEffect(Effect effect) => effects.Add(effect);
    
    public void Submit() {
        MutationHandler.Instance.SetMutation(_currentMutation);
    }
}
