using UnityEngine;
using Float;
public class FloatSway : MonoBehaviour
{
    [SerializeField] private float swayAmount = 0.1f;
    [SerializeField] private float swaySpeed = 2f;
    [SerializeField] private FloatController floatController;

    private Vector3 startPos;

    private void Start()
    {
        startPos = transform.localPosition;
    }

    private void Update()
    {
        if (floatController.IsInWater)
        {
            float sway = Mathf.Sin(Time.time * swaySpeed) * swayAmount;
            transform.localPosition = startPos + new Vector3(0, sway, 0);
        }
    }
}
