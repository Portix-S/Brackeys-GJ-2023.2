using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KickPlayer : MonoBehaviour
{
    [SerializeField] RagdollManager rag;
    float sec = 5.2f;
    [SerializeField] float force = 50f;
    [SerializeField] FinishLine fl;
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(Kick(sec));
    }

    IEnumerator Kick(float sec)
    {
        yield return new WaitForSeconds(sec);
        fl.isFalling = true;
        rag.RagDollMode(true);
        rag.head.GetComponent<Rigidbody>().AddForce((Vector3.left + Vector3.up) * force, ForceMode.Impulse);
        StartCoroutine(CanControl());

    }

    IEnumerator CanControl()
    {
        Debug.Log("hi");
        yield return new WaitForSeconds(1f);
        rag.GetComponent<NewPlayerMovement>().enabled = true;
        yield return new WaitForSeconds(0.5f);
        rag.windStrength = 5f;
    }
}
