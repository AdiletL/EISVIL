
using UnityEngine;

namespace Quest
{
    public class UnitKillModel : QuestModel
    {
        public UnitType TargetUnitTypeID { get; }
        public int CurrentAmount { get; private set; }
        public int TargetAmount { get; }

        public UnitKillModel(UnitKillQuestConfig config) : base(config)
        {
            this.TargetUnitTypeID = config.TargetUnitTypeID;
            this.TargetAmount = config.Amount;
        }
        
        public string GetProgressToString()
        {
            return $"{CurrentAmount}/{TargetAmount}";
        }
        
        public void AddAmount(int amount) => CurrentAmount += amount;
    }

    public class UnitKillController : QuestController<UnitKillModel>
    {
        public UnitKillController(UnitKillModel model, IQuestView questView) : base(model, questView)
        {
            questView.UpdateProgress(model.GetProgressToString());
        }


        public override void Start()
        {
            UnitController.OnDeath += OnDeathUnit;
        }

        public override void Stop()
        {
            UnitController.OnDeath -= OnDeathUnit;
        }

        private void OnDeathUnit(UnitController unit)
        {
            if ((questModel.TargetUnitTypeID & unit.UnitTypeID) != 0)
            {
                questModel.AddAmount(1);
                questView.UpdateProgress(questModel.GetProgressToString());
                if (questModel.CurrentAmount >= questModel.TargetAmount)
                {
                    Stop();
                    Complete();
                    questView.UpdateProgress($"{questModel.TargetAmount}/{questModel.TargetAmount}");
                }
            }
        }
    }
}
