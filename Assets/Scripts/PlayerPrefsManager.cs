using UnityEngine;

public static class PlayerPrefsManager
{
    public const string LEVEL_KEY = "Level";
    public const string LAST_OPENED_LEVEL_KEY = "LastOpenedLevel";
    public static int LastOpenedLevel
    {
        get
        {
            return PlayerPrefs.GetInt(LAST_OPENED_LEVEL_KEY, 1);
        }
        set
        {
            PlayerPrefs.SetInt(LAST_OPENED_LEVEL_KEY, value);
        }
    }

    public static void SetLevelStar(int level, int levelStart)
    {
        PlayerPrefs.SetInt(LEVEL_KEY + level, levelStart);
    }

    public static int GetLevelStar(int level)
    {
        return PlayerPrefs.GetInt(LEVEL_KEY + level);
    }
}
