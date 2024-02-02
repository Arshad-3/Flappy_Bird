using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseControl : MonoBehaviour
{
    public static bool ispaused;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            ispaused = !ispaused;
            pauseGame();
        }
    }
    void pauseGame()
    {
        if (ispaused)
            Time.timeScale = 0;
        else
            Time.timeScale = 1;
    }

}
