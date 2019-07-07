using System;
using UnityEngine;

public class GoalController : MonoBehaviour
{
    private int nextGoal;
    private int lastGoal;

    private void Awake()
    {
        nextGoal = 1;
        lastGoal = GameObject.FindGameObjectsWithTag(Tags.GoalPoints.ToString()).Length + 1;
    }

    private void OnTriggerEnter(Collider other)
    {
        Debug.Log(other.name);
        if (other.tag == Tags.GoalPoints.ToString() && nextGoal == Convert.ToInt32(other.name))
        {
            //Set next point
            nextGoal++;
        }
        else if (other.tag == Tags.MainGoal.ToString() && nextGoal == lastGoal)
        {
            //Player Win
            Debug.Log(string.Format("{0} Win!", this.gameObject.name));
        }
    }



}
