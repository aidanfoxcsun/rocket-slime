using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public void NewGame(){
        SceneManager.LoadScene(1);    
    }

    //placeholder !CHANGE LATER!
    public void LoadGame(){
        Debug.Log("LoadGame Placeholder Method. Add Functionality Later.");
    }

    public void QuitGame(){
        Debug.Log("Quit");
        Application.Quit();
    }

    //placeholder !CHANGE LATER!
    public void Options(){
        Debug.Log("Options Placeholder Method. Add Functionality Later.");
    }
}
