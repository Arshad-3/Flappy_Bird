using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    
    private int score;
    private int highscore;
    public int Score
    {
        get { return score; }
        set { score = value; }
    }
    public int HighScore
    {
        get { return highscore; }
        set { highscore = value; }
    }

    // Update is called once per frame
    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            //instance.HighScore = this.HighScore;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    private void OnEnable()
    {
        SceneManager.sceneLoaded += OnLevelFinishLoading;
    }
    private void OnDisable()
    {
        SceneManager.sceneLoaded -= OnLevelFinishLoading;
    }

    void OnLevelFinishLoading(Scene scene, LoadSceneMode mode)
    {
        if (scene.name == "Gameplay")
        {
            Restart.restart();
        }
            
    }
}
