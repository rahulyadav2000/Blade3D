using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GuardHealth : MonoBehaviour
{
    public float Health = 100f;
    public Animator anim;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Health <= 0)
        {
            anim.SetBool("Death", true);
        }
    }

    public void TakeDamage(float damageAmount)
    {
        Health -= damageAmount;
    }
}
