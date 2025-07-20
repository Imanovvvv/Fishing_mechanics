using UnityEngine;
using System.Collections;
using Core.States;

namespace Core
{
    public class BiteState : FishingStateBase
    {
        public BiteState(StatesController controller, FishingActions actions, FishingInput input) 
            : base(controller, actions, input) { }

        public override void Enter()
        {
            actions.StartCoroutine(BiteWindow());
        }

        private IEnumerator BiteWindow()
        {
            float waitTime = 1.5f;
            float timer = 0f;

            while (timer < waitTime)
            {
                if (input.IsCatchPressed) // Используем input здесь
                {
                    controller.SetState(new MinigameState(controller, actions, input));
                    yield break;
                }

                timer += Time.deltaTime;
                yield return null;
            }

            controller.SetState(new ResultState(controller, actions, false, input));
        }
    }
}
