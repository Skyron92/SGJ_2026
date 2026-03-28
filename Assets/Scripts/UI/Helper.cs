#nullable enable
using UnityEngine;

namespace UI
{
    public class Helper : PointerSensitive
    {
        [SerializeField] Explainable[] explainables;
        [SerializeField] BoxHelper boxHelper;

        private void Awake()
        {
            foreach (var explainable in explainables)
            {
                explainable.OnExplainStarted += OnExplain;
                explainable.OnExplainEnded += OnExplainEnded;
            }
        }

        private void OnExplain(Explanations explanations)
        {
            explanations.Reset();
            boxHelper.Open();
            boxHelper.SetText(explanations.GetNextContent());
            InputAction.started += _ =>
            {
                string? nextContent = explanations.GetNextContent();
                if(nextContent != null) boxHelper.SetText(nextContent);
                else boxHelper.Close();
            };
        }
        private void OnExplainEnded(Explanations _)
        {
            boxHelper.Close();
        }
    }
}