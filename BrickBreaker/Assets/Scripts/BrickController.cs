using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class BrickController : MonoBehaviour
{
    private AudioSource _audioSource;
    private SpriteRenderer _renderer;

    public int HitCount;
    private int _strength;
    Color green;
    Color yellow;
    Color red;

    public void Awake()
    {
        ColorUtility.TryParseHtmlString("#29E076", out green);
        ColorUtility.TryParseHtmlString("#e6df20", out yellow);
        ColorUtility.TryParseHtmlString("#d15241", out red);
        _strength = HitCount;
    }

    void Start()
    {
        GameManager.instance.brickCount++;
        _audioSource = GetComponent<AudioSource>();
        if(_audioSource == null)
        {
            Debug.LogError("AudioSource is null.");
        }

        _renderer = GetComponent<SpriteRenderer>();
        if(_renderer == null)
        {
            Debug.LogError("SpriteRenderer is null.");
        }
        ManageColor();
        Invoke("UpdateScore", .2f);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        _audioSource.Play();

        if (collision.gameObject.tag == "Ball")
        {            
            ManageColor();
            if (_strength > 1)
            {
                _strength--;
            }
            else
            {
                GameManager.instance.brickCount--;
                GameManager.instance.Score++;
                UpdateScore();
                Invoke("KillMe", .2f);
            }
        }
    }

    private void UpdateScore()
    {
        var scoreText = GameObject.Find("Score").GetComponent<Text>();
        scoreText.text = GameManager.instance.Score.ToString();
    }

    private void KillMe()
    {
        Destroy(gameObject);
    }

    private void ManageColor()
    {
        if (_strength < 3)
        {
            _renderer.color = green;
        }
        else if (_strength >= 3 && _strength < 6)
        {
            _renderer.color = yellow;
        }
        else
        {
            _renderer.color = red;
        }
    }
}
