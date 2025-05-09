
namespace Quest
{
    public abstract class QuestModel
    {
        public string Description { get; }

        public QuestModel(IQuestConfig config)
        {
            Description = config.Description;
        }
    }

    public abstract class QuestController<TModel> : IQuestController 
        where TModel: QuestModel
    {
        protected readonly TModel questModel;
        protected readonly IQuestView questView;

        public QuestController(TModel questModel, IQuestView questView)
        {
            this.questModel = questModel;
            this.questView = questView;

            this.questView.Initialize();
            this.questView.SetDescription(this.questModel.Description);
        }

        public abstract void Start();
        public abstract void Stop();

        public void Complete()
        {
            questView.SetCompleted();
        }
    }
}
