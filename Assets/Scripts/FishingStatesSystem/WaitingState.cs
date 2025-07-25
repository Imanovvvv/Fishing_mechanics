using Events;
using InitializeSystem;
using ProjectSerializebleDataObjects;

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
            controller.SetState(FishingStates.Bite);
        }
    }
}