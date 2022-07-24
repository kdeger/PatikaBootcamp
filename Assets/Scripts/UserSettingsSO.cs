using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Settings", menuName = "Scriptable Objects/Settings/User Settings", order = 1)]
public class UserSettingsSO : ScriptableObject
{
    public UserSettings UserSettings;
}

[System.Serializable]
public class UserSettings
{
    public AudioSettings AudioSettings;
    public GraphicsSettings GraphicsSettings;
    public ControllerSettings ControllerSettings;
    public PlayerSettings PlayerSettings;
}

[System.Serializable]
public class AudioSettings
{
    public int MasterVolume;
    public int MusicVolume;
    public int SoundVolume;
}

[System.Serializable]
public class GraphicsSettings
{
    public string Language;
    public bool SubtitleOn;
    public bool Fullscreen;
    public float Fov;
    public float Gamma;
    public float Brightness;
}

[System.Serializable]
public class ControllerSettings
{
    public float MouseSensitivity;
    public bool InvertY;
    public bool InvertX;
}

[System.Serializable]
public class PlayerSettings
{
    public string PlayerName;
    public int PlayerLevel;
    public int PlayerExperience;
    public int PlayerHealth;
    public int PlayerMaxHealth;
    public int PlayerMana;
    public int PlayerMaxMana;

    public List<int> LevelStars;

}
