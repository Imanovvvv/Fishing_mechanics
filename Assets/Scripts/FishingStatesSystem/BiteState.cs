using System.Collections;
using InitializeSystem;
using InputHandlerSystem;
using ProjectSerializebleDataObjects;
using UnityEngine;

namespace FishingStatesSystem
{
    public class BiteState : StateBase
    {
        public BiteState(StatesController controller, FishingActions actions, FishingSettings fishingSettings)
            : base(controller, actions, fishingSettings)
        {
        }

        public override void Enter()
        {
            actions.StartCoroutine(BiteWindow());
        }

        private IEnumerator BiteWindow()
        {
            float waitTime = 1.5f;
            float timer = 0f;

            while (timer < fishingSettings.FishingFightTime)
            {
                if (FishingInputHandler.IsCatchPressed) // Используем input здесь
                {
                    controller.SetState(new MinigameState(controller, actions, fishingSettings));
                    yield break;
                }

                timer += Time.deltaTime;
                yield return null;
            }

            controller.SetState(new ResultState(controller, actions, false, fishingSettings));
        }
    }
}