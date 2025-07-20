using Events;
using FloaterSystem;
using UnityEngine;
using UnityEngine.Serialization;

namespace InitializeSystem
{
    public class FishingActions : MonoBehaviour
    {
        [FormerlySerializedAs("floatController")] [Header("References")]
        public FloaterController floaterController;

        [HideInInspector] public FishingController Controller;

        public void Initialize(FishingController controller)
        {
            Controller = controller;
            floaterController.SetInitialPosition();
        }

        public void Cast()
        {
            Debug.Log("Cast called");
            floaterController.MoveToWater();
            FishingEventsBank.RaiseOnCast();
        }

        public void ReturnFloat()
        {
            floaterController.MoveToHand();
        }
    }
}
