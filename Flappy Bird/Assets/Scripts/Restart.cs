using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;

public class Restart : MonoBehaviour
{
    public static void restart()
    {
        GameManager.instance.Score = 0;
        Bird.isAlive = true;
        Time.timeScale = 1;
    }
}
