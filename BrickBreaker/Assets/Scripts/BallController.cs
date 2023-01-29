using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BallController : MonoBehaviour
{
    Rigidbody2D rb;
    public float bounceForce;
    private int bounceCount;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        bounceCount = 0;
    }

    void Start()
    {
        StartBounce();
    }

    
    void Update()
    {
    }

    void StartBounce()
    {
        var randomDirection = new Vector2(Random.Range(-1, 1), 1);
        rb.AddForce(randomDirection * bounceForce, ForceMode2D.Impulse);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "FallCheck")
        {
            SceneManager.LoadScene("Menu");
        }
        else if (collision.gameObject.tag == "Top")
        {
            var addDownwardThrust = new Vector2(rb.velocity.x, rb.velocity.y - 1);
            rb.AddForce(addDownwardThrust, ForceMode2D.Force);
        }
    }
}
