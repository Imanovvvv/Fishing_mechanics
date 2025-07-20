using BiteSystem;
using Minigame;
using ProjectSerializebleDataObjects;
using UnityEngine;

namespace FishingStatesSystem
{
    public class StatesController
    {
        private StateBase _currentState;
        private FishingMinigameController _fishingMinigameController;
        private BiteController _biteController;
        private FishingSettings _fishingSettings;

        public StatesController(FishingMinigameController minigameController, BiteController biteController, FishingSettings fishingSettings)
        {
            _fishingMinigameController = minigameController;
            _biteController = biteController;
            _fishingSettings = fishingSettings;
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
            _biteController.BiteRiseAwaiter(_fishingSettings.biteDelayMin, _fishingSettings.biteDelayMax);
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