using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class door3 : MonoBehaviour
{
    private void OnCollisionEnter2D(Collision2D collision)
    {
        scoreManager.score += 500;
        if (collision.gameObject.tag.Equals("moveRight") || collision.gameObject.tag.Equals("moveLeft") || collision.gameObject.tag.Equals("Jump")) SceneManager.LoadScene("bubbleEnd");
    }
}
