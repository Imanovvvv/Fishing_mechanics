
namespace Core
{
    public abstract class FishingStateBase
    {
        protected FishingController controller;
        protected FishingActions actions;

        protected FishingStateBase(FishingController controller, FishingActions actions)
        {
            this.controller = controller;
            this.actions = actions;
        }

        public virtual void Enter() { }
        public virtual void Update() { }
        public virtual void Exit() { }
    }
}
