using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickUp : MonoBehaviour
{
    public Transform TheDest;

    void OnMouseDown()
    {
        GetComponent<BoxCollider>().enabled = false;
        GetComponent<Rigidbody>().useGravity = false;
        transform.position = TheDest.position;
        transform.parent = GameObject.Find("Destination").transform;
    }

    void OnMouseUp()
    {
        GetComponent<BoxCollider>().enabled = true;
        transform.parent = null;
        GetComponent<Rigidbody>().useGravity = true;
    }
}
