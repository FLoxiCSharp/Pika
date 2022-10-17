using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollisionHeal : MonoBehaviour
{
    public int collisionHeal = 10;
    public string collisionTag;

    private void OnTriggerStay2D(Collider2D coll)
    {
        if (coll.gameObject.name == collisionTag)
        {
            Player.isGrounded = false;
        }
        if (Input.GetKey(KeyCode.Q) && coll.gameObject.tag == collisionTag)
        {
            print(Player.isGrounded);
            Health health = coll.gameObject.GetComponent<Health>();
          
            health.SetHealth(collisionHeal);
            
            Destroy(gameObject);
        }
    }

}
