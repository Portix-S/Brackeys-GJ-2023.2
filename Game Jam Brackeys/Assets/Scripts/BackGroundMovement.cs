using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackGroundMovement : MonoBehaviour
{
    GameManager gm;
    Rigidbody rb;
    // Start is called before the first frame update
    void Start()
    {
        gm = GameObject.FindGameObjectWithTag("GameController").GetComponent<GameManager>();
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        //gameObject.transform.position += Vector3.up * Time.deltaTime * gm.backgroundSpeed;
        rb.velocity = Vector3.up * gm.backgroundSpeed;
    }
}
