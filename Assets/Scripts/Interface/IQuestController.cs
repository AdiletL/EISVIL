using System;

public interface IQuestController
{
    public void Start();
    public void Stop();
    public void Complete();
}

public interface IQuestView
{
    public void Initialize();
    public void SetDescription(string description);
    public void UpdateProgress(string value);
    public void SetCompleted();
}

public interface IQuestConfig
{
    public string Description { get; }
}
