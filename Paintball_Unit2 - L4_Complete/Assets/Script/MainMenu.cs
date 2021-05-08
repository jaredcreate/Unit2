using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public void Start(){
        //Turns on the Mouse and Unlocks it
        //We do this because the First Person Player Scripts Turns of the Mouse and Locks the Mouse 
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;  
    }
    public void PlayGame()
    {
        //Moves to the Main Menu Scene
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex+1);
    }

    public void QuitGame()
    {
        //Quits the Applications
        Debug.Log("Application.Quit()");
        Application.Quit();
    }
}








