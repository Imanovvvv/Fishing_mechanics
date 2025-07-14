using UnityEngine;

namespace Core
{
    public class FishingController : MonoBehaviour
    {
        private FishingStateBase currentState;

        public FishingActions Actions;
        public FishingInput input;  // Добавляем сюда

        private void Start()
        {
            Actions.Initialize(this);
            SetState(new IdleState(this, Actions, input));
        }

        private void Update()
        {
            currentState?.Update();
        }

        public void SetState(FishingStateBase newState)
        {
            currentState?.Exit();
            currentState = newState;
            currentState?.Enter();
        }
    }
}
