using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Player : MonoBehaviour
{
    private Scene scene;
    public Vector2 speed = new Vector2(50, 50);
    public GameObject player;
    public Color bouncified;
    private bool canMoveInAir;

    public LayerMask ground;
    public LayerMask enemy;
    public LayerMask exit;
    public LayerMask bounce;

    public Transform topLeft;
    public Transform bottomRight;

    private float speedX;
    private SpriteRenderer sr;

    void Awake(){
        speedX = speed.x;
        scene = SceneManager.GetActiveScene();
        sr = GetComponent<SpriteRenderer>();
        sr.color = Color.white;
    }

    void FixedUpdate(){
        if(touchingEnemy()){
            SceneManager.LoadScene(scene.name);
        }
        if(touchingExit()){
            SceneManager.LoadScene(scene.buildIndex+1);

        }
        if(touchedBounce()){
            canMoveInAir = true;
        }
        if(!IsGrounded() && canMoveInAir == false){
            speed.x = speed.x/1.5f;
        }
        else
            speed.x = speedX;

        float inputX = Input.GetAxis("Horizontal");
        float inputY = Input.GetAxis("Vertical");
        
        Vector3 movement = new Vector3(speed.x * inputX, speed.y * inputY, 0);

        movement *= Time.deltaTime;

        player.GetComponent<Rigidbody2D>().AddForce(movement, ForceMode2D.Impulse);
    }

    void Update(){
        if(Input.GetKeyDown(KeyCode.R)){
            SceneManager.LoadScene(scene.name);
        }
        if(Input.GetKeyDown("escape")){
            SceneManager.LoadScene(0);
        }
        if(canMoveInAir){
            sr.color = bouncified;
        }else{
            sr.color = Color.white;
        }
    }

    private bool IsGrounded() {
        if(Physics2D.OverlapArea(topLeft.position, bottomRight.position, ground)){
            canMoveInAir = false;
            return true;
        }
        return false;
    }

    private bool touchingEnemy(){
        return Physics2D.OverlapArea(topLeft.position, bottomRight.position, enemy);
    }
    private bool touchingExit(){
        return Physics2D.OverlapArea(topLeft.position, bottomRight.position, exit);
    }
    private bool touchedBounce(){
        return Physics2D.OverlapArea(topLeft.position, bottomRight.position, bounce);
    }

}
