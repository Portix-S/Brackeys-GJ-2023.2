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
    [SerializeField] Transform playerInitialPosition;
    Collider[] ragdollColliders;
    Rigidbody[] limbsRigidbodies;
    Rigidbody rBody;
    public float windStrength = 5.0f;
    [SerializeField] MenuManager menuManager;
    // Start is called before the first frame update
    void Start()
    {
        rBody = GetComponent<Rigidbody>();
        GetRagDollBits();
        RagDollMode(true);

    }

    // Update is called once per frame
    void Update()
    {
        WindSimulation();
        //transform.position = rig.transform.position;
        if (Input.GetMouseButtonDown(0))
        {
            //RagDollMode(false);
        }
        if (Input.GetMouseButton(0))
        {
            //LookAtMousePos();

        }
        if (Input.GetMouseButtonUp(0))
        {
            /*Vector3 mousePosition = Input.mousePosition;

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
            Vector3 dir = new Vector3(hit.point.x - transform.position.x, hit.point.y - transform.position.y, 0).normalized * 300f;
            head.GetComponent<Rigidbody>().AddForce(dir , ForceMode.Impulse);
            Debug.Log(dir);
            foreach (Rigidbody rb in limbsRigidbodies)
            {
                rb.GetComponent<Rigidbody>().AddForce(dir.normalized * 150f, ForceMode.Impulse) ;
            }
        }
            */
        }
    }
    public void ApplyRagdollForces(Vector3 dir, float mag)
    {
        head.GetComponent<Rigidbody>().AddForce(dir * mag, ForceMode.Impulse);

        foreach (Rigidbody rb in limbsRigidbodies)
        {
            rb.GetComponent<Rigidbody>().AddForce(dir * mag, ForceMode.Impulse);

        }
    }

    public void RagDollMode(bool x)
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
    private void WindSimulation()
    {
        //*
        if (!menuManager.isPaused)
        {
            foreach (Rigidbody rb in limbsRigidbodies)
            {
                rb.GetComponent<Rigidbody>().AddForce(Vector3.up * windStrength * Random.Range(-1, 1.1f), ForceMode.Impulse);
            }
        }
        //*/
        //rBody.AddForce ( new Vector3(0, (playerInitialPosition.transform.position.y - transform.position.y) * 10, 0), ForceMode.Impulse);
        //Debug.Log(playerInitialPosition.transform.position.y - transform.position.y);
    }   
}
