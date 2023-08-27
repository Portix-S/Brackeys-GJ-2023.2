using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KickPlayer : MonoBehaviour
{
    [SerializeField] RagdollManager rag;
    [SerializeField] float sec = 2;
    [SerializeField] float force = 50;
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(Kick(sec));
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    IEnumerator Kick(float sec)
    {

        yield return new WaitForSeconds(sec);
        rag.RagDollMode(true);
        rag.head.GetComponent<Rigidbody>().AddForce((Vector3.left + Vector3.up) * force, ForceMode.Impulse);
        StartCoroutine(CanControl());
    }

    IEnumerator CanControl()
    {
        Debug.Log("hi");
        yield return new WaitForSeconds(1);
        rag.GetComponent<NewPlayerMovement>().enabled = true;
    }
}
