using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Sling : MonoBehaviour
{
    private Rigidbody rb;
    private bool isHoldingSling = false;
    [SerializeField] float slingForce = 2f;

    private Vector3 slingDirection;
    private Ray mouseCast;
    private Plane plane;
        void Start()
    {
        rb = GetComponent<Rigidbody>();
        plane = new Plane(Vector3.forward, transform.position);
    }

    // Update is called once per frame
    void Update()
    {
        
        if(Input.GetMouseButton(0) && isHoldingSling){
            mouseCast = Camera.main.ScreenPointToRay(Input.mousePosition);
            if(plane.Raycast(mouseCast, out float enter)){
                Vector3 hit = mouseCast.GetPoint(enter);
                Vector3 playerPos = plane.ClosestPointOnPlane(transform.position);
                slingDirection = new Vector3(hit.x - playerPos.x, hit.y - playerPos.y, 0);
            }
        }
        if(Input.GetMouseButtonDown(0)){
            mouseCast = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;
            if(Physics.Raycast(mouseCast, out hit) && hit.transform == transform){
                Debug.Log("Achei o jogador");
                isHoldingSling = true;
            }
        }
        if(Input.GetMouseButtonUp(0)&& isHoldingSling){
            isHoldingSling = false;
            rb.AddForce(-slingDirection.normalized * slingForce, ForceMode.Impulse);
            rb.AddForce(slingDirection.normalized * slingForce * 0.8f, ForceMode.Impulse);
        }
    }
}
