using UnityEngine;

namespace Core.States
{
    public class StatesController
    {
        private FishingStateBase _currentFishingState;
        private FishingMinigame _fishingMinigame;
        private BiteSystem _biteSystem;

        public StatesController(FishingMinigame minigame, BiteSystem biteSystem)
        {
            _fishingMinigame = minigame;
            _biteSystem = biteSystem;
            _fishingMinigame.StopMinigame();
        }
        
        public void StartMinigame()
        {
            _fishingMinigame.StartMinigame();
        }

        public void StopMinigame()
        {
            _fishingMinigame.StopMinigame();
        }
        
        public void StartBite()
        {
            _biteSystem.StartBiteTimer();
        }
        
        public void SetState(FishingStateBase newState)
        {
            Debug.Log(newState.GetType().Name);
            newState.Exit();
            _currentFishingState = newState;
            newState.Enter();
        }

        public void UpdateState()
        {
            _currentFishingState.Update();
        }
    }
}
