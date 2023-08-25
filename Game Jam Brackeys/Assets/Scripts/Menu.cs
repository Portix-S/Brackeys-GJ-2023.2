using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
public class Menu : MonoBehaviour
{
    AudioSource aud;
    [SerializeField] Slider sld;
    private void Start()
    {
        aud = FindObjectOfType<AudioSource>();
        if(sld != null)
        {
            sld.value = aud.volume;
        }
    }
    public void GoToScene(string x)
    {
        SceneManager.LoadScene(x);
    }

    public void ChangeVolume()
    {
        aud.volume = sld.value;
    }

}
