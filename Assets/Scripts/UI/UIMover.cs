using DG.Tweening;
using UnityEngine;

namespace UI
{
    public class UIMover : PointerSensitive
    {
        [SerializeField] float closedHeight;
        [SerializeField] float openedHeight;
        [SerializeField, Range(0,1)] private float moveDuration = .2f;


        public void MoveToOpen() => transform.DOMoveY(openedHeight, moveDuration).SetEase(Ease.InBack);
        public void MoveToClose() => transform.DOMoveY(closedHeight, moveDuration).SetEase(Ease.OutBack);
    }
}
