using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

/*
    Sling Mechanic

    TODO
    * limit sling angle
    * playtest and adjust sling force
    * make collision interactions
    * probally should make the click detection a little better
    * visual indicators
*/

public class Sling : MonoBehaviour
{
    private Rigidbody rb;
    private bool isHoldingSling = false;
    [SerializeField] float slingForce = 2f;

    private Vector3 slingDirection;
    private Ray mouseCast;
    private Plane plane;

    private GameObject slingHUD;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        slingHUD = transform.GetChild(0).gameObject;
        //slingHUD.transform.rotation = Quaternion.identity;
        slingHUD.SetActive(false);
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

                // Quaternion rot = Quaternion.LookRotation(slingDirection);
                slingHUD.transform.rotation = new Quaternion(slingDirection.x, slingDirection.y, 0, 0);
            }
        }
        if(Input.GetMouseButtonDown(0)){
            mouseCast = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;
            if(Physics.Raycast(mouseCast, out hit) && hit.transform == transform){
                Debug.Log("Achei o jogador");
                rb.velocity = Vector3.zero;
                slingHUD.SetActive(true);
                isHoldingSling = true;
            }
        }
        if(Input.GetMouseButtonUp(0)&& isHoldingSling){
            slingHUD.SetActive(false);
            slingHUD.transform.rotation = Quaternion.identity;
            isHoldingSling = false;
            rb.AddForce(-slingDirection * slingForce, ForceMode.Impulse);
            rb.AddForce(slingDirection * slingForce * 0.8f, ForceMode.Impulse);
        }
    }
}
