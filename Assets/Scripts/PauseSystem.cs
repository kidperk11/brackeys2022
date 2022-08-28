using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseSystem : MonoBehaviour
{
    private static bool isPaused;

    private void Awake()
    {
        isPaused = false;
    }

    public void PauseGame()
    {
        Time.timeScale = 0f;
        AudioListener.pause = true;
        isPaused = true;
    }
    public void ResumeGame()
    {
        Time.timeScale = 1;
        AudioListener.pause = false;
        isPaused = true;
    }

    public void TogglePause()
    {
        if (isPaused)
            ResumeGame();
        else
            PauseGame();
        
    }

    public void TestPause()
    {
        print("TestPause");
    }
}
