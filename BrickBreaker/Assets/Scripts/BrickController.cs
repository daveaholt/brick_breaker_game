using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BrickController : MonoBehaviour
{
    public int HitCount;
    Color green;
    Color yellow;
    Color red;

    public void Awake()
    {
        ColorUtility.TryParseHtmlString("#29E076", out green);
        ColorUtility.TryParseHtmlString("#e6df20", out yellow);
        ColorUtility.TryParseHtmlString("#d15241", out red);
        ManageColor();
    }

    void Start()
    {
        GameManager.instance.brickCount++;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Ball")
        {
            ManageColor();
            if (HitCount > 1)
            {
                HitCount--;
            }
            else
            {
                GameManager.instance.brickCount--;
                Destroy(gameObject);
            }
        }
    }

    private void ManageColor()
    {
        if (HitCount < 2)
        {
            GetComponent<SpriteRenderer>().color = green;
        }
        else if (HitCount >= 2 && HitCount < 5)
        {
            GetComponent<SpriteRenderer>().color = yellow;
        }
        else
        {
            GetComponent<SpriteRenderer>().color = red;
        }
    }
}
