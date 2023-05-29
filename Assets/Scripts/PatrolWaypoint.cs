using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class PatrolWaypoint : MonoBehaviour
{
    public NavMeshAgent navMeshAgent;
    public Transform[] waypoints;

    int m_CurrentWaypoint;
    void Start()
    {
        navMeshAgent.SetDestination(waypoints[0].position); 
    }

    void Update()
    {
        if(navMeshAgent.remainingDistance < navMeshAgent.stoppingDistance)
        {
            m_CurrentWaypoint = (m_CurrentWaypoint + 1) % waypoints.Length;
            navMeshAgent.SetDestination(waypoints[m_CurrentWaypoint].position);

        }   
    }
}
