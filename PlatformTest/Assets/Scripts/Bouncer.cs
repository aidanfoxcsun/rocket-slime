using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bouncer : MonoBehaviour
{
    public float time;
    public float force;
    public bool changeDir = true; //true - left; false - right
    public bool isVertical = false;
    private float horizontalForce;

    void Start(){
        StartCoroutine(Jump());

        if(isVertical == false){
            horizontalForce = 1;
        }else{
            horizontalForce = 0;
        }
    }


    IEnumerator Jump(){
        while(true){
            yield return new WaitForSeconds(time);
            if(changeDir == true){
            transform.GetComponent<Rigidbody2D>().AddForce((Vector3.up*1.5f + (Vector3.left*horizontalForce)) * force, ForceMode2D.Impulse );
            }
            else{
            transform.GetComponent<Rigidbody2D>().AddForce((Vector3.up*1.5f + (Vector3.right*horizontalForce)) * force, ForceMode2D.Impulse );
            }
            changeDir = !changeDir;
        }
    }    
}
