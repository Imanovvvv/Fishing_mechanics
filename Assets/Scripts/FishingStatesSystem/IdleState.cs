using InitializeSystem;
using InputHandlerSystem;
using ProjectSerializebleDataObjects;

namespace FishingStatesSystem
{
    public class IdleState : StateBase
    {
        public IdleState(StatesController controller, FishingActions actions, FishingSettings fishingSettings)
            : base(controller, actions, fishingSettings)
        {
        }

        public override void Enter()
        {
            actions.ReturnFloat();
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