using System;
using System.Threading;
using System.Threading.Tasks;
using UnityEngine;

namespace Quest
{
    public class TimeInGameModel : QuestModel
    {
        public int TargetTimer { get; }
        public int CurrentSeconds { get; private set; }

        public TimeInGameModel(TimeInGameQuestConfig config) : base(config)
        {
            TargetTimer = config.Timer;
        }

        public string GetFormattedProgress()
        {
            return $"{FormatTime(CurrentSeconds)} / {FormatTime(TargetTimer)}";
        }

        public string FormatTime(int totalSeconds)
        {
            int minutes = totalSeconds / 60;
            int seconds = totalSeconds % 60;
            return $"{minutes:00}:{seconds:00}";
        }

        public void SetCurrentSeconds(int seconds) => CurrentSeconds = seconds;
    }

    public class TimeInGameController : QuestController<TimeInGameModel>
    {
        private CancellationTokenSource cts;

        public TimeInGameController(TimeInGameModel model, IQuestView questView) : base(model, questView)
        {
            this.questView.UpdateProgress(model.FormatTime(model.TargetTimer));
        }

        public override void Start()
        {
            cts = new CancellationTokenSource();
            _ = StartTimerAsync(cts.Token);
        }

        public override void Stop()
        {
            cts?.Cancel();
        }

        private async Task StartTimerAsync(CancellationToken ct)
        {
            float elapsed = 0f;
            float tickRate = 1f;

            while (elapsed < questModel.TargetTimer)
            {
                if (ct.IsCancellationRequested)
                    return;

                await Task.Delay(TimeSpan.FromSeconds(tickRate), ct);

                elapsed += tickRate;
                questModel.SetCurrentSeconds(Mathf.FloorToInt(elapsed));
                questView.UpdateProgress(questModel.GetFormattedProgress());
            }

            questModel.SetCurrentSeconds(questModel.TargetTimer);
            questView.UpdateProgress(questModel.GetFormattedProgress());
            Complete();
        }
    }
}