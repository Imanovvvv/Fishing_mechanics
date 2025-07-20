using BiteSystem;
using FishingStatesSystem;
using InputHandlerSystem;
using Minigame;
using Settings;
using UnityEngine;

namespace InitializeSystem
{
    public class FishingController : MonoBehaviour
    {
        public FishingActions Actions;
        public FishingMinigameController MinigameController;
        public BiteController BiteController;
        public FishingSettings FishingSettings;
        
        private StatesController _stateController;

        private void Start()
        {
            _stateController = new StatesController(MinigameController, BiteController);
            Actions.Initialize(this);
            _stateController.SetState(new IdleState(_stateController, Actions, FishingSettings));
        }

        private void Update()
        {
            _stateController.UpdateState();
            if (FishingInputHandler.IsCastPressed)
                Debug.Log("ПКМ нажата");
        }
    }
}
