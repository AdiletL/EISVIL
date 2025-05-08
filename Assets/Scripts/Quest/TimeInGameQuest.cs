using System;
using System.Threading;
using System.Threading.Tasks;
using UnityEngine;

public class TimeInGameQuest : Quest
{
    private int targetTimer;
    private int currentSeconds;
    private CancellationTokenSource cts;

    public TimeInGameQuest(IQuestConfig config, IQuestView questView) : base(config, questView)
    {
        var timerInGameConfig = config as TimeInGameQuestConfig;
        targetTimer = timerInGameConfig.Timer;
        this.questView.UpdateProgress(FormatTime(targetTimer));
    }
    
    private string GetFormattedProgress()
    {
        return $"{FormatTime(currentSeconds)} / {FormatTime(targetTimer)}";
    }

    private string FormatTime(int totalSeconds)
    {
        int minutes = totalSeconds / 60;
        int seconds = totalSeconds % 60;
        return $"{minutes:00}:{seconds:00}";
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

        while (elapsed < targetTimer)
        {
            if (ct.IsCancellationRequested)
                return;

            await Task.Delay(TimeSpan.FromSeconds(tickRate), ct);

            elapsed += tickRate;
            currentSeconds = Mathf.FloorToInt(elapsed);
            questView.UpdateProgress(GetFormattedProgress());
        }

        currentSeconds = targetTimer;
        questView.UpdateProgress(GetFormattedProgress());
        Complete();
    }
}