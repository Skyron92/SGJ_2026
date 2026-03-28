using TMPro;
using UnityEngine;
using UnityEngine.Events;

namespace UI
{
    public class BoxHelper : MonoBehaviour
    {
        [SerializeField] UnityEvent onOpen, onClose;
        [SerializeField] TextMeshProUGUI textMeshProUGUI;

        public void Open()
        {
            onOpen?.Invoke();
        }

        public void Close()
        {
            onClose?.Invoke();
        }

        public void SetText(string text) => textMeshProUGUI.text = text;
    }
}