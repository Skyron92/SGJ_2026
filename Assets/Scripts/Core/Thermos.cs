using System.Collections;
using TMPro;
using UI;
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
    
    [SerializeField] private FeedbackNotification feedbackNotification;
    
    public AudioSource audioSource;

    public void StartLowProgram() => StartCoroutine(StartProgram(lowTemp));
    public void StartHighProgram() => StartCoroutine(StartProgram(highTemp));

    private IEnumerator StartProgram(int temp)
    {
        if (MutationHandler.Instance.GetCurrentMutation() == null) {
            feedbackNotification.gameObject.SetActive(true);
            feedbackNotification.Init(false, "Vous n'avez pas de mutation à tester.");
            yield break;
        }
        SetAllButtonsEnabled(false);
        audioSource.Play();
            
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
        
        SetAllButtonsEnabled(true);
        slider.gameObject.SetActive(false);
        feedbackNotification.gameObject.SetActive(true);
        var success = MutationHandler.Instance.SupportWarm(temp);
        if(!success) MutationHandler.Instance.KillMutation();
        feedbackNotification.Init(success, success ? "Votre mutation a survécu au programme !" : "Votre mutation n'a pas survécu au programme...");
        onTimerEnded?.Invoke(temp);
    }

    private void SetAllButtonsEnabled(bool state)
    {
        foreach (var btn in buttons) btn.interactable = state;
    }
}