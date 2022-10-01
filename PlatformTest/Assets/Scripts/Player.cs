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
    private bool showRestart;

    public LayerMask ground;
    public LayerMask enemy;
    public LayerMask exit;
    public LayerMask bounce;

    public Transform topLeft;
    public Transform bottomRight;

    private GameObject restartText;
    public GameObject DeadPlayer;

    private float speedX;
    private SpriteRenderer sr;

    void Awake(){
        restartText = GameObject.FindGameObjectWithTag("Restart");
        restartText.SetActive(false);
        speedX = speed.x;
        scene = SceneManager.GetActiveScene();
        sr = GetComponent<SpriteRenderer>();
        sr.color = Color.white;
        showRestart = false;
    }
    void FixedUpdate(){
        if(touchingEnemy()){
            FindObjectOfType<AudioManager>().Play("Splat");
            restartText.SetActive(true);
            Instantiate(DeadPlayer, transform.position + new Vector3(0f,0.5f,0f),Quaternion.identity);
            Destroy(this.gameObject);
            //SceneManager.LoadScene(scene.name);
        }
        if(touchingExit()){
            FindObjectOfType<AudioManager>().Play("NextLevel");
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

        if(this.gameObject.GetComponent<PlayerAim>().GetAmmoCount() <= 0){
            StartCoroutine(WaitForRestartScreen());
        }
        if (showRestart == true){
            if(this.gameObject.GetComponent<PlayerAim>().GetAmmoCount() <= 0){
                restartText.SetActive(true);
            }
            else{
                showRestart = false;
            }
        }


        /*if(Input.GetKeyDown(KeyCode.R)){
            SceneManager.LoadScene(scene.name);
        }
        if(Input.GetKeyDown("escape")){
            SceneManager.LoadScene(0);
        }
        */
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

    IEnumerator WaitForRestartScreen(){
        yield return new WaitForSeconds(5f);

        showRestart = true;

    }

}
