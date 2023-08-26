using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioHandler : MonoBehaviour
{
    [SerializeField] AudioClip[] songs;
    AudioSource audSource;

    public static AudioHandler instance;
    private void Awake()
    {

        
    }

    // Start is called before the first frame update
    void Start()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
        audSource = GetComponent<AudioSource>();
        audSource.PlayOneShot(songs[0]);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
