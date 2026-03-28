using DG.Tweening;
using UnityEngine;

namespace UI
{
    public class GameplayDialog : MonoBehaviour
    {
        private const float BaseScale = 1;
        private const float CloseScale = 0;
        [SerializeField, Range(0,1)] private float scaleDuration = .2f;

        private void OnEnable()
        {
            Open();
        }

        private void Open()
        {
            transform.DOScale(BaseScale,scaleDuration).SetEase(Ease.OutBack);
        }
        
        public void Close()
        {
            transform.DOScale(CloseScale,scaleDuration).SetEase(Ease.InBack);
        }
    }
}