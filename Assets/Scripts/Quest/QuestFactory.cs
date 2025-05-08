using System;

public class QuestFactory
{
    public IQuest CreateQuest(IQuestConfig config, IQuestView view)
    {
        IQuest result = config switch
        {
            _ when config.GetType() == typeof(TimeInGameQuestConfig) => CreateTimeInGameQuest(config, view),
            _ when config.GetType() == typeof(UnitKillQuestConfig) => CreateUnitKillQuest(config, view),
            _ => throw new ArgumentException($"Unknown quest config: {config}")
        };
        
        return result;
    }

    private TimeInGameQuest CreateTimeInGameQuest(IQuestConfig config, IQuestView view)
    {
        return new TimeInGameQuest(config, view);
    }

    private UnitKillQuest CreateUnitKillQuest(IQuestConfig config, IQuestView view)
    {
        return new UnitKillQuest(config, view);
    }
}
