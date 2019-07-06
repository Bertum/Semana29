using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class IAController : MonoBehaviour
{
    public List<GameObject> WayPoints;
    private int currentWayPointIndex;
    private int lap;
    private NavMeshAgent navMeshAgent;


    private void Awake()
    {
        currentWayPointIndex = 0;
        lap = 0;
        navMeshAgent = GetComponent<NavMeshAgent>();
        navMeshAgent.autoBraking = false;
        navMeshAgent.updatePosition = true;
        navMeshAgent.updateRotation = true;
        SetDestination(currentWayPointIndex);
    }

    void Update()
    {
        Debug.Log(currentWayPointIndex);
        if (navMeshAgent.remainingDistance <= navMeshAgent.stoppingDistance && !navMeshAgent.pathPending)
        {
            navMeshAgent.isStopped = true;
            if (currentWayPointIndex <= WayPoints.Count)
            {
                currentWayPointIndex++;
                NextWayPoint(currentWayPointIndex);
            }
            else
            {
                NextWayPoint(0);
            }
        }
    }

    private void NextWayPoint(int index)
    {
        this.gameObject.transform.LookAt(WayPoints[index].transform);
        SetDestination(index);
    }

    private void SetDestination(int index)
    {
        navMeshAgent.SetDestination(WayPoints[index].transform.position);
        navMeshAgent.isStopped = false;
    }
}
