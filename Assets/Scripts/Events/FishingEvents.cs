using System;

public static class FishingEvents
{
    public static event Action OnCast;
    public static event Action OnBite;
    public static event Action OnCatchSuccess;
    public static event Action OnCatchFail;

    public static void RaiseOnCast()
    {
        OnCast?.Invoke();
    }

    public static void RaiseOnBite()
    {
        OnBite?.Invoke();
    }

    public static void RaiseOnCatchSuccess()
    {
        OnCatchSuccess?.Invoke();
    }

    public static void RaiseOnCatchFail()
    {
        OnCatchFail?.Invoke();
    }
}
