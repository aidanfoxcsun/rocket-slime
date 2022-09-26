using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[System.Serializable]
public class GameData
{
    public int scene;
    public int enemies;
    public int collectables;
    public bool hardcore;

    public GameData(GameManager gm){
        scene = gm.scene;
        enemies = gm.enemies;
        collectables = gm.collectables;
    }

    
}
