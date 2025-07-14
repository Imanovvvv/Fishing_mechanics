using UnityEngine;

namespace Core
{
    public class FishingController : MonoBehaviour
    {
        public FishingInput input;

        private FishingStateBase currentState;

        public FishingActions Actions;

        private void Start()
        {
            Actions.Initialize(this);

            SetState(new IdleState(this, Actions));
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
