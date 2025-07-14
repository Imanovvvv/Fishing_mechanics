namespace Core
{
    public abstract class FishingStateBase
    {
        protected FishingController controller;
        protected FishingActions actions;
        protected FishingInput input;  // Добавляем ссылку на input

        protected FishingStateBase(FishingController controller, FishingActions actions, FishingInput input)
        {
            this.controller = controller;
            this.actions = actions;
            this.input = input;
        }

        public virtual void Enter() { }
        public virtual void Update() { }
        public virtual void Exit() { }
    }
}
