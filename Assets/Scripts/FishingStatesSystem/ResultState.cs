using Events;
using InitializeSystem;
using Settings;

namespace FishingStatesSystem
{
    public class ResultState : StateBase
    {
        private readonly bool _success;

        public ResultState(StatesController controller, FishingActions actions, bool success, FishingSettings fishingSettings)
            : base(controller, actions, fishingSettings)
        {
            _success = success;
        }

        public override void Enter()
        {
            controller.StopMinigame();
            if (_success)
                FishingEventsBank.RaiseOnCatchSuccess();
            else
                FishingEventsBank.RaiseOnCatchFail();

            actions.ReturnFloat();
            controller.SetState(new IdleState(controller, actions, fishingSettings));
        }
    }
}