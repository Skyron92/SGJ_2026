using DG.Tweening;
using UnityEngine;

namespace UI
{
    public class UIScaler : PointerSensitive
    {
        private const float BaseScale = 1;
        [SerializeField, Range(0,2)] private float hoverScale = 1.1f;
        [SerializeField, Range(0,2)] private float pressedScale = .9f;
        [SerializeField, Range(0,1)] private float scaleDuration = .2f;
        
        void Start() {
           ScaleToBase();
        }

        public void ScaleToBase() => transform.DOScale(BaseScale,scaleDuration);
        public void ScaleOnHoverEnter() => transform.DOScale(hoverScale,scaleDuration);
        public void ScaleOnPressed() => transform.DOScale(pressedScale,scaleDuration).OnComplete(IsMouseOver ? ScaleOnHoverEnter : ScaleToBase);
    }
}
