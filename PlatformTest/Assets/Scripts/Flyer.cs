using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Flyer : MonoBehaviour
{
    public float timeX;
    public float timeY;
    public float speedX;
    public float speedY;
    public bool changeDirX = true; // true - left; false - right
    private bool changeDirY = true;

    void Start(){
        StartCoroutine(LR());
        StartCoroutine(UD());
    }

    void Update()
    {

        if(changeDirX == true){
            transform.Translate(Vector3.left * Time.deltaTime * speedX);
        }
        else if(changeDirX == false){
            transform.Translate(Vector3.right * Time.deltaTime * speedX);
        }

        if(changeDirY == true){
            transform.Translate(Vector3.up * Time.deltaTime * speedY);
        }
        else if(changeDirY == false){
            transform.Translate(Vector3.down * Time.deltaTime * speedY);
        }



    }

    IEnumerator LR(){
        while(true){
            yield return new WaitForSeconds(timeX);
        changeDirX = !changeDirX;
        }
    
    }
    IEnumerator UD(){
        while(true){
            yield return new WaitForSeconds(timeY);
        changeDirY = !changeDirY;
        }
    
    }
}
