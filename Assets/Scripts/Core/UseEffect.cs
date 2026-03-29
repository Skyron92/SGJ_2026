using UnityEngine;
using UnityEngine.UI;

public class UseEffect : MonoBehaviour
{
    public Effect effectValues;
    
    public DNAModifier dnaModifier;
    
    [SerializeField] private Sprite activated, disabled;
    [SerializeField] private Image image;

    private bool _contained = true;

    public void OnClick() {
        if(_contained) dnaModifier.RemoveEffect(effectValues);
        else dnaModifier.AddEffect(effectValues);
        _contained = !_contained;
        image.sprite = _contained ? activated : disabled;
    }
}
