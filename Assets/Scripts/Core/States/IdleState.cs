
namespace Core

{
    public class IdleState : FishingStateBase
    {
        public IdleState(FishingController controller, FishingActions actions) : base(controller, actions) { }

        public override void Enter()
        {
            actions.ReturnFloat();
        }

        public override void Update()
        {
            // Переход в HoldingState выполняется через Input, подписку можно реализовать через события
        }
    }
}
