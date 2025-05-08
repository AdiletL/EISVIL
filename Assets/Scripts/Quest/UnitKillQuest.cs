
using UnityEngine;

public class UnitKillQuest : Quest
{
    private UnitType targetUnitTypeID;
    private int currentAmount;
    private int targetAmount;
    
    public UnitKillQuest(IQuestConfig config, IQuestView questView) : base(config, questView)
    {
        var unitKillConfig = config as UnitKillQuestConfig;
        targetUnitTypeID = unitKillConfig.TargetUnitTypeID;
        targetAmount = unitKillConfig.Amount;
        questView.UpdateProgress(GetProgressToString());
    }

    private string GetProgressToString()
    {
        return $"{currentAmount}/{targetAmount}";
    }
    
    public override void Start()
    {
        UnitController.OnDeath += OnDeathUnit;
    }

    public override void Stop()
    {
        UnitController.OnDeath -= OnDeathUnit;
    }
    
    private void OnDeathUnit(IUnitController unit)
    {
        if ((targetUnitTypeID & unit.UnitTypeID) != 0)
        {
            currentAmount++;
            questView.UpdateProgress(GetProgressToString());
            if (currentAmount >= targetAmount)
            {
                Stop();
                Complete();
                questView.UpdateProgress($"{targetAmount}/{targetAmount}");
            }
        }
    }
}
