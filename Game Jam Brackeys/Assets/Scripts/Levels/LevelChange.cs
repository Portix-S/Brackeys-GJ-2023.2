using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelChange : MonoBehaviour
{
    GameManager gm;
    [SerializeField] float force = 150f;
    [SerializeField] Rigidbody[] rbs;
    bool isDestroyed;
    // Start is called before the first frame update
    void Start()
    {
        gm = GameObject.FindGameObjectWithTag("GameController").GetComponent<GameManager>();
    }

    private void OnCollisionEnter(Collision collision)
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player" && !isDestroyed)
        {
            int rand = Random.Range(0, 2);
            if (rand == 0)
                rand = -1;
            other.gameObject.GetComponent<Rigidbody>().AddForce(Vector2.left * force * 2 * rand, ForceMode.Impulse);
            isDestroyed = true;
            gm.ChangeLevel();
            // Play Anim?
            rbs = GetComponentsInChildren<Rigidbody>();
            foreach (Rigidbody rb in rbs)
            {
                rb.constraints = RigidbodyConstraints.None;
                rb.AddExplosionForce(0.5f, other.gameObject.transform.position, 2f);
                rb.useGravity = true;
                rb.mass = 10f;
                Destroy(rb.gameObject, 5f);
            }
        }
    }
}
