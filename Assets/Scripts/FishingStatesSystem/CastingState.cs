using System.Collections;
using InitializeSystem;
using Settings;
using UnityEngine;

namespace FishingStatesSystem
{
    public class CastingState : StateBase
    {
        public CastingState(StatesController controller, FishingActions actions, FishingSettings fishingSettings)
            : base(controller, actions, fishingSettings)
        {
        }

        public override void Enter()
        {
            actions.Cast();
            actions.StartCoroutine(CastingDelay());
        }

        private IEnumerator CastingDelay()
        {
            yield return new WaitForSeconds(fishingSettings.CastingDelayTime);
            controller.SetState(new WaitingState(controller, actions, fishingSettings));
        }
    }
}