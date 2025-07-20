using System.Collections;
using Events;
using InputHandlerSystem;
using UnityEngine;
using UnityEngine.UI;

namespace Minigame
{
    public class FishingMinigameController : MonoBehaviour
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
                if (FishingInputHandler.IsRodPulled)
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
                    FishingEventsBank.RaiseOnCatchSuccess();
                    StopMinigame();
                    yield break;
                }

                yield return null;
            }
        }
    }
}