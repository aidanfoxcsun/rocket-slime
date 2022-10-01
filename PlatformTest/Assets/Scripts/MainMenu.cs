using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public GameManager gm;
    private int levelIndex = 1;

    public Dropdown dropdown;


    void Awake(){
        gm.scene = 1;

    }

    public void NewGame(){
        SceneManager.LoadScene(1);
        SaveSystem.SaveGame(gm);    
    }
    public void LoadGame(){
        SceneManager.LoadScene(levelIndex);
    }

    public void Continue(){
        if(SaveSystem.LoadGame() != null){
            GameData data = SaveSystem.LoadGame();
            SceneManager.LoadScene(data.scene); 
        } else{
            Debug.LogError("No Game Data");
        }
        
    }

    public void QuitGame(){
        Debug.Log("Quit");
        Application.Quit();
    }

    public void SetSceneIndex(int index){
        levelIndex = index;
    }

    public void DropdownSelect(){
        levelIndex = dropdown.value + 1;
    }

    
}
