using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class MoveFwd : MonoBehaviour
{
    [SerializeField] int dmg = 1;
    [SerializeField] float force;
    [SerializeField] GameObject feathersPrefab;
    Rigidbody rb;
    public float speed;
    // Start is called before the first frame update
    void Start()
    {
        //rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = new Vector3(transform.position.x + speed * Time.deltaTime, transform.position.y, transform.position.z);
    }

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.CompareTag("Player"))
        {
            PlayerHealth player = collision.gameObject.transform.root.GetComponent<PlayerHealth>();
            if (player.canTakeDmg)
            {
                player.TakeHit(dmg);

            }
            
            
            GameObject feathers = feathersPrefab;
            GameObject spawn = Instantiate(feathers, transform.position, Quaternion.identity);
            Destroy(spawn, 2f);
            collision.gameObject.GetComponent<Rigidbody>().AddForce(Vector2.up * force * 2, ForceMode.Impulse);
            Destroy(gameObject);
        }
    }

    

}
