using UnityEngine;

public static class CustomLogger
{
    public static void Log(string message)
    {
#if CUSTOM_LOGGER
        Debug.Log("Custom Log: " + message);
#endif
    }
}