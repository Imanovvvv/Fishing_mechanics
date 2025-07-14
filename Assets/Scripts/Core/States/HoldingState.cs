
namespace Core
{
    public class HoldingState : FishingStateBase
    {
        public HoldingState(FishingController controller, FishingActions actions) : base(controller, actions) { }

        public override void Enter()
        {
            // Держим поплавок в руке
        }

        public override void Update()
        {
            // Ожидаем заброса (ПКМ) -> переход в CastingState
        }
    }
}
