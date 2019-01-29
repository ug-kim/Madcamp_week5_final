using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Player : MonoBehaviour
{
   
    private Vector2 targetPos;
    public float Yincrement = 3;

    public float speed;
    public float maxHeight;
    public float minHeight;

    public int health = 3;

    public Text healthyDisplay;


    // Update is called once per frame
    void Update()
    {
        healthyDisplay.text = health.ToString();

        if (health <= 0)
        {
            SceneManager.LoadScene("ghostEnd");
            Destroy(gameObject);
        }


        transform.position = Vector2.MoveTowards(transform.position, targetPos, speed * Time.deltaTime);

        if (Input.GetKeyDown(KeyCode.UpArrow) && transform.position.y < maxHeight)
        {
            targetPos = new Vector2(transform.position.x, transform.position.y + Yincrement);
            transform.position = targetPos;
        } else if (Input.GetKeyDown(KeyCode.DownArrow) && transform.position.y > minHeight)
        {
            targetPos = new Vector2(transform.position.x, transform.position.y - Yincrement);
            
        }
    }
}
