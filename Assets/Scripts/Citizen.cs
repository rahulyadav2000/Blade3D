using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class Citizen : MonoBehaviour
{
    public List<Transform> WP = new List<Transform>();
    private Transform TarWP;
    private int Index;
    private int LastWP;
    private float MinDis = 0.2f;
    public Animator anim;

    public float speed;
    public float RotateSpeed;

    // Start is called before the first frame update
    void Start()
    {
        LastWP = WP.Count - 1;
        TarWP = WP[Index];
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 DistanceToLook = (TarWP.position - transform.position).normalized;
        Quaternion RotateToLook = Quaternion.LookRotation(DistanceToLook);

        transform.rotation = Quaternion.Slerp(transform.rotation, RotateToLook, RotateSpeed * Time.deltaTime);

        float Distance = Vector3.Distance(transform.position, TarWP.position);
        CheckDistance(Distance);

        transform.position = Vector3.MoveTowards(transform.position, TarWP.transform.position, speed * Time.deltaTime);
    }

    private void CheckDistance(float CurrentDistance)
    {
        if(CurrentDistance <= MinDis)
        {
            Index++;
            UpdateWPIndex();
        }
    }

    private void UpdateWPIndex()
    {
        if(Index > LastWP)
        {
            Index = 0;
        }
        TarWP = WP[Index];
    }
}
