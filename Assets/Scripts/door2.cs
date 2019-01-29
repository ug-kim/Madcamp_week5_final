using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class door2 : MonoBehaviour
{
    private void OnCollisionEnter2D(Collision2D collision)
    {
        scoreManager.score += 300;
        if (collision.gameObject.tag.Equals("moveRight") || collision.gameObject.tag.Equals("moveLeft") || collision.gameObject.tag.Equals("Jump")) SceneManager.LoadScene("Level3");
    }
}
