using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemyBubbleMovement : MonoBehaviour
{
    Vector3 pos;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag.Equals("Ground") || collision.gameObject.tag.Equals("Bar"))
        {
            pos = gameObject.transform.position;
            Invoke("createItem", 5.0f);
            Invoke("bubbleCntDown", 5.0f);
            Destroy(gameObject, 5.0f);
        }
    }
    
    void createItem()
    {
        GameObject item = Instantiate(Resources.Load("item")) as GameObject;
        item.transform.position = pos;
    }

    void bubbleCntDown()
    {
        PlayerState.bubbleNum--;
        Debug.Log(PlayerState.bubbleNum);
    }
}
