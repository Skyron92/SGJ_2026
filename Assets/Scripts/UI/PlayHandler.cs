using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

namespace UI
{
    public class PlayHandler : MonoBehaviour
    {
        [SerializeField] private GameObject loaderCanvas;
        [SerializeField] private Slider loadingSlider;

        public void LoadGameScene()
        {
            StartCoroutine(LoadGameSceneAsync());
        }
        
        private IEnumerator LoadGameSceneAsync() {
            var loadingLevel = SceneManager.LoadSceneAsync(1);
            if (loadingLevel == null) throw new System.Exception("The scene index isn't valid. Check the scene has been added to built scenes list.");
            loaderCanvas.SetActive(true);
            loadingSlider.value = 0;
            while (!loadingLevel.isDone) {
                loadingSlider.value = loadingLevel.progress;
                yield return null;
            }
            loadingSlider.value = 0;
            loaderCanvas.SetActive(false);
        }
    }
}
