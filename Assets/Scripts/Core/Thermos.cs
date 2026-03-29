using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class Thermos : MonoBehaviour
{
    [SerializeField] private Slider slider;
    [SerializeField] private TextMeshProUGUI counterText;
    [SerializeField] private Button[] buttons;
    [Space]
    [SerializeField, Range(60,135)] private int lowTemp, highTemp;
    [Space]
    public UnityEvent<int> onTimerEnded;

    private float _time;
    [Space]
    [SerializeField, Range(0,100)] private float maxTime;

    public void StartLowProgram() => StartCoroutine(StartProgram(lowTemp));
    public void StartHighProgram() => StartCoroutine(StartProgram(highTemp));

    private IEnumerator StartProgram(int temp)
    {
        foreach (var btn in buttons) btn.interactable = false;
            
        slider.gameObject.SetActive(true);
        _time = maxTime;
        slider.value = 1;
        counterText.text = ((int)(_time)) + "s";
            
        while (_time > 0) {
            _time -= Time.deltaTime;
            slider.value = _time / maxTime;
            counterText.text = ((int)(_time)) + "s";
            yield return null;
        }
        onTimerEnded?.Invoke(temp);
    }
}