using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class FishingMinigame : MonoBehaviour
{
    [SerializeField] private GameObject minigameUI;
    [SerializeField] private Slider progressBar;
    [SerializeField] private float fillSpeed = 0.5f;
    [SerializeField] private float drainSpeed = 0.3f;
    [SerializeField] private float targetValue = 1f;

    private bool isPlaying;
    private Coroutine fillCoroutine;

    public void StartMinigame()
    {
        minigameUI.SetActive(true);
        progressBar.value = 0f;
        isPlaying = true;

        if (fillCoroutine != null)
            StopCoroutine(fillCoroutine);

        fillCoroutine = StartCoroutine(UpdateProgress());
    }

    public void StopMinigame()
    {
        isPlaying = false;

        if (fillCoroutine != null)
            StopCoroutine(fillCoroutine);

        minigameUI.SetActive(false);
    }

    private IEnumerator UpdateProgress()
    {
        while (isPlaying)
        {
            if (Input.GetKey(KeyCode.Space))
            {
                progressBar.value += fillSpeed * Time.deltaTime;
            }
            else
            {
                progressBar.value -= drainSpeed * Time.deltaTime;
            }

            progressBar.value = Mathf.Clamp01(progressBar.value);

            if (progressBar.value >= targetValue)
            {
                FishingEvents.RaiseOnCatchSuccess();
                StopMinigame();
                yield break;
            }

            yield return null;
        }
    }
}
