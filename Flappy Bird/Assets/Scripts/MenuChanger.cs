using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuChanger : MonoBehaviour
{
    // Start is called before the first frame update
    public void playgame()
    {
        SceneManager.LoadScene("Gameplay");
    }

    public void MainMenu()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - 1);
    }
}
