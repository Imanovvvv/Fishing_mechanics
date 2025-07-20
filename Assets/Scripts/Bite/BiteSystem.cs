using UnityEngine;
using System.Collections;

public class BiteSystem : MonoBehaviour
{
    [SerializeField] private float minBiteTime = 1.5f;
    [SerializeField] private float maxBiteTime = 4f;

    private Coroutine biteCoroutine;

    public void StartBiteTimer()
    {
        StopBiteTimer();
        biteCoroutine = StartCoroutine(BiteCoroutine());
    }

    public void StopBiteTimer()
    {
        if (biteCoroutine != null)
        {
            StopCoroutine(biteCoroutine);
            biteCoroutine = null;
        }
    }

    private IEnumerator BiteCoroutine()
    {
        float waitTime = Random.Range(minBiteTime, maxBiteTime);
        yield return new WaitForSeconds(waitTime);
        FishingEvents.RaiseOnBite();
    }
}