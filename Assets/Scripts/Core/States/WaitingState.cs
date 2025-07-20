using Core.States;
using UnityEngine;

namespace Core
{
    public class WaitingState : FishingStateBase
    {
        public WaitingState(StatesController controller, FishingActions actions, FishingInput input) 
            : base(controller, actions, input) { }

        public override void Enter()
        {
            FishingEvents.OnBite += OnBite;
            controller.StartBite();
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
