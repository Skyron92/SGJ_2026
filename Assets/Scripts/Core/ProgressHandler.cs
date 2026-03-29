using System.Collections.Generic;
using UnityEngine;

public class ProgressHandler : MonoBehaviour
{
    private const string PROPERTY_NAME = "Progress";

    public void Save(int level) => PlayerPrefs.SetInt(PROPERTY_NAME, level);
    public int Load() => PlayerPrefs.GetInt(PROPERTY_NAME);
    
    [SerializeField] List<Quest> quests = new();

    public Quest GetLastQuestAvailable() {
        if(Load() > quests.Count) return quests[^1];
        int index = Load() == 0 ? 0 : Load() - 1;
        return quests[index];
    }
}