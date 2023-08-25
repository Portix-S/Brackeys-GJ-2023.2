using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InstaKill : MonoBehaviour
{
    private void OnTriggerEnter(Collider collision)
    {
        if(collision.gameObject.CompareTag("Player"))
        {
            Destroy(collision.gameObject.transform.root.gameObject);
        }
    }
}
