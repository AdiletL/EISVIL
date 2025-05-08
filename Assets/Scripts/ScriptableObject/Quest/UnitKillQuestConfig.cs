using UnityEngine;

[CreateAssetMenu(fileName = "UnitKillQuestConfig", menuName = "SO/Quest/Unit Kill", order = 51)]
public class UnitKillQuestConfig : QuestConfig
{
    [field: SerializeField] public UnitType TargetUnitTypeID { get; private set; }
    [field: SerializeField] public int Amount { get; private set; }
}
