using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class WayPointPatrol : MonoBehaviour
{
    int m_CurrentWayPointIndex;
    public NavMeshAgent navMeshAgent;
    public Transform[] waypoints;
    // Start is called before the first frame update
    void Start()
    {
        navMeshAgent.SetDestination(waypoints[0].position);
    }

    // Update is called once per frame
    void Update()
    {
        if(navMeshAgent.remainingDistance < navMeshAgent.stoppingDistance)
        {
            m_CurrentWayPointIndex = (m_CurrentWayPointIndex + 1) % waypoints.Length;
            Debug.Log($"hoa m_CurrentWayPointIndex ={m_CurrentWayPointIndex}, waypoints.Length ={waypoints.Length}");
            navMeshAgent.SetDestination( waypoints[m_CurrentWayPointIndex].position );
        }
    }
}
