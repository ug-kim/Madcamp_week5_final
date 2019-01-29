using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class door1 : MonoBehaviour
{
    private void OnCollisionEnter2D(Collision2D collision)
    { 
        if (collision.gameObject.tag.Equals("moveRight") || collision.gameObject.tag.Equals("moveLeft") || collision.gameObject.tag.Equals("Jump")) SceneManager.LoadScene("Level2");
    }
}
