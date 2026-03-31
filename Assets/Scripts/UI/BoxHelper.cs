using System.Collections;
using System.Text;
using TMPro;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.EventSystems;

namespace UI
{
    public class BoxHelper : MonoBehaviour, IPointerClickHandler
    {
        [SerializeField] UnityEvent onOpen, onClose;
        [SerializeField] TextMeshProUGUI textMeshProUGUI;
        [SerializeField, Range(0,0.1f)] private float offset = 0.05f;
        private bool hasClicked;
        private Coroutine current;
        private StringBuilder stringBuilder = new();
        

        public void Open()
        {
            onOpen?.Invoke();
        }

        public void Close()
        {
            onClose?.Invoke();
        }

        public void SetText(string text)
        {
            if (current != null) StopCoroutine(current);
            current = StartCoroutine(AnimateText(text));
        }

        private IEnumerator AnimateText(string text)
        {
            yield return new WaitForEndOfFrame();
            textMeshProUGUI.text = "";
            stringBuilder.Clear();

            for (var i = 0; i < text.Length; i++)
            {
                var t = text[i];
                if (hasClicked) {
                    if (i > 0) textMeshProUGUI.text = text;
                    hasClicked = false;
                    stringBuilder.Clear();
                    yield break;
                }

                stringBuilder.Append(t);
                textMeshProUGUI.text = stringBuilder.ToString();
                yield return new WaitForSeconds(offset);
            }
            stringBuilder.Clear();
        }

        public void OnPointerClick(PointerEventData eventData)
        {
            hasClicked = true;
        }
    }
}