using DG.Tweening;
using UnityEngine;

namespace UI
{
    public class UIMoverX : PointerSensitive
    {
        [SerializeField] private float closedPos;
        [SerializeField] float openedPos;
        [SerializeField, Range(0,1)] private float moveDuration = .2f;


        public void MoveToOpen() => transform.DOMoveX(openedPos, moveDuration).SetEase(Ease.InBack);
        public void MoveToClose() => transform.DOMoveX(closedPos, moveDuration).SetEase(Ease.OutBack);
    }
}
