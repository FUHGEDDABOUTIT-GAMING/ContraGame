using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class PauseMenu : MonoBehaviour
{
    //restarts level and sets health to 5 again
    public void Restart(){
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        ControlPlayer2D.health = 5;
    }

    //returns back to menu
    public void Menu(){
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - 1);
        ControlPlayer2D.health = 5;
    }
}
