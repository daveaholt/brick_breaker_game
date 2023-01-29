using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BrickController : MonoBehaviour
{
    public int HitCount;
    private int _strength;

    public void Awake()
    {
        _strength = HitCount;
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
            if(_strength > 1)
            {
                _strength--;
            }
            else
            {
                GameManager.instance.brickCount--;
                Destroy(gameObject);
            }
        }
    }
}
