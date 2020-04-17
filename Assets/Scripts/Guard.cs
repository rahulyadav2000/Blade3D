using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
public class Guard : MonoBehaviour
{
    public Animator anim;
    public Player player;
    private NavMeshAgent navAgent;
    public float Dis = 6f;
    public bool isRun;
    public Transform Destination;
    // Start is called before the first frame update
    void Start()
    {
        navAgent = GetComponent<NavMeshAgent>();
    }

    public void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            if (!isRun)
            {
                isRun = true;
               // Debug.Log("Detected");
                anim.SetBool("Run", true);
            }
        }       
    }
    // Update is called once per frame
    void Update()
    {
        Dis = Vector3.Distance(player.transform.position, gameObject.transform.position);
        if(isRun)
        {
            if(Dis > 1.76f )
            {
                isRun = true;
                anim.SetBool("Run", true);
                navAgent.SetDestination(Destination.position);
                anim.SetBool("Attack", false);
            }
            else
            {
                anim.SetBool("Attack", true);
            }
        }
    }

    /*private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, Dis);
    }*/
}
