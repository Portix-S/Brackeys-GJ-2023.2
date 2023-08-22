using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RagdollManager : MonoBehaviour
{
    //public BoxCollider mainCollider;
    public GameObject rig;
    public Animator anim;
    public GameObject body;
    public GameObject head;
    Collider[] ragdollColliders;
    Rigidbody[] limbsRigidbodies;

    // Start is called before the first frame update
    void Start()
    {
        GetRagDollBits();
        RagDollMode(true);

    }

    // Update is called once per frame
    void Update()
    {
        //transform.position = rig.transform.position;
        if(Input.GetMouseButtonDown(0))
        {
            RagDollMode(false);
        }
        if(Input.GetMouseButton(0))
        {
            //LookAtMousePos();
        }
        if (Input.GetMouseButtonUp(0))
        {
            Vector3 mousePosition = Input.mousePosition;

            Ray ray = Camera.main.ScreenPointToRay(mousePosition);
            RaycastHit hit;

            if (Physics.Raycast(ray, out hit))
            {
                Vector3 targetPosition = hit.point;
                Vector3 directionToTarget = targetPosition - transform.position;
                Quaternion targetRotation = Quaternion.LookRotation(directionToTarget);

                //float rotationSpeed = 5.0f;
                //body.transform.rotation = Quaternion.Slerp(body.transform.rotation, targetRotation, Time.deltaTime * rotationSpeed);
            }

            RagDollMode(true);
            head.GetComponent<Rigidbody>().AddForce(new Vector3(hit.point.x - transform.position.x, hit.point.y - transform.position.y, 0).normalized * 300f, ForceMode.Impulse);

            foreach (Rigidbody rb in limbsRigidbodies)
            {
                rb.GetComponent<Rigidbody>().AddForce(new Vector3(hit.point.x - transform.position.x, hit.point.y - transform.position.y, 0).normalized * 150f, ForceMode.Impulse);

            }

        }
    }
    void RagDollMode(bool x)
    {
        foreach(Collider col in ragdollColliders)
        {
            col.enabled = x;
        }
        foreach(Rigidbody rb in limbsRigidbodies)
        {
            rb.isKinematic = !x;
        }
        anim.enabled = !x;
        //mainCollider.enabled = !x;
        //GetComponent<Rigidbody>().isKinematic = !x;
    }

    void GetRagDollBits()
    {
        ragdollColliders = rig.GetComponentsInChildren<Collider>();
        limbsRigidbodies = rig.GetComponentsInChildren<Rigidbody>();
    }
    private void LookAtMousePos()
    {
        Vector3 mousePosition = Input.mousePosition;

        Ray ray = Camera.main.ScreenPointToRay(mousePosition);
        RaycastHit hit;

        if (Physics.Raycast(ray, out hit))
        {
            Vector3 targetPosition = hit.point;
            Vector3 directionToTarget = targetPosition - transform.position;
            Quaternion targetRotation = Quaternion.LookRotation(directionToTarget);

            float rotationSpeed = 5.0f;
            body.transform.rotation = Quaternion.Slerp(body.transform.rotation, targetRotation, Time.deltaTime * rotationSpeed);
        }
    }
}
