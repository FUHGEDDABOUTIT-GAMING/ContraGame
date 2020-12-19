using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class GameOver : MonoBehaviour
{
    public void playAgain(){
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        ControlPlayer2D.health = 5;
    }
    
    public void menu(){
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - 1);
        ControlPlayer2D.health = 5;
    }

    
}