using Events;
using InitializeSystem;
using Settings;

namespace FishingStatesSystem
{
    public class WaitingState : StateBase
    {
        public WaitingState(StatesController controller, FishingActions actions, FishingSettings fishingSettings)
            : base(controller, actions, fishingSettings)
        {
        }

        public override void Enter()
        {
            FishingEventsBank.OnBite += OnBite;
            controller.StartBite();
        }

        public override void Exit()
        {
            FishingEventsBank.OnBite -= OnBite;
        }

        private void OnBite()
        {
            controller.SetState(new BiteState(controller, actions, fishingSettings));
        }
    }
}