using UnityEngine;
using UnityEngine.Events;

namespace UI
{
    public class Explainable : PointerSensitive
    {
        public UnityEvent<Explanations> onExplainStarted, onExplainEnded;
        [SerializeField] private Explanations explanations;
        [SerializeField] private bool explainOnStart;
        
        private void Start() {
            explanations.Reset();
            explanations.onEnded += (e, a) => FinishExplanations();
            if(!explainOnStart) return;
            TriggerExplanations();
        }

        public void TriggerExplanations() => onExplainStarted?.Invoke(explanations);
        public void FinishExplanations() => onExplainEnded?.Invoke(explanations);
    }
}