using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{

// Loading next scene in build index
public void PlayGame () 
{
    SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
}
// Quitting game from main menu
public void QuitGame () 
{
    Debug.Log("quit game");
    Application.Quit();
}

}
