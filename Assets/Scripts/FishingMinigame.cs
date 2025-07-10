using UnityEngine;
using UnityEngine.UI;

public class FishingMinigame : MonoBehaviour
{
    public Slider slider;
    public float fillSpeed = 0.5f;
    public FishingManager manager;

    private float progress = 0f;

    void Start()
    {
        slider.gameObject.SetActive(false); // скрываем слайдер в начале
    }

    public void StartMinigame()
    {
        slider.gameObject.SetActive(true); 
        slider.value = 0f;
        progress = 0f;
    }

    void Update() {
        if (manager.currentState != FishingState.Minigame) return;

        if (Input.GetMouseButton(0)) {
            progress += fillSpeed * Time.deltaTime;
            slider.value = progress;
        }

        if (progress >= 1f) {
            slider.gameObject.SetActive(false);
            manager.CompleteCatch();
        }
    }
}
