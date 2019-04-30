using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

[System.Serializable]
public class QuestUI
{
    public PlayerQuest player;
    public GameObject questWindow;

    public Text nameText;
    public Text descriptionText;
    public Text expText;
    public Text goldText; 
}
public class QuestGiver : MonoBehaviour
{
    public Quest quest;
    public QuestUI UI;

    public void OpenQuestWindow()
    {
        UI.questWindow.SetActive(true);
        UI.nameText.text = quest.name;
        UI.descriptionText.text = quest.description;
        UI.expText.text = quest.expReward.ToString();
        UI.goldText.text = quest.goldReward.ToString();
    }

    public void AcceptQuest()
    {
        UI.questWindow.SetActive(false);
        if(quest.state == QuestState.New)
        {
            quest.state = QuestState.Accepted;
            UI.player.quests.Add(quest);
        }
    }
}
