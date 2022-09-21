using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyDead : MonoBehaviour
{
    public Transform topLeft;
    public Transform bottomRight;
    public LayerMask ground;

    private Rigidbody2D rb;

    void Awake(){
        rb = GetComponent<Rigidbody2D>();

    }


    void FixedUpdate()
    {
        if(Physics2D.OverlapArea(topLeft.position, bottomRight.position, ground)){
            Destroy(rb);
        }
    }
}
