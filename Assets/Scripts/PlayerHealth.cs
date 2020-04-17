using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    public float Health = 100f;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    public void IncreaseHealth(float factor)
    {
        Health = Mathf.Clamp(Health + factor, 0, 100);
    }

    public void decreaseHealth(float factor)
    {
        Health = Mathf.Clamp(Health - factor, 0, 100);
    }
    // Update is called once per frame
    void Update()
    {

    }

    public void TakeDamage(float damageAmount)
    {
        Health -= damageAmount;
    }
}
