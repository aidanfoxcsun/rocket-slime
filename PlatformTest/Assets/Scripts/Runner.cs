using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Runner : MonoBehaviour
{
    public float time;
    public float speed;
    public bool changeDir = true;//true = start left, false = start right

    void Start(){
        StartCoroutine(Run());
    }

    void Update()
    {

        if(changeDir == true){
            transform.Translate(Vector3.left * Time.deltaTime * speed);
        }
        else{
            transform.Translate(Vector3.right * Time.deltaTime * speed);
        }



    }

    IEnumerator Run(){
        while(true){
            yield return new WaitForSeconds(time);
        changeDir = !changeDir;
        }
        

    }


}
