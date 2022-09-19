using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AmmoCount : MonoBehaviour
{
    public GameObject player;
    public Text txt;

    void Update(){
        txt.text = player.GetComponent<PlayerAim>().ammoCount.ToString();

    }
}
