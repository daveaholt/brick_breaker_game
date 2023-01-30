using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class BallController : MonoBehaviour
{
    Rigidbody2D rb;
    public float bounceForce;
    private int bounceCount;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        bounceCount = 0;
        var gameOverText = GameObject.Find("Game_Over").GetComponent<Text>();
        gameOverText.enabled = false;
    }

    void Start()
    {
        Invoke("HideTextAndStart", 1f);
    }

    
    void Update()
    {
    }

    private void HideTextAndStart()
    {
        var levelText = GameObject.Find("Level_Text").GetComponent<Text>();
        levelText.enabled = false;
        StartBounce();
    }

    private void FixedUpdate()
    {
        rb.velocity = Vector2.ClampMagnitude(rb.velocity, bounceForce);
        if (rb.velocity.magnitude < bounceForce)
        {
            rb.velocity = rb.velocity.normalized * bounceForce;
        }
        if(rb.velocity.x > -0.05 && rb.velocity.x < 0)
        {
            rb.velocity = new Vector2(rb.velocity.x - .06f, rb.velocity.y);
        }
        else if (rb.velocity.x > 0 && rb.velocity.x < 0.05)
        {
            rb.velocity = new Vector2(rb.velocity.x + .6f, rb.velocity.y);
        }

        if (rb.velocity.y > -0.05 && rb.velocity.y < 0)
        {
            rb.velocity = new Vector2(rb.velocity.x, rb.velocity.y - .6f);
        }
        else if (rb.velocity.y > 0 && rb.velocity.y < 0.05)
        {
            rb.velocity = new Vector2(rb.velocity.x, rb.velocity.y + .6f);
        }
    }

    void StartBounce()
    {
        var randomDirection = new Vector2(Random.Range(-1, 0), 1);
        rb.AddForce(randomDirection * bounceForce, ForceMode2D.Impulse);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "FallCheck")
        {
            var gameOverText = GameObject.Find("Game_Over").GetComponent<Text>();
            gameOverText.enabled = true;
            rb.velocity = Vector2.zero;
            GameManager.instance.Score = 0;
            Invoke("LoadMainMenu", 1f);
        }
        else if (collision.gameObject.tag == "Top")
        {
            var addDownwardThrust = new Vector2(rb.velocity.x, rb.velocity.y - 1);
            rb.AddForce(addDownwardThrust, ForceMode2D.Force);
        }
        else if (collision.gameObject.tag == "Right")
        {
            var addDownwardThrust = new Vector2(rb.velocity.x - 1, rb.velocity.y);
            rb.AddForce(addDownwardThrust, ForceMode2D.Force);
        }
        else if (collision.gameObject.tag == "Left")
        {
            var addDownwardThrust = new Vector2(rb.velocity.x + 1, rb.velocity.y);
            rb.AddForce(addDownwardThrust, ForceMode2D.Force);
        }
    }

    private void LoadMainMenu()
    {
        SceneManager.LoadScene("Menu");
    }
}
