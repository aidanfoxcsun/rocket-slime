using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public int collectables;
    public int enemies;
    public int scene;

    public static GameManager instance;


    void Awake(){
        if(instance != null){
            Debug.LogError("More than one GameManager in scene!");
            return;
        }
        instance = this;
    }

    void Update(){
        if(Input.GetKeyDown(KeyCode.R)){
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }
        if(Input.GetKeyDown("escape")){
            SceneManager.LoadScene(0);
        }
    }

    void Start(){
        scene = SceneManager.GetActiveScene().buildIndex;
        enemies = GameObject.FindGameObjectsWithTag("Enemy").Length;
        collectables = GameObject.FindGameObjectsWithTag("Ammo").Length;
        if(SaveSystem.LoadGame() == null || this.scene > SaveSystem.LoadGame().scene){
            SaveSystem.SaveGame(this);
        }
    }
}
