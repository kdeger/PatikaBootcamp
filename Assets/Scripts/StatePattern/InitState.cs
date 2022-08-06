using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class InitState : IState
{
    public void Handle()
    {
        Debug.Log("InitState");
        LoadLevel();
    }

    void LoadLevel()
    {
        SceneManager.LoadScene("LevelScene");
    }
}
