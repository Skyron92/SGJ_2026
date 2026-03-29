using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace UI
{
    public class FeedbackNotification : MonoBehaviour
    {
        [SerializeField, Range(0,20)] private float duration;
        
        [SerializeField] private Color wrongColor, rightColor;
        [SerializeField] private TextMeshProUGUI content;
        [SerializeField] private Image background;
        [SerializeField] private UIMoverX uiMover;
        
        public void Init(bool success, string message) {
            background.color = success ? rightColor : wrongColor;
            content.text = message;
            uiMover.MoveToOpen();
            StartCoroutine(Timer());
        }

        private IEnumerator Timer()
        {
            float time = 0;
            while (time < duration) {
                time += Time.deltaTime;
                yield return null;
            }
            uiMover.MoveToClose();
        }
    }
}