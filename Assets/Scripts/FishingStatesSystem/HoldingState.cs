using InitializeSystem;
using InputHandlerSystem;
using Settings;

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
                controller.SetState(new CastingState(controller, actions, fishingSettings));
            }
        }
    }
}