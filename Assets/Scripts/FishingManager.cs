using UnityEngine;
public enum FishingState {
    Idle,
    Holding,
    Casting,
    Waiting,
    Bite,
    Minigame,
    Result
}

public class FishingManager : MonoBehaviour
{
    public GameObject floatPrefab;
    public Transform floatHoldPoint;
    public Transform cameraTransform;
    public FishingMinigame minigame;

    public FishingState currentState = FishingState.Idle;
    private GameObject currentFloat;
    private GameObject castedFloat;


    private float biteTimer;
    private float biteTime;

    void Start()
    {
        SpawnFloatInHand();
        Debug.Log("Нажми ЛКМ по воде, чтобы закинуть удочку");
    }

    void Update()
    {
        switch (currentState)
        {
            case FishingState.Waiting:
                UpdateWaiting();
                break;
            case FishingState.Bite:
                UpdateBite();
                break;
        }

        if (Input.GetMouseButtonDown(0) && currentState == FishingState.Holding)
        {
            TryCast();
        }

        if (Input.GetMouseButtonDown(1) && currentState == FishingState.Bite)
        {
            StartMinigame(); // Подсёк
        }
    }

    void SpawnFloatInHand()
    {
        currentFloat = Instantiate(floatPrefab, floatHoldPoint.position, floatHoldPoint.rotation);
        currentFloat.transform.SetParent(floatHoldPoint);
        currentState = FishingState.Holding;
    }

    void TryCast()
    {
        Ray ray = cameraTransform.GetComponent<Camera>().ScreenPointToRay(Input.mousePosition);
        if (Physics.Raycast(ray, out RaycastHit hit, 100f))
        {
            if (hit.collider.CompareTag("Water"))
            {
                CastFloat(hit.point);
            }
        }
    }

    void CastFloat(Vector3 targetPosition)
{
    // Убираем поплавок из руки
    currentFloat.SetActive(false);

    // Создаём новый поплавок в воде
    castedFloat = Instantiate(floatPrefab, targetPosition + new Vector3(0, 0.2f, 0), Quaternion.identity);

    // Animator anim = castedFloat.GetComponent<Animator>();
    // if (anim != null) anim.SetTrigger("Splash");

    currentState = FishingState.Waiting;
    biteTime = Random.Range(3f, 6f);
    biteTimer = 0f;
    Debug.Log("Ожидание поклёвки...");
}


    void UpdateWaiting()
    {
        biteTimer += Time.deltaTime;
        if (biteTimer >= biteTime)
        {
            currentState = FishingState.Bite;
            biteTimer = 0f;
            biteTime = 2f;
            Debug.Log("Нажми ПКМ, чтобы подсечь");
        }
    }

    void UpdateBite()
{
    biteTimer += Time.deltaTime;
    if (biteTimer >= biteTime)
    {
        FailCatch(); // Не успел подсечь
    }
}


public void StartMinigame()
{
    Debug.Log("StartMinigame() вызван в FishingManager");

    currentState = FishingState.Minigame;
    if (minigame != null)
    {
        Debug.Log("Вызываем StartMinigame() в FishingMinigame");
        minigame.StartMinigame();
    }
    else
    {
        Debug.LogWarning("minigame == null!");
    }
}

    public void CompleteCatch()
{
    currentState = FishingState.Result;
    Debug.Log("Ты поймал рыбу!");
    if (castedFloat != null)
        Destroy(castedFloat);
    Invoke(nameof(ResetFishing), 2f);
}

void FailCatch()
{
    currentState = FishingState.Result;
    Debug.Log("Рыба сорвалась.");
    if (castedFloat != null)
        Destroy(castedFloat);
    Invoke(nameof(ResetFishing), 2f);
}


    void ResetFishing()
    {
        Destroy(currentFloat);
        currentFloat = null;
        SpawnFloatInHand();
    }
}


