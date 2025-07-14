using UnityEngine;
using System.Collections;

namespace Core
{
    public class MinigameState : FishingStateBase
    {
        public MinigameState(FishingController controller, FishingActions actions) : base(controller, actions) {}

        public override void Enter()
        {
            actions.StartCoroutine(PlayMinigame());
        }

        private IEnumerator PlayMinigame()
        {
            float duration = 2f;
            float elapsed = 0f;

            while (elapsed < duration)
            {
                elapsed += Time.deltaTime;
                yield return null;
            }

            bool isSuccess = true; // Здесь можно вставить логику успеха
            controller.SetState(new ResultState(controller, actions, isSuccess));
        }
    }
}
