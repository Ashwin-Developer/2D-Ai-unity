using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurretScript : MonoBehaviour
{
    // Start is called before the first frame update
    public float Range;

    public Transform Target;

    bool Detected = false;

    Vector2 Direction;

    public GameObject gun;

    public GameObject AlarmLight;

    public GameObject bullet;

    public float fireRate;

    public Transform shootPoint;

    float nextTimeToFire = 0;

    public float force;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Vector2 targetPos = Target.position;
        Direction = targetPos - (Vector2)transform.position;
        RaycastHit2D rayInfo = Physics2D.Raycast(transform.position,Direction,Range);

        if (rayInfo)
        {
            if(rayInfo.collider.gameObject.tag == "Player")
            {
                if(Detected == false)
                {
                    Detected = true;
                    AlarmLight.GetComponent<SpriteRenderer>().color = Color.red;
                }
            }

            else
            {
                if (Detected == true)
                {
                    Detected = false;
                    AlarmLight.GetComponent<SpriteRenderer>().color = Color.green;
                }
            }
        }

        if(Detected)
        {
            gun.transform.up = Direction;
            if(Time.time > nextTimeToFire)
            {
                nextTimeToFire = Time.time + 1 / fireRate;
                shoot();
            }
        }
    }

    void shoot()
    {
        GameObject bulletIns = Instantiate(bullet, shootPoint.position, Quaternion.identity);
        bulletIns.GetComponent<Rigidbody2D>().AddForce(Direction * force);
    }

    void OnDrawGizmosSelected()
    {
        Gizmos.DrawWireSphere(transform.position,Range);

    }
}
