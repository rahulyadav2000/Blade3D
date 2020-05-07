using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Eatables : MonoBehaviour
{
    public float health = 15f;

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {

            collision.gameObject.GetComponent<PlayerHealth>().IncreaseHealth(15);
            Destroy(gameObject);

        }
    }

}
