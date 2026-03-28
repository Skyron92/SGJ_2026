using UnityEngine;

namespace UI
{
    public delegate void ExplanationsHandler(Explanations explanations);
    
    public interface IExplainable
    {
        public event ExplanationsHandler OnExplainStarted;
        public event ExplanationsHandler OnExplainEnded;
        
    }
    public class Explainable : PointerSensitive, IExplainable
    {
        public event ExplanationsHandler OnExplainStarted, OnExplainEnded;
        [SerializeField] private Explanations explanations;
        [SerializeField] private bool explainOnStart;
        
        private void Start() {
            explanations.Reset();
            if(!explainOnStart) return;
            TriggerExplanations();
        }

        public void TriggerExplanations() => OnExplainStarted?.Invoke(explanations);
        public void FinishExplanations() => OnExplainEnded?.Invoke(explanations);
    }
}