using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    public Transform enemyToSpawn;
    bool spawned;
    [SerializeField] bool hasEnemies;

    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Spawner" && !spawned)
        {
            spawned = true;
            if (enemyToSpawn != null)
            {
                Transform spawned = Instantiate(enemyToSpawn, transform.position, enemyToSpawn.rotation, transform.parent);
               // Debug.Log("Spawning" + enemyToSpawn.gameObject.name + "with rotation: " + spawned.rotation.y + "at possition: " + transform.position.x);
                if (((spawned.rotation.y < 0f && transform.position.x < 0f) || (spawned.rotation.y > 0f && transform.position.x > 0f)) && hasEnemies)
                {
                    Debug.Log("changing rotation");
                    spawned.eulerAngles = new Vector3(0f, -spawned.localEulerAngles.y);
                    spawned.GetComponent<MoveFwd>().speed *= -1f;
                }
                //spawned.rotation = new Quaternion(0f, -spawned.rotation.y , 0f, 0f);
                Destroy(spawned.gameObject, 10f);
            }
            Destroy(gameObject);
        }
    }
}
