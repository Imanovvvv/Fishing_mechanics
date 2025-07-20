using BiteSystem;
using Minigame;
using UnityEngine;

namespace FishingStatesSystem
{
    public class StatesController
    {
        private StateBase _currentState;
        private FishingMinigameController _fishingMinigameController;
        private BiteController _biteController;

        public StatesController(FishingMinigameController minigameController, BiteController biteController)
        {
            _fishingMinigameController = minigameController;
            _biteController = biteController;
            _fishingMinigameController.StopMinigame();
        }

        public void StartMinigame()
        {
            _fishingMinigameController.StartMinigame();
        }

        public void StopMinigame()
        {
            _fishingMinigameController.StopMinigame();
        }

        public void StartBite()
        {
            _biteController.StartBiteTimer();
        }

        public void SetState(StateBase newState)
        {
            Debug.Log(newState.GetType().Name);
            newState.Exit();
            _currentState = newState;
            newState.Enter();
        }

        public void UpdateState()
        {
            _currentState.Update();
        }
    }
}