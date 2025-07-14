
using UnityEngine;

namespace Core
{
    public class ResultState : FishingStateBase
    {
        private readonly bool success;

        public ResultState(FishingController controller, FishingActions actions, bool success) : base(controller, actions)
        {
            this.success = success;
        }

        public override void Enter()
        {
            if (success)
                FishingEvents.RaiseOnCatchSuccess();
            else
                FishingEvents.RaiseOnCatchFail();

            actions.ReturnFloat();
            controller.SetState(new IdleState(controller, actions));
        }
    }
}
