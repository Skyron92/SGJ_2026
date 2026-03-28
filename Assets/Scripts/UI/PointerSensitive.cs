using UnityEngine;
using UnityEngine.EventSystems;

namespace UI
{
    public abstract class PointerSensitive : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
    {
        protected bool IsMouseOver { get; private set; }
        
        public virtual void OnPointerEnter(PointerEventData eventData) => IsMouseOver = true;

        public virtual void OnPointerExit(PointerEventData eventData) => IsMouseOver = false;
    }
}