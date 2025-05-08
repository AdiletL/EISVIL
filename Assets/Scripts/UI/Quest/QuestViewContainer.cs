using System.Collections.Generic;
using UnityEngine;

public class QuestViewContainer : MonoBehaviour
{
    [SerializeField] private GameObject questViewPrefab;
    [SerializeField] private Transform container;
    
    
    public IQuestView CreateQuestView()
    {
        return Instantiate(questViewPrefab, container).GetComponent<IQuestView>();
    }
}
