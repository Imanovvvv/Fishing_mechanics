using System.Collections;
using InitializeSystem;
using ProjectSerializebleDataObjects;
using UnityEngine;

namespace FishingStatesSystem
{
    public class MinigameState : StateBase
    {
        public MinigameState(StatesController controller, FishingActions actions, FishingSettings fishingSettings)
            : base(controller, actions, fishingSettings)
        {
        }

        public override void Enter()
        {
            controller.StartMinigame();
            actions.StartCoroutine(PlayMinigame());
        }

        private IEnumerator PlayMinigame()
        {
            float elapsed = 0f;

            while (elapsed < fishingSettings.MinigameDuration)
            {
                elapsed += Time.deltaTime;
                yield return null;
            }

            bool isSuccess = true; // Можно потом сделать логику успеха с input
            controller.GetResultSuccessAndReset(isSuccess);
            controller.SetState(FishingStates.Result);
        }
    }
}