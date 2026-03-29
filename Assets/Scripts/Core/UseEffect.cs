using UnityEngine;

public class UseEffect : MonoBehaviour
{
    public Effect effectValues;
    
    public DNAModifier dnaModifier;

    private bool _contained = true;

    public void OnClick() {
        if(_contained) dnaModifier.RemoveEffect(effectValues);
        else dnaModifier.AddEffect(effectValues);
        _contained = !_contained;
    }
}
