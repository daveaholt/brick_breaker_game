using System.Collections;
using System.Collections.Generic;
using Unity.Burst.Intrinsics;
using UnityEngine;

public class PaddleController : MonoBehaviour
{
    Rigidbody2D rb;
    public float moveSpeed;


    private void Awake()
    {
       rb = GetComponent<Rigidbody2D>(); 
    }

    void Start()
    {
        
    }

    void Update()
    {
        
    }

    private void FixedUpdate()
    {
        TouchMove();
    }

    void TouchMove()
    {
        if(Input.GetMouseButton(0))
        {
            var touchPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            if(touchPos.x < 0)
            {
                rb.velocity = Vector2.left * moveSpeed;
            }
            else
            {
                rb.velocity = Vector2.right * moveSpeed;
            }
        }
        else
        {
            rb.velocity = Vector2.zero;
        }
    }
}
