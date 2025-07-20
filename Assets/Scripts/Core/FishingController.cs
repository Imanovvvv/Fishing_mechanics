using Core.States;
using UnityEngine;

namespace Core
{
    public class FishingController : MonoBehaviour
    {
        private FishingStateBase currentState;

        public FishingActions Actions;
        public FishingInput input;  // Добавляем сюда
        public FishingMinigame Minigame;
        public BiteSystem BiteSystem;
        
        private StatesController _stateController;

        private void Start()
        {
            _stateController = new StatesController(Minigame, BiteSystem);
            Actions.Initialize(this);
            _stateController.SetState(new IdleState(_stateController, Actions, input));
        }

        private void Update()
        {
            _stateController.UpdateState();
            if (input.IsCastPressed)
                Debug.Log("ПКМ нажата");
        }
    }
}
