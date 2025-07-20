using UnityEngine;

namespace FloaterSystem
{
    public class FloaterController : MonoBehaviour
    {
        [SerializeField] private Transform holdPoint;   // Точка в руке
        [SerializeField] private Transform waterPoint;  // Точка на воде

        [SerializeField] private float moveSpeed = 5f;

        private bool isMoving = false;
        private Vector3 targetPosition;

        private void Update()
        {
            if (isMoving)
            {
                transform.position = Vector3.MoveTowards(transform.position, targetPosition, moveSpeed * Time.deltaTime);

                if (Vector3.Distance(transform.position, targetPosition) < 0.01f)
                {
                    transform.position = targetPosition;
                    isMoving = false;
                }
            }
        }

        public void SetInitialPosition()
        {
            transform.position = holdPoint.position;
        }

        public void MoveToWater()
        {
            targetPosition = waterPoint.position;
            isMoving = true;
        }

        public void MoveToHand()
        {
            targetPosition = holdPoint.position;
            isMoving = true;
        }
        public bool IsInWater => !isMoving && Vector3.Distance(transform.position, waterPoint.position) < 0.1f;
    }
}
