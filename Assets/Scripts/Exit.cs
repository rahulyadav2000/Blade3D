using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Exit : MonoBehaviour
{
    public bool GemCollected = false;
    public bool IsExit = false;
    public GameObject Lighting;
    private AudioSource audio;
    public AudioClip win;
    
    // Start is called before the first frame update
    void Start()
    {
        Lighting.SetActive(false);
        audio = GetComponent<AudioSource>();
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
                    //Debug.Log("GameOver");
                    Lighting.SetActive(true);
                    Invoke("Reached", 9f);
                    audio.PlayOneShot(win);
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

    private void Reached()
    {
        SceneManager.LoadScene("WinScene");
    }
}
