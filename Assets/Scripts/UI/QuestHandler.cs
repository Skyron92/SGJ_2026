using Core;
using TMPro;
using UnityEngine;

namespace UI
{
    public class QuestHandler : MonoBehaviour
    {
        public Quest questTemp;
        
        [SerializeField] private TextMeshProUGUI title, description, goals;

        private void Start()
        {
            DisplayQuest();
        }

        public void DisplayQuest()
        {
            title.text = questTemp.customer;
            description.text = questTemp.description;
            goals.text = questTemp.requestedMutation.ToString();
        }

        public void SubmitMutation(Mutation mutation)
        {
        }
    }
}