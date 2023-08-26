using System.Collections;
using System.Collections.Generic;
<<<<<<< HEAD
using System.Threading;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
=======
using UnityEngine;
using UnityEngine.UI;
>>>>>>> Portix

public class FinishLine : MonoBehaviour
{
    [SerializeField] Transform playerTransform;
    [SerializeField] Scrollbar sb;
<<<<<<< HEAD
    [SerializeField] GameObject endScreen;
    [SerializeField] TextMeshProUGUI scoreFinal;
    [SerializeField] TextMeshProUGUI timeText;
    float fallTime = 0;
    float dif;
    float initialDist;
    bool isFalling = true;

=======
    float dif;
    float initialDist;
    // Start is called before the first frame update
>>>>>>> Portix
    void Start()
    {
        initialDist = playerTransform.position.y - transform.position.y;
    }

<<<<<<< HEAD
    void Update()
    {
        Scroll();
        CalculateTime();
    }

    public void Scroll()
    {
        dif = playerTransform.position.y - transform.position.y;
        sb.value = dif / initialDist;
    }

    public void CalculateTime()
    {
        if (isFalling)
        {
            fallTime += Time.deltaTime;
            timeText.text = fallTime.ToString();
        }
        
    }
    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.CompareTag("Player"))
        {
            isFalling = false;
            timeText.transform.parent.gameObject.SetActive(false);
            scoreFinal.text = timeText.text;
            endScreen.SetActive(true);
        }
        
        
    }
=======
    // Update is called once per frame
    void Update()
    {
        dif = playerTransform.position.y - transform.position.y;
        sb.value = dif / initialDist;
    }
>>>>>>> Portix
}
