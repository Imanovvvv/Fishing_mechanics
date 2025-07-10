using UnityEngine;

public class FloatController : MonoBehaviour
{
    public float bobSpeed = 2f;
    public float bobAmount = 0.1f;

    private Vector3 startPos;

    void Start()
    {
        startPos = transform.position;
    }

    void Update()
    {
        // Простое покачивание вверх-вниз
        transform.position = startPos + new Vector3(0, Mathf.Sin(Time.time * bobSpeed) * bobAmount, 0);
    }

    public void OnFishBite()
    {
        // Реакция на поклёвку — кратковременное погружение
        transform.position -= new Vector3(0, 0.2f, 0);
    }
}
