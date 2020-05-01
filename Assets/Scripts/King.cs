using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class King : MonoBehaviour
{
    public Animator anim;
    public Player player;
    private NavMeshAgent navAgent;
    public Transform Destination;
    public GameObject Enemy;
    public float Range = 6f;
    private bool InRange;
    // Start is called before the first frame update
    void Start()
    {
        navAgent = GetComponent<NavMeshAgent>();
    }


    // Update is called once per frame
    void Update()
    {
        float Distance = Vector3.Distance(player.transform.position, gameObject.transform.position);
        if (Distance <= Range)
        {
            anim.SetBool("Idle", true);
            InRange = true;
            navAgent.ResetPath();
        }
        if (Distance > Range)
        {
            InRange = false;
            anim.SetBool("Run", false);
            navAgent.isStopped = true;
            anim.SetBool("Idle", true);

        }

        if (InRange)
        {
            if (Distance <= navAgent.stoppingDistance)
            {
                anim.SetBool("Attack", true);
                anim.SetBool("Run", false);
                anim.SetBool("Idle", false);
            }

            if (Distance > navAgent.stoppingDistance)
            {
                anim.SetBool("Attack", false);
                anim.SetBool("Run", true);
                anim.SetBool("Idle", false);
                navAgent.SetDestination(Destination.position);
                FaceTarget();
            }
        }

    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.blue;
        Gizmos.DrawWireSphere(transform.position, Range);
    }

    private void FaceTarget()
    {
        Vector3 Dir = (player.transform.position - transform.position).normalized;
        Quaternion Look = Quaternion.LookRotation(new Vector3(Dir.x, 0, Dir.z));
        transform.rotation = Quaternion.Slerp(transform.rotation, Look, Time.deltaTime * 2f);
    }
}
