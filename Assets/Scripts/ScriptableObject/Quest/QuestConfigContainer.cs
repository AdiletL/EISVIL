using UnityEngine;

[CreateAssetMenu(fileName = "QuestConfigContainer", menuName = "SO/Quest/Container", order = 51)]
public class QuestConfigContainer : ScriptableObject
{
    [field: SerializeField] public QuestConfig[] QuestConfigs { get; private set; }
}
