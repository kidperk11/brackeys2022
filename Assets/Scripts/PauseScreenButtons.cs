using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseScreenButtons : MonoBehaviour
{
    public PauseSystem pauseSystem;

    public void ContinueGame()
    {
        pauseSystem.ResumeGame();
    }

    public void ExitGame()
    {
        print("Test");
        Application.Quit();
        UnityEditor.EditorApplication.isPlaying = false;
    }

}
