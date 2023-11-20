using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIButtons : MonoBehaviour
{
    [SerializeField] private LevelLoader levelLoader;

    public void ExitGame()
    {
        Application.Quit();
    }

    public void RestartOrBeginGame()
    {
        levelLoader.LoadLevel(1);
    }
}
