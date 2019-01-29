using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bubbleActionLeft : MonoBehaviour
{
    int moveHorizontal = 50;
 
    void Update()
    {
        if (moveHorizontal-- > 0) gameObject.transform.position += new Vector3(-0.08f, 0, 0);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag.Equals("Ground") || collision.gameObject.tag.Equals("Bar"))
        {
            Invoke("bubbleCntDown", 5.0f);
            Destroy(gameObject, 5.0f);
        }
        else if (collision.gameObject.tag.Equals("Enemy"))
        {
            GameObject newBubble = Instantiate(Resources.Load("enemy_in_bubble")) as GameObject;
            newBubble.transform.position = gameObject.transform.position;
            PlayerState.bubbleNum--;
            Destroy(gameObject);
        }
    }

    void bubbleCntDown()
    {
        PlayerState.bubbleNum--;
        Debug.Log(PlayerState.bubbleNum);
    }
}
