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
    [SerializeField] Vector2 limits;

    void Start()
    {
        limits = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height, 0));
        rb = GetComponent<Rigidbody>();
    }

    public void CalculateLimits()
    {
        Debug.Log("Recalculating Limits");
        limits.x += 5.5f;
        limits.y += 5.5f;
    }

    // Clamp player to screen
    void LateUpdate()
    {
        Vector3 objPos = transform.position;
        objPos.x = Mathf.Clamp(objPos.x, -limits.x + 1f, limits.x - 1f);
        //objPos.y = Mathf.Clamp(objPos.y, -limits.y + 0.5f, limits.y - 0.5f);
        transform.position = objPos;
    }

    void FixedUpdate()
    {
        xDir = Input.GetAxisRaw("Horizontal");
        rb.velocity = new Vector3(xDir * movSpeed, -div, 0)  *  Time.deltaTime;
        div += grav * Time.deltaTime;
    }

    private void OnTriggerEnter(Collider other) // Mudar para quebrar a "mascara" depois de fazer a explosão
    {
        if (other.tag == "StageFinish")
            Destroy(other.gameObject, 0f);
    }

}
