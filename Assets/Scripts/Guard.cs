using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
public class Guard : MonoBehaviour
{
   // public SphereCollider playerdetector;
    public Animator anim;
    public Player player;
    private NavMeshAgent navAgent;
    //public float Dis = 2f;
    public bool isRun;
    public Transform Destination;
    public GameObject Enemy;
    public float Range = 6f;
    private bool isActive;
    // Start is called before the first frame update
    void Start()
    {
        navAgent = GetComponent<NavMeshAgent>();
    }

  
    // Update is called once per frame
    void Update()
    {
        float Distance = Vector3.Distance(player.transform.position, gameObject.transform.position);
        if(Distance <= Range)
        {
            Enemy.gameObject.GetComponent<EnemyPatrol>().enabled = false;
            anim.SetBool("Walk", false);
            anim.SetBool("Run", true);
            navAgent.SetDestination(Destination.position);
            
            if(Distance <= navAgent.stoppingDistance)
            {
                anim.SetBool("Attack", true);
                FaceTarget();
            }
            else
            {
                anim.SetBool("Attack", false);
            }
        }
        
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, Range);
    }

    private void FaceTarget()
    {
        Vector3 Dir = (player.transform.position - transform.position).normalized;
        Quaternion Look = Quaternion.LookRotation(new Vector3(Dir.x, 0, Dir.z));
        transform.rotation = Quaternion.Slerp(transform.rotation, Look, Time.deltaTime * 2f);
    }

}
