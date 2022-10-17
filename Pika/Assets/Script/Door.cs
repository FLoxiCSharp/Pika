using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door : MonoBehaviour
{
    public string collisionTag;

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.name == collisionTag)
        {
            Player.isGrounded = true;
        }
        if (Input.GetKeyDown(KeyCode.F) && collision.gameObject.tag == collisionTag)
        {
            GetComponent<Collider2D>().isTrigger = false;
        }
    }

    private void OnCollisionStay2D(Collision2D collision)
    {
        if (collision.gameObject.name == collisionTag)
        {
            Player.isGrounded = true;
        }
        if (Input.GetKeyDown(KeyCode.F) && collision.gameObject.tag == collisionTag)
        {
            GetComponent<Collider2D>().isTrigger = true;
        }
    }
}
