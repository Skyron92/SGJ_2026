using DG.Tweening;
using UnityEngine;
using UnityEngine.InputSystem;

namespace UI
{
    public class GameplayDialog : PointerSensitive
    {
        private const float BaseScale = 1;
        private const float CloseScale = 0;
        [SerializeField, Range(0,1)] private float scaleDuration = .2f;

        protected override void OnEnable() {
            base.OnEnable();
            Open();
        }

        private void Open()
        {
            transform.DOScale(BaseScale,scaleDuration).SetEase(Ease.OutBack);
        }
        
        public void Close()
        {
            transform.DOScale(CloseScale,scaleDuration).SetEase(Ease.InBack).OnComplete(() => gameObject.SetActive(false));
        }

        public override void OnClick(InputAction.CallbackContext _) {
            if(IsMouseOver) return;
            Close();
        }
    }
}