using UnityEditor;
using UnityEngine;

namespace UI
{
    public class QuitHandler : MonoBehaviour
    {
        public void QuitGame()
        {
            if (Application.isEditor) {
                EditorApplication.isPlaying = false;
                return;
            }
            Application.Quit();
        }
    }
}
