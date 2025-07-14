using UnityEngine;
using System.Collections;


namespace Core
{
    public class CastingState : FishingStateBase
    {
        public CastingState(FishingController controller, FishingActions actions) : base(controller, actions) {}

        public override void Enter()
        {
            actions.Cast();
            actions.StartCoroutine(CastingDelay());
        }

        private IEnumerator CastingDelay()
        {
            yield return new WaitForSeconds(1.5f);
            controller.SetState(new WaitingState(controller, actions));
        }
    }
}
