using UnityEngine;
using System.Collections;

public class DronePatrol : MonoBehaviour {

    public Transform[] patrolPoints;
    NavMeshAgent droneAgent;
    int patrolPointID;
	void Awake () 
    {
        droneAgent = GetComponent<NavMeshAgent>();
        patrolPointID = 0;
        nextPatrolSpot();
	}
	
	
	void Update () 
    {
	    if(droneAgent.remainingDistance < 0.5f)
        {
            nextPatrolSpot();
        }
	}


    void nextPatrolSpot()
    {
        if (patrolPointID < patrolPoints.Length)
        {
            patrolPointID++;
        }
        else
        {
            patrolPointID = 0;
        }

        droneAgent.destination = patrolPoints[patrolPointID].position;
    }

}
