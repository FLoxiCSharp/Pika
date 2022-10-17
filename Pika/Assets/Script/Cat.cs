using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cat : MonoBehaviour
{
    [SerializeField] float speed;

    [SerializeField] float targetPosition;

    [SerializeField] Transform playerTransform;

    Rigidbody2D myRigidbody2D;

    Transform target;
    void Start()
    {
        myRigidbody2D = GetComponent<Rigidbody2D>();

    }

    void Update()
    {
        
    }

    void targetFollow()
    {
        if (Vector2.Distance(transform.position, target.position) > targetPosition)
        {

        }
    }
}
