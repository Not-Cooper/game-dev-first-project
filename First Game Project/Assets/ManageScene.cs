using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ManageScene : MonoBehaviour
{
    public string sceneName;

    void Start()
    {
        FindAnyObjectByType<AudioManager>().Play("StartTheme");
    }

    public void loadScene()
    {
        FindAnyObjectByType<AudioManager>().Stop("StartTheme");
        FindAnyObjectByType<AudioManager>().Play("Theme");
        SceneManager.LoadScene(sceneName);
    }
}
