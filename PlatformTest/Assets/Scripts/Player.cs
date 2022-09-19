using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Player : MonoBehaviour
{
    private Scene scene;
    public Vector2 speed = new Vector2(50, 50);
    public GameObject player;
    public LayerMask ground;
    public LayerMask enemy;
    public LayerMask exit;
    public Transform topLeft;
    public Transform bottomRight;

    private float speedX;

    void Awake(){
        speedX = speed.x;
        scene = SceneManager.GetActiveScene();
    }

    void FixedUpdate(){
        if(touchingEnemy()){
            SceneManager.LoadScene(scene.name);
        }
        if(touchingExit()){
            SceneManager.LoadScene(scene.buildIndex+1);

        }
        if(!IsGrounded()){
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
    }

    private bool IsGrounded() {
        return Physics2D.OverlapArea(topLeft.position, bottomRight.position, ground);
    }

    private bool touchingEnemy(){
        return Physics2D.OverlapArea(topLeft.position, bottomRight.position, enemy);
    }
    private bool touchingExit(){
        return Physics2D.OverlapArea(topLeft.position, bottomRight.position, exit);
    }

}
