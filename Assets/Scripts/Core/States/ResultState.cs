using Core.States;
using UnityEngine;

namespace Core
{
    public class ResultState : FishingStateBase
    {
        private readonly bool success;

        public ResultState(StatesController controller, FishingActions actions, bool success, FishingInput input) 
            : base(controller, actions, input)
        {
            this.success = success;
        }

        public override void Enter()
        {
            controller.StopMinigame();
            if (success)
                FishingEvents.RaiseOnCatchSuccess();
            else
                FishingEvents.RaiseOnCatchFail();

            actions.ReturnFloat();
            controller.SetState(new IdleState(controller, actions, input));
        }
    }
}
