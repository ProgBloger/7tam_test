using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoader : MonoBehaviour
{
    enum Scenes
    {
        Game,
        Win,
        Lose
    }

    // Start is called before the first frame update
    void Start()
    {
        DontDestroyOnLoad(gameObject);
    }
    
    public void LoadFirstScene()
    {
        SceneManager.LoadScene((int)Scenes.Game);
    }

    public void LoadWinScene()
    {
        SceneManager.LoadScene((int)Scenes.Win);
    }

    public void LoadLoseScene()
    {
        SceneManager.LoadScene((int)Scenes.Lose);
    }
}
