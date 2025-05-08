using System;
using System.Collections.Generic;
using UnityEngine;

public class QuestManager : MonoBehaviour
{
    [SerializeField] private QuestConfigContainer questConfigContainer;
    [SerializeField] private QuestViewContainer questViewContainerPrefab;

    private QuestFactory questFactory;
    private List<IQuest> quests;
    
    private void Start()
    {
        questFactory = new QuestFactory();
        quests = new List<IQuest>();
        
        questViewContainerPrefab = Instantiate(questViewContainerPrefab);
        foreach (var questConfig in questConfigContainer.QuestConfigs)
        {
            var newView = questViewContainerPrefab.CreateQuestView();
            var newQuest = questFactory.CreateQuest(questConfig, newView);
            quests.Add(newQuest);
        }

        StartQuests();
    }

    private void StartQuests()
    {
        if(quests == null) return;
        foreach (var VARIABLE in quests)
            VARIABLE.Start();
    }
}
