using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewPlayerMovement : MonoBehaviour
{
    Rigidbody rb;
    [SerializeField] float movSpeed = 50;
    [SerializeField] float xDir;
    [SerializeField] float div = 100;
    [SerializeField] float grav = 50;
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    void FixedUpdate()
    {
        xDir = Input.GetAxisRaw("Horizontal");
        rb.velocity = new Vector3(xDir * movSpeed, -div, 0)  *  Time.deltaTime;
        div += grav * Time.deltaTime;
    }

}
