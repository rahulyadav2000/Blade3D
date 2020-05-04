using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GuardHealth : MonoBehaviour
{
    public float Health = 100f;
    public Animator anim;
    private AudioSource audio;
    public AudioClip die;
    // Start is called before the first frame update
    void Start()
    {
        audio = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        if(Health <= 0)
        {
            audio.PlayOneShot(die);
            anim.SetBool("Dead", true);
            Invoke("Death", 2.6f);
        }
    }

    public void TakeDamage(float damageAmount)
    {
        Health -= damageAmount;
    }
    
    private void Death()
    {
        Destroy(gameObject);
    }
}
