using UnityEngine;

public abstract class QuestConfig : ScriptableObject, IQuestConfig
{
    [field: SerializeField, TextArea] public string Description { get; private set; }
}
