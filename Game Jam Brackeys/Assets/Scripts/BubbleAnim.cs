using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BubbleAnim : MonoBehaviour
{
    [SerializeField] float min = 4;
    [SerializeField] float max = 15;
    Animator animator;
    float cd;
    float counter;
    void Start()
    {
        animator = GetComponent<Animator>();
        cd = Random.Range(1f, 10f);
        counter = 0;
    }

    // Update is called once per frame
    void Update()
    {
        counter += Time.deltaTime;
        if(counter >= cd)
        {
            animator.SetTrigger("Explode");
            animator.speed = Random.Range(0.8f, 1.1f);
            counter = 0;
            cd = Random.Range(min, max);
        }
    }
}
