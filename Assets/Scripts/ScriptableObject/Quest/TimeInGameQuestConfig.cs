using System;
using UnityEngine;

[CreateAssetMenu(fileName = "TimeInGameQuestConfig", menuName = "SO/Quest/Time In Game", order = 51)]
public class TimeInGameQuestConfig : QuestConfig
{
    [field: SerializeField, Tooltip("Second")] public int Timer { get; private set; }
}
