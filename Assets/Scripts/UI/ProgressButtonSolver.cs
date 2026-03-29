using UnityEngine;
using UnityEngine.UI;

namespace UI
{
    public class ProgressButtonSolver : MonoBehaviour
    {
        [SerializeField] private int levelUnlocked;
        [SerializeField] private ProgressHandler progressHandler;
        [SerializeField] private Button button;

        private void Awake() {
            button.interactable = progressHandler.Load() >= levelUnlocked;
        }
    }
}