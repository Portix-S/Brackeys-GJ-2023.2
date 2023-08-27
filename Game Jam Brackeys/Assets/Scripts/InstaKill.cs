using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InstaKill : MonoBehaviour
{
    private void OnTriggerEnter(Collider collision)
    {
        if(collision.gameObject.CompareTag("Player"))
        {
            collision.transform.root.GetComponent<PlayerHealth>().TakeHit(1);
            collision.transform.root.GetComponent<PlayerHealth>().TakeHit(1);
            collision.transform.root.GetComponent<PlayerHealth>().TakeHit(1);
        }
    }
}
