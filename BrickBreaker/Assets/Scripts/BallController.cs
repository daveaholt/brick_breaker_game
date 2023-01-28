using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallController : MonoBehaviour
{
    Rigidbody2D rb;
    public float bounceForce;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void Start()
    {
        
    }

    
    void Update()
    {
        if (Input.anyKeyDown)
        {
            StartBounce();
        }
    }

    void StartBounce()
    {
        var randomDirection = new Vector2(Random.Range(-1, 1), 1);
        rb.AddForce(randomDirection * bounceForce, ForceMode2D.Impulse);
    }
}
