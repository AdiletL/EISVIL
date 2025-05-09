using System;

namespace Quest
{
    public class QuestFactory
    {
        public IQuestController CreateQuest(IQuestConfig config, IQuestView view)
        {
            switch(config)
            {
                case TimeInGameQuestConfig timeConfig:
                    var timeModel = new TimeInGameModel(timeConfig);
                    return new TimeInGameController(timeModel, view);
                
                case UnitKillQuestConfig killConfig:
                    var killModel = new UnitKillModel(killConfig);
                    return new UnitKillController(killModel, view);
                
                default:
                    throw new ArgumentException($"Unknown config type: {config.GetType()}");
            }
        }
    }
}
