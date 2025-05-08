using System;

public abstract class Quest : IQuest
{
    public event Action<IQuest> OnCompleted;

    protected IQuestView questView;

    public Quest(IQuestConfig config, IQuestView questView)
    {
        this.questView = questView;
        this.questView.Initialize();
        this.questView.SetDescription(config.Description);
    }

    public abstract void Start();
    public abstract void Stop();

    public virtual void Complete()
    {
        questView.SetCompleted();
        OnCompleted?.Invoke(this);
    }
}
