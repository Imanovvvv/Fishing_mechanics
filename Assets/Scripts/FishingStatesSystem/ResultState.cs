using Events;
using InitializeSystem;
using ProjectSerializebleDataObjects;

namespace FishingStatesSystem
{
    public class ResultState : StateBase
    {

        public ResultState(StatesController controller, FishingActions actions, FishingSettings fishingSettings)
            : base(controller, actions, fishingSettings)
        {
        }

        public override void Enter()
        {
            controller.StopMinigame();
            if (controller.GetResultSuccessAndReset(false))
                FishingEventsBank.RaiseOnCatchSuccess();
            else
                FishingEventsBank.RaiseOnCatchFail();

            actions.ReturnFloat();
            controller.SetState(FishingStates.Idle);
        }
    }
}