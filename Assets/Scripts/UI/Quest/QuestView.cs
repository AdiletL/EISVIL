using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class QuestView : MonoBehaviour, IQuestView
{
    [SerializeField] private TextMeshProUGUI descriptionText;
    [SerializeField] private TextMeshProUGUI progressTxt;
    
    [Space]
    [SerializeField] private Image background;
    
    public void Initialize()
    {
        
    }

    public void SetDescription(string description)
    {
        descriptionText.text = description;
    }

    public void UpdateProgress(string value)
    {
        progressTxt.text = value;
    }

    public void SetCompleted()
    {
        background.color = Color.green;
    }
}
