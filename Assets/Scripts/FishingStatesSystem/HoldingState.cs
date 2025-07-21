using InitializeSystem;
using InputHandlerSystem;
using ProjectSerializebleDataObjects;

namespace FishingStatesSystem
{
    public class HoldingState : StateBase
    {
        public HoldingState(StatesController controller, FishingActions actions, FishingSettings fishingSettings)
            : base(controller, actions, fishingSettings)
        {
        }

        public override void Update()
        {
            if (FishingInputHandler.IsCastPressed)
            {
                controller.SetState(FishingStates.Casting);
            }
        }
    }
}