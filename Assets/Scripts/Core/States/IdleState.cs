using Core.States;

namespace Core
{
    public class IdleState : FishingStateBase
    {
        public IdleState(StatesController controller, FishingActions actions, FishingInput input) 
            : base(controller, actions, input) { }

        public override void Enter()
        {
            actions.ReturnFloat();
        }

        public override void Update()
        {
            if (input.IsCastPressed)
            {
                controller.SetState(new CastingState(controller, actions, input));
            }
        }
    }
}
