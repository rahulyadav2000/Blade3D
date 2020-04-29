using System.Collections;
using System.Collections.Generic;
using UnityEditor.Rendering;
using UnityEngine;

public class EnemyPatrol : MonoBehaviour
{
    public List<Transform> WayPoints = new List<Transform>();
    private Transform TargetWP;
    private int TargetWPIndex;
    private float minDistance = 0.2f;
    private int LastWPIndex;
    public Animator anim;

    private float speed = 1.2f;
    private float RotateSpeed = 2f;
    // Start is called before the first frame update
    void Start()
    {
        LastWPIndex = WayPoints.Count - 1;
        TargetWP = WayPoints[TargetWPIndex];
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 DirectionToWP = TargetWP.position - transform.position;
        Quaternion RotationtoWP = Quaternion.LookRotation(DirectionToWP);

        transform.rotation = Quaternion.Slerp(transform.rotation, RotationtoWP, RotateSpeed * Time.deltaTime);

        float distance = Vector3.Distance(transform.position, TargetWP.position);
        CheckDistance(distance);
        anim.SetBool("Walk", true);

        transform.position = Vector3.MoveTowards(transform.position, TargetWP.position, speed * Time.deltaTime);

    }

    void CheckDistance(float CurrentDistace)
    {
        if(CurrentDistace <= minDistance)
        {
            TargetWPIndex++;
            UpdateWP();
        }
    }

    void UpdateWP()
    {
        if(TargetWPIndex > LastWPIndex)
        {
            TargetWPIndex = 0;
        }
        TargetWP = WayPoints[TargetWPIndex];
    }
}
