using System.Collections.Generic;
using UnityEngine;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

public class SettingsController : MonoBehaviour
{
    public static SettingsController Instance;
    public UserSettingsSO _userSettingsSO;

    public static event System.Action<UserSettings> OnDataLoadeded;

    //public static UserSettings UserSettings { get; private set; }

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
            return;
        }

        OnDataLoadeded += OnLoad;
        LoadSettings();
    }

    [ContextMenu("Save")]
    public void SaveSettings()
    {
        string saveDirectory = Application.persistentDataPath + "/Resources";
        _userSettingsSO.UserSettings.PlayerSettings.LevelStars = new List<int>();
        for (int i = 0; i < 5000; i++)
        {
            _userSettingsSO.UserSettings.PlayerSettings.LevelStars.Add(3);
        }
        string settingsJsonData = JsonUtility.ToJson(_userSettingsSO.UserSettings, true);
        //settingsJsonData = EncryptionTool.EncryptString(settingsJsonData);
        Debug.Log(saveDirectory);
        if (!File.Exists(saveDirectory + "/userSettings.json"))
        {
            Directory.CreateDirectory(saveDirectory);
        }
        StreamWriter streamWriter = new StreamWriter(saveDirectory + "/userSettings.json");
        streamWriter.Write(settingsJsonData);
        streamWriter.Close();
    }

    void OnLoad(UserSettings userSettings)
    {
        Debug.Log("Loaded");
    }

    [ContextMenu("Load")]
    public void LoadSettings()
    {
        string saveDirectory = Application.persistentDataPath + "/Resources";
        if (!File.Exists(saveDirectory + "/userSettings.json"))
        {
            return;
        }

        StreamReader streamReader = new StreamReader(saveDirectory + "/userSettings.json");
        string settingsJsonData = streamReader.ReadToEnd();
        //settingsJsonData = EncryptionTool.DecryptString(settingsJsonData);
        streamReader.Close();
        UserSettings userSettings = JsonUtility.FromJson<UserSettings>(settingsJsonData);
        _userSettingsSO.UserSettings = userSettings;
        OnDataLoadeded?.Invoke(userSettings);
    }

    private void OnDestroy()
    {
        if (Instance == this)
            Debug.Log("Destroyed");
    }

}
