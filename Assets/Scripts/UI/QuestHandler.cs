using DG.Tweening;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace UI
{
    public class QuestHandler : MonoBehaviour
    {
        [Header("Quest")]
        public Quest currentQuest;
        
        [SerializeField] private TextMeshProUGUI title, description;
        [SerializeField] private ProgressHandler progressHandler;
        
        [Header("Feedbadck")]
        [SerializeField] private Transform buttonTransform;
        [SerializeField,Range(0,100)] private float shakeIntensity, shakeDuration;
        [SerializeField] private Image buttonImage;
        [SerializeField] private Color wrongColor, rightColor;
        [SerializeField,Range(0,2)] private float rightDuration, wrongDuration;
        [SerializeField,Range(1,5)] private int wrongTwinkleIterations;
        [SerializeField] private FeedbackNotification feedbackNotification;

        private void Start()
        {
            currentQuest= progressHandler.GetLastQuestAvailable();
            DisplayQuest();
        }

        public void DisplayQuest()
        {
            title.text = currentQuest.customer;
            description.text = currentQuest.description;
        }

        public void SubmitMutation()
        {
            var mutation = MutationHandler.Instance.GetCurrentMutation();
            if (!mutation) {
                ThrowFeedback(false, "Tu dois d'abord créer une mutation.");
                return;
            }
            var requestedEffect = currentQuest.requestedMutation.effects[0];
            if(requestedEffect.MaxHeat != 0 && requestedEffect.MaxHeat > mutation.MaxHeat) {
                ThrowFeedback(false, "Votre mutation ne résiste pas à la chaleur demandée.");
                return;
            }
            if (requestedEffect.MaxPh != 0 && requestedEffect.MaxPh > mutation.MaxPh) {
                ThrowFeedback(false, "Votre mutation ne résiste pas au Ph demandé.");
                return;
            }
            if (requestedEffect.MinPh != 0 && requestedEffect.MinPh > mutation.MinPh) {
                ThrowFeedback(false, "Votre mutation ne résiste pas au Ph demandé.");
                return;
            }
            if (requestedEffect.SupportPulsed != 0 && requestedEffect.SupportPulsed != mutation.SupportPulsed) {
                ThrowFeedback(false, "Votre mutation n'a pas la résistance attendue face à la lumière pulsée.");
                return;
            }
            if (requestedEffect.SupportPulsed != 0 && requestedEffect.SupportUv != mutation.SupportUV) {
                ThrowFeedback(false, "Votre mutation n'a pas la résistance attendue face aux rayons UV.");
                return;
            }
            ThrowFeedback(true, "Félcitiation, votre mutation remplit tous les citères !");
            progressHandler.Save(progressHandler.Load()+1);
            currentQuest = progressHandler.GetLastQuestAvailable();
        }

        public void ThrowFeedback(bool success, string message)
        {
            if (!success) {
                WrongFade(0);
                buttonTransform.DOShakePosition(shakeDuration, shakeIntensity);
            }
            else RightFade();

            feedbackNotification.gameObject.SetActive(true);
            feedbackNotification.Init(success, message);
        }

        private void RightFade()
        {
            buttonImage.DOColor(rightColor, rightDuration).SetEase(Ease.OutBack);
        } 
        private void WrongFade(int count) {
            if(count >= wrongTwinkleIterations) return;
            buttonImage.DOColor(wrongColor, wrongDuration).OnComplete((() => buttonImage.DOColor(Color.white, wrongDuration))).OnComplete((() => {
                WrongFade(count+1);
            }));
        }
    }
}