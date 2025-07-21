using System.Collections.Generic;
using BiteSystem;
using InitializeSystem;
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
        private FishingActions _fishingActions;
        
        private bool _isResultSuccess;
        private Dictionary<FishingStates,StateBase> _states;

        public StatesController(FishingMinigameController minigameController, BiteController biteController, FishingSettings fishingSettings,
            FishingActions fishingActions)
        {
            _fishingMinigameController = minigameController;
            _biteController = biteController;
            _fishingSettings = fishingSettings;
            _fishingActions = fishingActions;
            _fishingMinigameController.StopMinigame();
            _states = new Dictionary<FishingStates, StateBase>();
            _states.Add(FishingStates.Idle, new IdleState(this, _fishingActions, _fishingSettings));
            _states.Add(FishingStates.Casting, new CastingState(this, _fishingActions, _fishingSettings));
            _states.Add(FishingStates.Waiting, new WaitingState(this, _fishingActions, _fishingSettings));
            _states.Add(FishingStates.Bite, new BiteState(this, _fishingActions, _fishingSettings));
            _states.Add(FishingStates.Holding, new HoldingState(this, _fishingActions, _fishingSettings));
            _states.Add(FishingStates.Minigame, new MinigameState(this, _fishingActions, _fishingSettings));
            _states.Add(FishingStates.Result, new ResultState(this, _fishingActions, _fishingSettings));
            _currentState = _states[FishingStates.Idle];
        }

        public bool GetResultSuccessAndReset(bool success)
        {
            bool previousResult = _isResultSuccess;
            _isResultSuccess = success;
            return previousResult;
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
        
        public void SetState(FishingStates newState)
        {
            Debug.Log(newState);
            _currentState.Exit();
            _currentState = _states[newState];
            _currentState.Enter();
        }

        public void UpdateState()
        {
            _currentState.Update();
        }
    }
}