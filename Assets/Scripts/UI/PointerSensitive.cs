using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.InputSystem;

namespace UI
{
    public abstract class PointerSensitive : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
    {
        [SerializeField] private InputActionReference inputActionReference;
        protected InputAction InputAction => inputActionReference.action;
        
        protected bool IsMouseOver { get; private set; }
        
        public virtual void OnPointerEnter(PointerEventData eventData) => IsMouseOver = true;

        public virtual void OnPointerExit(PointerEventData eventData) => IsMouseOver = false;
        
        public virtual void OnClick(InputAction.CallbackContext ctx) {}
        
        protected virtual void OnEnable()
        {
            InputAction.Enable();
            InputAction.started += OnClick;
        }
        
        protected virtual void OnDisable()
        {
            InputAction.RemoveAllBindingOverrides();
            InputAction.Disable();
        }
    }
}