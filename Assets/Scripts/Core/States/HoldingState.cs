namespace Core
{
    public class HoldingState : FishingStateBase
    {
        public HoldingState(FishingController controller, FishingActions actions, FishingInput input) 
            : base(controller, actions, input) { }

        public override void Update()
        {
            if (input.IsCastPressed)
            {
                controller.SetState(new CastingState(controller, actions, input));
            }
        }
    }
}
