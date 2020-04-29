using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Exit : MonoBehaviour
{
    public bool GemCollected = false;
    public bool IsExit = false;
    
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (IsExit)
        {
            if (GemCollected)
            {
                if (Input.GetKeyDown(KeyCode.P))
                {
                    Debug.Log("GameOver");
                }
            }
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
           // GemCollected = true;
            IsExit = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {           
            IsExit = false;
        }
    }
}
