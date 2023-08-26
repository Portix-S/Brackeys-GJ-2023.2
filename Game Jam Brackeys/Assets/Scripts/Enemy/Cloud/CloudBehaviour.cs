using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CloudBehaviour : MonoBehaviour
{
    [SerializeField] float bounceForce;
    [SerializeField] PhysicMaterial playerMat;

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.transform.tag == "Player")
        {
            Rigidbody rb = collision.rigidbody;
            //rb.AddForce(new Vector3(-collision.transform.position.x / 4 * bounceForce, -collision.transform.position.y /2f * bounceForce), ForceMode.Impulse);
        }
    }
}
