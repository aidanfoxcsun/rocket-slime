using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ammo : MonoBehaviour
{


    void OnTriggerEnter2D(Collider2D col){
        if(col.gameObject.tag == "Player"){
            col.GetComponent<PlayerAim>().AmmoPickup();
            Destroy(this.gameObject);
        }

    }
}
