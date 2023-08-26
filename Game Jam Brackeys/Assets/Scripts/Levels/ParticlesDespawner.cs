using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParticlesDespawner : MonoBehaviour
{
    [SerializeField] string stageSpawnerName;
    private void OnTriggerEnter(Collider other)
    {
        /*
        if (other.gameObject.tag == stageSpawnerName)
        {
            Debug.Log("test");
            Destroy(other.gameObject);
        }
        //*/
    }
}
