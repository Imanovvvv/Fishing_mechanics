using UnityEngine;
using UnityEngine.Serialization;

namespace FloaterSystem
{
    public class FloaterSway : MonoBehaviour
    {
        [SerializeField] private float swayAmount = 0.1f;
        [SerializeField] private float swaySpeed = 2f;
        [FormerlySerializedAs("floatController")] [SerializeField] private FloaterController floaterController;

        private Vector3 startPos;

        private void Start()
        {
            startPos = transform.localPosition;
        }

        private void Update()
        {
            if (floaterController.IsInWater)
            {
                float sway = Mathf.Sin(Time.time * swaySpeed) * swayAmount;
                transform.localPosition = startPos + new Vector3(0, sway, 0);
            }
        }
    }
}
