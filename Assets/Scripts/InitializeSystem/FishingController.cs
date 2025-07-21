using BiteSystem;
using FishingStatesSystem;
using InputHandlerSystem;
using Minigame;
using ProjectSerializebleDataObjects;
using UnityEngine;

namespace InitializeSystem
{
    public class FishingController : MonoBehaviour
    {
        public FishingActions Actions;
        public FishingMinigameController MinigameController;
        public FishingSettings FishingSettings;
        
        private BiteController _biteController;
        private StatesController _stateController;

        private void Start()
        {
            _biteController = new BiteController();
            _stateController = new StatesController(MinigameController, _biteController, FishingSettings, Actions);
            Actions.Initialize(this);
            _stateController.SetState(FishingStates.Idle);
        }

        private void Update()
        {
            _stateController.UpdateState();
            if (FishingInputHandler.IsCastPressed)
                Debug.Log("ПКМ нажата");
        }
    }
}
