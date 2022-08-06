using UnityEngine;

public class PlayState : IState
{
    public void Handle()
    {
        Time.timeScale = 1f;
        Debug.Log("PlayState");
    }
}
