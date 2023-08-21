using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackAnimations : MonoBehaviour
{
    [SerializeField] Animator animator;
    Rigidbody rb;
    private void Awake()
    {
        rb = GetComponent<Rigidbody>();
    }
    private void Update()
    {
        if(Input.GetMouseButtonDown(0))
        {
            animator.SetBool("isCharging", true);
            //rb.isKinematic = true;
        }
    }
}
