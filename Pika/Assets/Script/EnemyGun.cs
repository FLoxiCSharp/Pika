using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyGun : MonoBehaviour
{
    public float Range;
    public Transform target;
    private bool detected = false;
    private Vector2 direction;
    public GameObject gun;
    RaycastHit2D rayInfo;
    
    public GameObject turret0;

    public GameObject Bullet;
    public float FireRate;
    float nextTimeToFire = 0;
    public Transform shootPos;
    public float Force;

    void Start()
    {

    }

    
    void Update()
    {
        Vector2 targetPos = target.position;
        direction = targetPos - (Vector2)transform.position;
        rayInfo = Physics2D.Raycast(transform.position, direction, Range);
        if (rayInfo.collider != null && rayInfo.collider.gameObject.tag == "Player")
        {
            if (!detected)
            {
                detected = true;
            }
        }
        else
        {
            if(!detected)
            {
                detected = false;
            }
        }
        if (detected)
        {
            gun.transform.right = direction;
            if (Time.time > nextTimeToFire)
            {
                nextTimeToFire = Time.time + 1 / FireRate;
                Shoot();
            }
        }
    }
    void Shoot()
    {
        GameObject BulletIns = Instantiate(Bullet, shootPos.position, Quaternion.identity);
        BulletIns.GetComponent<Rigidbody2D>().AddForce(direction * Force);
        BulletIns.transform.right = direction;
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.DrawWireSphere(transform.position, Range);
    }
}
