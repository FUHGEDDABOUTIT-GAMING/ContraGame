using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class SettingsMenu: MonoBehaviour
{
    public string gameSceneName;
    public void closeSettings()
    {
        SceneManager.LoadScene(gameSceneName);
    }
    
    public void closeAbout()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - 3);
    }
}
