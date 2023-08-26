using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Heart : MonoBehaviour
{
    [SerializeField] GameObject[] lifeSprites;
    [SerializeField] GameObject particlePrefab;

    void Start()
    {
        lifeSprites = GameObject.FindGameObjectWithTag("GameController").GetComponent<GameManager>().lifeImages;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.CompareTag("Player"))
        {
            
            int l = other.transform.root.GetComponent<PlayerHealth>().life;
            if ( l < 3)
            {
                other.transform.root.GetComponent<PlayerHealth>().life += 1;
                lifeSprites[l].SetActive(true);
                
            }
            GameObject exp = Instantiate(particlePrefab, transform.position, Quaternion.identity);

            Destroy(gameObject);
        }
    }
}
