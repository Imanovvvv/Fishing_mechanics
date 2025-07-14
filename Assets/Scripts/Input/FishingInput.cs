using UnityEngine;

public class FishingInput : MonoBehaviour
{
    // ПКМ — заброс
    public bool IsCastPressed => Input.GetMouseButtonDown(1);

    // ЛКМ — подсечка / ловля
    public bool IsCatchPressed => Input.GetMouseButtonDown(0);
}
