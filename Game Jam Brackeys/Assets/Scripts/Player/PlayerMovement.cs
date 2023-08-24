using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private Rigidbody rb;
    [SerializeField] float moveSpeed = 10f;
    private Vector3 moveDirection;
    [SerializeField] Vector2 limits;
    GameManager gm;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        limits = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height, 0));
        gm = GameObject.FindGameObjectWithTag("GameController").GetComponent<GameManager>();
    }

    // Update is called once per frame
    void Update()
    {
        float movementX = 0f;
        float movementY = 0f;
        /*
        if (Input.GetKey(KeyCode.W))
            movementY = 0.4f;
        if (Input.GetKey(KeyCode.S))
            movementY = -1f;
        //*/
        if (Input.GetKey(KeyCode.D))
            movementX = 1f;
        if (Input.GetKey(KeyCode.A))
            movementX = -1f;

        if (Input.GetKey(KeyCode.D) && Input.GetKey(KeyCode.A))
            movementX = 0f;

        moveDirection = new Vector3(movementX, 0f);
    }

    // Clamp player to screen
    void LateUpdate()
    {
        Vector3 objPos = transform.position;
        objPos.x = Mathf.Clamp(objPos.x, -limits.x + 1f, limits.x - 1f);
        //objPos.y = Mathf.Clamp(objPos.y, -limits.y + 0.5f, limits.y - 0.5f);
        transform.position = objPos;
    }


    private void FixedUpdate()
    {
        // Adds velocity to rigidbody decide how to move
        //if (!isOnMenu)
        rb.velocity = moveDirection * moveSpeed;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "StageFinish")
            Destroy(other.gameObject);
    }
}
