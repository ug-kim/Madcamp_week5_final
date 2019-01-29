using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class itemAction : MonoBehaviour
{
    private void Start()
    {
        Destroy(gameObject, 10.0f);
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag.Equals("moveRight") || collision.gameObject.tag.Equals("moveLeft") || collision.gameObject.tag.Equals("Jump"))
        {
            scoreManager.score += 50;
            Destroy(gameObject);
        }
    }
}
