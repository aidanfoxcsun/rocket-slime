using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAim : MonoBehaviour
{
    private Transform aimTransform;
    public Transform barrelExit;
    public Transform player;
    public float shootForce = 50;
    private Vector3 aimDirection;
    public int ammoCount = 5;

    public GameObject AmmoPrefab;

    private void Awake(){
        aimTransform = transform.Find("Aim");

    }

    private void Update(){
        Vector3 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        mousePosition.z = 0f;

        aimDirection = (mousePosition - transform.position).normalized;
        float angle = Mathf.Atan2(aimDirection.y, aimDirection.x) * Mathf.Rad2Deg;
        aimTransform.eulerAngles = new Vector3(0,0, angle);

        if(Input.GetKeyDown(KeyCode.Space) || Input.GetMouseButtonDown(0)){
            Shoot();
            Debug.Log("Ammo: " + ammoCount);
        }

        if(Input.GetKeyDown(KeyCode.Q)){
            ammoCount = 5;
            Debug.Log("Ammo: " + ammoCount);
        }

    }

    void Shoot(){
        RaycastHit2D hit = Physics2D.Raycast(barrelExit.transform.position, aimDirection);
        Debug.DrawRay(barrelExit.transform.position, aimDirection, Color.red);
        if(ammoCount > 0){
            player.GetComponent<Rigidbody2D>().AddForce(-aimDirection * shootForce, ForceMode2D.Impulse );
            if(hit.collider.gameObject.tag == "Enemy" && hit.collider.gameObject != null){
                Instantiate(AmmoPrefab, hit.transform.position, hit.transform.rotation);
                Destroy(hit.collider.gameObject);
            }
            ammoCount--;
        }
        else{
            Debug.Log("Reload");
        }
    }

    public void AmmoPickup(){
        ammoCount++;
    }
}
