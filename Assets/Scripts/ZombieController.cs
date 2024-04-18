using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class ZombieController : MonoBehaviour
{


    private NavMeshAgent agent = null;

    [SerializeField]
    private Transform target;

    [SerializeField]
    private float rotationSpeed = 5f;


    // Start is called before the first frame update
    void Start()
    {
        GetReferences();

    }

    // Update is called once per frame
    void Update()
    {
        MoveToTarget();
    }

    private void MoveToTarget()
    {
        agent.SetDestination(target.position);
        RotateToTarget();
    }

    private void RotateToTarget()
    {

        Vector3 direction = (target.position - transform.position).normalized;
        if (direction != Vector3.zero)
        {
            Quaternion lookRotation = Quaternion.LookRotation(direction);
            transform.rotation = Quaternion.Slerp(transform.rotation, lookRotation, Time.deltaTime * rotationSpeed);
        }

    }

    private void GetReferences()
    {
        agent = GetComponent<NavMeshAgent>();
    }
}
