using UnityEngine;
using Float;

namespace Core
{
    public class FishingActions : MonoBehaviour
    {
        [Header("References")]
        public FloatController floatController;

        [HideInInspector] public FishingController Controller;

        public void Initialize(FishingController controller)
        {
            Controller = controller;
            floatController.SetInitialPosition();
        }

        public void Cast()
        {
            floatController.MoveToWater();
            FishingEvents.RaiseOnCast();
        }

        public void ReturnFloat()
        {
            floatController.MoveToHand();
        }
    }
}
