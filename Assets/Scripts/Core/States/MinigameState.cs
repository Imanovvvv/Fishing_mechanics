using UnityEngine;
using System.Collections;
using Core.States;

namespace Core
{
    public class MinigameState : FishingStateBase
    {
        public MinigameState(StatesController controller, FishingActions actions, FishingInput input) 
            : base(controller, actions, input) { }

        public override void Enter()
        {
            controller.StartMinigame();
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

            bool isSuccess = true; // Можно потом сделать логику успеха с input
            controller.SetState(new ResultState(controller, actions, isSuccess, input));
        }
    }
}