using DG.Tweening;
using UnityEngine;
using UnityEngine.EventSystems;

namespace UI
{
    public class UIScaler : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
    {
        private const float BaseScale = 1;
        [SerializeField, Range(0,2)] private float hoverScale = 1.1f;
        [SerializeField, Range(0,2)] private float pressedScale = .9f;
        [SerializeField, Range(0,1)] private float scaleDuration = .2f;
        
        private bool _isMouseOver;
        
        void Start() {
           ScaleToBase();
        }

        public void ScaleToBase() => transform.DOScale(BaseScale,scaleDuration);
        public void ScaleOnHoverEnter() => transform.DOScale(hoverScale,scaleDuration);
        public void ScaleOnPressed() => transform.DOScale(pressedScale,scaleDuration).OnComplete(_isMouseOver ? ScaleOnHoverEnter : ScaleToBase);
        
        public void OnPointerEnter(PointerEventData _) => _isMouseOver = true;

        public void OnPointerExit(PointerEventData _) => _isMouseOver = false;
    }
}
