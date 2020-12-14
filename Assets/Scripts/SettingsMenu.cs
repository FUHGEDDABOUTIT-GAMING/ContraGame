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
}
