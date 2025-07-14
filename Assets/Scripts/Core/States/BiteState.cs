using UnityEngine;
using System.Collections;

namespace Core
{
    public class BiteState : FishingStateBase
    {
        public BiteState(FishingController controller, FishingActions actions) : base(controller, actions) {}

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
                if (Input.GetMouseButtonDown(0)) // ЛКМ = подсечка
                {
                    controller.SetState(new MinigameState(controller, actions));
                    yield break;
                }

                timer += Time.deltaTime;
                yield return null;
            }

            controller.SetState(new ResultState(controller, actions, success: false));
        }
    }
}
