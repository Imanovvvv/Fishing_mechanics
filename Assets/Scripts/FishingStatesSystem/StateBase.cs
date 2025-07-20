using InitializeSystem;
using Settings;

namespace FishingStatesSystem
{
    public abstract class StateBase
    {
        protected StatesController controller;
        protected FishingActions actions;
        protected FishingSettings fishingSettings;

        protected StateBase(StatesController controller, FishingActions actions, FishingSettings fishingSettings)
        {
            this.controller = controller;
            this.actions = actions;
            this.fishingSettings = fishingSettings;
        }

        public virtual void Enter()
        {
        }

        public virtual void Update()
        {
        }

        public virtual void Exit()
        {
        }
    }
}