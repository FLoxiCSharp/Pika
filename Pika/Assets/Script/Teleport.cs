using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Teleport : MonoBehaviour
{
    public GameObject pointTeleport;


   

    private void OnTriggerStay2D(Collider2D collision)
    {
        print(2);
        if (Input.GetKeyDown(KeyCode.E) && collision.gameObject.tag == "Player")
        {
            print(1);
            collision.gameObject.transform.position = pointTeleport.gameObject.transform.position;
            
        }
       
    }
}
