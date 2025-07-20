using UnityEngine;

namespace InputHandlerSystem
{
    public static class FishingInputHandler
    {
        // ПКМ — заброс
        public static bool IsCastPressed => Input.GetMouseButtonDown(1);

        // ЛКМ — подсечка / ловля
        public static bool IsCatchPressed => Input.GetMouseButtonDown(0);

        public static bool IsRodPulled => Input.GetKey(KeyCode.Space);
    }
}