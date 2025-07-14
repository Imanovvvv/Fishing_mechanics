using UnityEngine;

namespace Core
{
    public class WaitingState : FishingStateBase
    {
        public WaitingState(FishingController controller, FishingActions actions, FishingInput input) 
            : base(controller, actions, input) { }

        public override void Enter()
        {
            FishingEvents.OnBite += OnBite;
        }

        public override void Exit()
        {
            FishingEvents.OnBite -= OnBite;
        }

        private void OnBite()
        {
            controller.SetState(new BiteState(controller, actions, input));
        }
    }
}
