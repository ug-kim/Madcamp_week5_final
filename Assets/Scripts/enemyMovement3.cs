using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class enemyMovement3 : MonoBehaviour
{
    bool goRight;

    void Start()
    {
        goRight = true;
    }
    
    void Update()
    {
        if (goRight)
        {
            if (gameObject.transform.position.x >-1.5) goRight = false;
            gameObject.transform.position += new Vector3(0.05f, 0, 0);
        }
        else
        {
            if (gameObject.transform.position.x < -7) goRight = true;
            gameObject.transform.position += new Vector3(-0.05f, 0, 0);
        }
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag.Equals("moveRight") || collision.gameObject.tag.Equals("moveLeft") || collision.gameObject.tag.Equals("Jump"))
        {
            SceneManager.LoadScene("bubbleEnd");
        }
        else if (collision.gameObject.tag.Equals("Bubble")) Destroy(gameObject);
    }
}
