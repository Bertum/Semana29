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
        //Debug.Log(currentWayPointIndex);
        //if (navMeshAgent.remainingDistance <= navMeshAgent.stoppingDistance && !navMeshAgent.pathPending)   {
        //Debug.Log("Distancia hasta el punto " + currentWayPointIndex + " es " + Vector3.Distance(navMeshAgent.transform.position, WayPoints[currentWayPointIndex].transform.position));
        if (Vector3.Distance(navMeshAgent.transform.position, WayPoints[currentWayPointIndex].transform.position) <= 15)
        {
            navMeshAgent.isStopped = true;
            if (currentWayPointIndex < WayPoints.Count - 1)
            {
                currentWayPointIndex++;
                NextWayPoint(currentWayPointIndex);
            }
            else
            {
                currentWayPointIndex = 0;
                NextWayPoint(currentWayPointIndex);
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
