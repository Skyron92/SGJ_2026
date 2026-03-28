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
        
        [SerializeField] private InputActionReference inputActionReference;
        private InputAction InputAction => inputActionReference.action;

        private void OnEnable()
        {
            Open();
            InputAction.Enable();
            InputAction.started += OnClick;
        }

        private void OnDisable()
        {
            InputAction.started -= OnClick;
            InputAction.Disable();
        }

        private void Open()
        {
            transform.DOScale(BaseScale,scaleDuration).SetEase(Ease.OutBack);
        }
        
        public void Close()
        {
            transform.DOScale(CloseScale,scaleDuration).SetEase(Ease.InBack).OnComplete(() => gameObject.SetActive(false));
        }

        public void OnClick(InputAction.CallbackContext _)
        {
            if(IsMouseOver) return;
            Close();
        }
    }
}