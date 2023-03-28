using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickUpCode : MonoBehaviour
{

    public Transform player;
    public Rigidbody rb;

    private void Start()
    {
        //Setup

    }

    private void Update()
    {
        if (Input.GetKey(KeyCode.Z))
        {
            PickUp();
        }
        if (Input.GetKey(KeyCode.G))
        {
            Drop();
        }
    }

    private void PickUp()
    {
        transform.SetParent(player);
        transform.localPosition = Vector3.zero;
        transform.localRotation = Quaternion.Euler(Vector3.zero);
        transform.localScale = Vector3.one;

        //Make Rigidbody kinematic 
        rb.isKinematic = true;
        //coll.isTrigger = true;


    }
    private void Drop()
    {
        transform.SetParent(null);

        //Make Rigidbody not kinematic 
        rb.isKinematic = false;
    }

}
