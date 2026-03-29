using UnityEditor;
using UnityEngine;

namespace UI
{
    public class QuitHandler : MonoBehaviour
    {
        public void QuitGame()
        {
#if UNITY_EDITOR
                EditorApplication.isPlaying = false;
#endif
            Application.Quit();
        }
    }
}
